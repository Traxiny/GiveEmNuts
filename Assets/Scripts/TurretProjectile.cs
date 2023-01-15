using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretProjectile : MonoBehaviour
{
    [SerializeField] protected Transform projectileSpawnPosition;
    [SerializeField] protected float delayBtwAttacks = 2f;
    [SerializeField] protected float damage = 2f;

    public float Damage { get; set; }
    public float DelayPerShot { get; set;}
    protected float nextAttacktime;
    protected ObjectPooler pooler;
    protected TreeTurret turret;
    protected Projectile currentProjectileLoaded;
    // Start is called before the first frame update
    void Start()
    {
        pooler = GetComponent<ObjectPooler>();
        turret = GetComponent<TreeTurret>();

        Damage = damage;
        DelayPerShot = delayBtwAttacks;
        LoadProjectiles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LoadProjectiles()
    {
        GameObject newInstance = pooler.GetInstanceFromPool();
    }
}
