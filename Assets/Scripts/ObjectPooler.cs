using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int PoolSize = 10;
    [SerializeField] private int Radius = 1;
    private List<GameObject> pool;
    private GameObject poolContainer;

    // Start is called before the first frame update
    void Awake()
    {
        pool = new List<GameObject>();
        poolContainer = new GameObject($"Pool - {prefab.name}");
        CreatePooler();
    }

    void CreatePooler()
    {
        for (int i = 0; i < PoolSize; i++)
        {
            pool.Add(CreateInstance());
        }
    }

    GameObject CreateInstance()
    {
        Vector2 spawnPosition = GetPointOnCircleRadius();
        GameObject newInstance = Instantiate(prefab);
        newInstance.transform.SetParent(poolContainer.transform);
        newInstance.transform.position = spawnPosition;
        newInstance.SetActive(false);
        return newInstance;
    }

    public GameObject GetInstanceFromPool()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                return pool[i];
            }
        }
        return CreateInstance();
    }

    public void ReturnToPool(GameObject instance)
    {
        instance.SetActive(false);
    }

    public static IEnumerator ReturnToPoolWithDelay(GameObject instance, float delay)
    {
        yield return new WaitForSeconds(delay);
        instance.SetActive(false);
    }
    public Vector2 GetPointOnCircleRadius()
    {
        float randomAngle = Random.Range(0f, Mathf.PI * 2f);
        return new Vector2(Mathf.Cos(randomAngle)*Radius, Mathf.Sin(randomAngle)*Radius);
    }
}
