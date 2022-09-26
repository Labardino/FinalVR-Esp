using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropEnemies : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GetEnemy", 10.0f, 10.0f);
    }

    public void GetEnemy()
    {
        GameObject enemy = GenerateEnemies.instance.GetPooledObject();
        if (enemy != null)
        {
            enemy.SetActive(true);
        }
    }
}
