using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public static Action<Enemy> OnEnemyKilled;
    public static Action<Enemy> OnEnemyHit;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Image HealthBar;
    [SerializeField] private Transform barPosition;
    [SerializeField] private float InitialHealth = 10f;
    [SerializeField] private float MaxHealth = 10f;

    public float CurrentHealth { get; set; }

    private Enemy enemy;
    private ObjectPooler pooler;
    private GameObject[] gameObjects;
    private GameControler gameControler;
    // Start is called before the first frame update
    void Start()
    {
        //CreateHealthBar();
        CurrentHealth = InitialHealth;
        pooler = GetComponent<ObjectPooler>();
        enemy = GetComponent<Enemy>();
        gameObjects = GameObject.FindGameObjectsWithTag("GameController");
        gameControler = gameObjects[0].GetComponent<GameControler>();

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Bullet":
                DealDamage(3.5f);
                break;

            case "Projectile":
                DealDamage(2f);
                break;

            case "MotherTree":
                Die();
                break;

            default:
                break;
        }
    }

    public void DealDamage(float damageReceived)
    {
        audioSource.Play();
        CurrentHealth -= damageReceived;
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            Die();
        }else
        {
            OnEnemyHit?.Invoke(enemy);
        }
    }

    void Die()
    {
        //play animation //deal damage to mothertree and stuff
        Destroy(gameObject);
        gameControler.AddScore();
    }
}
