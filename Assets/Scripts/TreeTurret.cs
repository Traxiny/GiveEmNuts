using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTurret : MonoBehaviour
{
    [SerializeField] private float Range = 1.3f;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform projectileTransform;
    [SerializeField] private bool canFire = true;

    private float timer;
    private bool isEnemy;
    public float timeBetweenFiring;

    private List<GameObject> enemies = new List<GameObject>();
    private Projectile projectiles;
    private GameObject CurrentEnemyTarget;
    // Start is called before the first frame update
    void Start()
    {
        projectiles = projectile.GetComponent<Projectile>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnemy)
        {

            GetCurrentEnemyTarget();
            if (!canFire)
            {
                timer += Time.deltaTime;
                if (timer > timeBetweenFiring)
                {
                    canFire = true;
                    timer = 0;
                }
            }

            if (canFire)
            {
                Debug.Log(CurrentEnemyTarget);
                canFire = false;
                GameObject newObject = Instantiate(projectile, projectileTransform.position, Quaternion.identity);
                Projectile proj = newObject.GetComponent<Projectile>();
                proj.SetEnemy(CurrentEnemyTarget);
            }
        }
    }

    void GetCurrentEnemyTarget()
    {
        if (enemies.Count <= 0)
        {
            CurrentEnemyTarget = null;
            return;
        }
        CurrentEnemyTarget = enemies[0];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemies.Add(other.gameObject);
            if (enemies.Count > 0)
            {
                isEnemy = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (enemies.Contains(other.gameObject))
            {
                enemies.Remove(other.gameObject);
                if (enemies.Count == 0)
                {
                    isEnemy = false;
                }
            }
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
