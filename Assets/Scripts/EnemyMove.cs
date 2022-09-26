using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    private NavMeshAgent enemy;

    private void Awake()
    {
        enemy = GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(new Vector3(0, 0, 0));
        float dist = Vector3.Distance(Vector3.zero, this.gameObject.transform.position);
        if(dist <= 0.05)
        {
            //DISABLE OBJECT
            Destroy(this.gameObject);
        }
    }
}
