using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject playerObj;
    public bool toDie;

    // Start is called before the first frame update
    void Awake()
    {
        playerObj = FindObjectOfType<OVRCameraRig>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(Vector3.zero, this.gameObject.transform.position);
        if (dist <= 2.80f)
        {
            agent.isStopped = true;
            StartCoroutine(DelayActive());
            if(!toDie)
                CheckForPlayerDamage();
        }
        else
        {
            agent.SetDestination(playerObj.transform.position);
        }
    }

    void CheckForPlayerDamage()
    {
        MonoBehaviour[] behaviours = playerObj.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour behaviour in behaviours)
        {
            if (behaviour is IDamageable)
            {
                IDamageable damageable = (IDamageable)behaviour;
                damageable.Damage(1.0f);
                toDie = true;
                break;
            }
        }
    }

    private void OnEnable()
    {
        this.gameObject.transform.LookAt(playerObj.transform.position);
    }

    IEnumerator DelayActive()
    {
        yield return new WaitForSeconds(3.0f);
        this.gameObject.SetActive(false);

    }
}
