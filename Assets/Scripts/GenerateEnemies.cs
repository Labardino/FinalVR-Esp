using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject theEnemy;
    public int x;
    public int z;
    public int min_x;
    public int max_x;
    public int min_z;
    public int max_z;

    public static GenerateEnemies instance;

    private List<GameObject> pooledObjects = new List<GameObject>();
    private int amountToPool = 30;

    [SerializeField] private GameObject Cube; // Change this to the prefab

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
        x = Random.Range(min_x, max_x);
        z = Random.Range(min_z, max_z);
        return Instantiate(theEnemy, new Vector3(x, 1, z), Quaternion.identity);
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
                return pooledObjects[i];
        }
        return null;
    }

}
