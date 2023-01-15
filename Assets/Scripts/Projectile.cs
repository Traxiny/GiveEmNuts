using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public static Action<Enemy, float> OnEnemyHit;

    [SerializeField]
    private float force = 2f;
    protected TreeTurret turret;
    private Rigidbody2D rb;
    public float Damage { get; set; }

    public GameObject enemyTarget;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.LookAt(enemyTarget.transform);
        rb.velocity = new Vector2(enemyTarget.transform.position.x, enemyTarget.transform.position.y) * force;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyTarget != null)
        {
            MoveProjectile(); 
        }
    }

    void MoveProjectile()
    {
        transform.Rotate(0, 0, 0.5f);
    }

    public void SetEnemy(GameObject enemy)
    {
        enemyTarget = enemy;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
