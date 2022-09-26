using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent enemy;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(Vector3.zero, this.gameObject.transform.position);
        if (dist <= 1.05)
        {
            enemy.gameObject.SetActive(false);
        }
        else
        {
            enemy.SetDestination(new Vector3(0, 0, 0));
        }
    }
}
