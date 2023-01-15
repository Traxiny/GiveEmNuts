using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private int EnemyCount = 10;
    [SerializeField]
    private float DelayBtwSpawms;
    [SerializeField]
    private GameObject LightEnemy;
    [SerializeField]
    private float Radius;

    private float spawnTimer;
    private int enemiesSpawned;
    private ObjectPooler pooler;

    private DayScript day;
    // Start is called before the first frame update
    void Start()
    {
        pooler = GetComponent<ObjectPooler>();
        day = GetComponent<DayScript>();  
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer < 0)
        {
            spawnTimer = DelayBtwSpawms;
            //Debug.Log(day.isNight);
            if (enemiesSpawned < EnemyCount)//spawn only on night
            {
                enemiesSpawned++;
                SpawnEnemy();
            }
        }
    }
    void SpawnEnemy()
    {
        GameObject newInstance = CreateInstance();
        newInstance.SetActive(true);
    }
    public Vector2 GetPointOnCircleRadius()
    {
        float randomAngle = Random.Range(0f, Mathf.PI * 2f);
        return new Vector2(Mathf.Cos(randomAngle) * Radius, Mathf.Sin(randomAngle) * Radius);
    }
    GameObject CreateInstance()
    {
        Vector2 spawnPosition = GetPointOnCircleRadius();
        GameObject newInstance = Instantiate(LightEnemy);
        newInstance.transform.position = spawnPosition;
        newInstance.SetActive(false);
        return newInstance;
    }
}
