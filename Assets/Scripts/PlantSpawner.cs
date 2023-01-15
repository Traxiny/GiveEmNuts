using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpawner : MonoBehaviour
{
    [SerializeField]
    private float DelayBtwSpawms;
    [SerializeField]
    private int MaxTrees;
    [SerializeField]
    private int MaxBushes;
    [SerializeField]
    private int MaxShrooms;
    [SerializeField]
    private GameObject Bush;
    [SerializeField]
    private GameObject TreeTurret;
    [SerializeField]
    private GameObject ShroomBomb;
    [SerializeField]
    private GameObject ShroomBuff;
    [SerializeField]
    private GameControler GameControler;

    private float spawnTimer;
    private int currentTrees;
    private int currentBushes;
    private int currentShrooms;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer < 0)
        {
            spawnTimer = DelayBtwSpawms;
            int tmp = Random.Range(0, 10);
            if (tmp % 2 == 0)
            {
                if (currentShrooms < MaxShrooms)//spawn only on night
                {
                    SpawnShrooms();
                }
            }else
            {

                SpawnPlants();
            }
        }
    }

    void SpawnShrooms()
    {
        int tmp = Random.Range(0, 10); //which shroom will I spawn?
        if (tmp % 2 == 0)
        {
            Vector2 spawnPosition = GetPointOnCircleRadius();
            if ((spawnPosition.x >= 3 || spawnPosition.x <= -3) || (spawnPosition.y >= 2 || spawnPosition.y <= -2))
            {
                return;
            }
            GameObject newInstance = Instantiate(ShroomBuff);
            newInstance.transform.position = spawnPosition;

        }
        else
        {
            Vector2 spawnPosition = GetPointOnCircleRadius();
            if ((spawnPosition.x >= 3 || spawnPosition.x <= -3) || (spawnPosition.y >= 2 || spawnPosition.y <= -2))
            {
                return;
            }
            GameObject newInstance = Instantiate(ShroomBomb);
            newInstance.transform.position = spawnPosition;
        }
    }

    void SpawnPlants()
    {
        int tmp = Random.Range(0, 10); //which plant will I spawn?
        if (tmp % 2 == 0 && currentTrees < MaxTrees)
        {
            Vector2 spawnPosition = GetPointOnCircleRadius();
            if((spawnPosition.x >= 3 || spawnPosition.x <= -3)||(spawnPosition.y >= 2 || spawnPosition.y <= -2))
            {
                return;
            }
            GameObject newInstance = Instantiate(TreeTurret);
            newInstance.transform.position = spawnPosition;

        }else if(tmp%2==1 && currentBushes < MaxBushes)
        {
            Vector2 spawnPosition = GetPointOnCircleRadius();
            if ((spawnPosition.x >= 3 || spawnPosition.x <= -3) || (spawnPosition.y >= 2 || spawnPosition.y <= -2))
            {
                return;
            }
            GameObject newInstance = Instantiate(Bush);
            newInstance.transform.position = spawnPosition;
        }
    }
    public Vector2 GetPointOnCircleRadius()
    {
        float randomAngle = Random.Range(0f, Mathf.PI * 2f);
        float radius = Random.Range(1f, 2.5f);
        new Vector2(Mathf.Cos(randomAngle) * radius, Mathf.Sin(randomAngle) * radius);
        return new Vector2(Mathf.Cos(randomAngle) * radius, Mathf.Sin(randomAngle) * radius);
    }

}
