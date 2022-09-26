using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject theEnemy;
    private int x,z;
    public int min_x;
    public int max_x;
    public int min_z;
    public int max_z;
    public Vector3 position;

    public static GenerateEnemies instance;
    public List<Transform> spawnPositions;

    private List<GameObject> pooledObjects = new List<GameObject>();
    private int amountToPool = 10;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = DropEnemy();
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject DropEnemy()
    {
        return Instantiate(theEnemy, RandomizePosition(), Quaternion.identity);
    }

    public Vector3 RandomizePosition()
    {
        int rand = Random.Range(0, (spawnPositions.Count));
        return spawnPositions[rand].position;
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i< pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                pooledObjects[i].transform.position = RandomizePosition();
                return pooledObjects[i];
            }
        }
        return null;
    }

}
