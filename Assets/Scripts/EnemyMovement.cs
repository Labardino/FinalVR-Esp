using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject playerObj;

    // Start is called before the first frame update
    void Awake()
    {
        playerObj = FindObjectOfType<OVRCameraRig>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(Vector3.zero, this.gameObject.transform.position);
        if (dist <= 1.05)
        {
            //Wait 3 seconds to die
            StartCoroutine(DelayActive());
        }
        else
        {
            agent.SetDestination(playerObj.transform.position);
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
