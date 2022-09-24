using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingLogic : MonoBehaviour
{
    public GameObject hey;
    public static bool isShooting;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
        {
            isShooting = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
            {
                isShooting = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        { 
            if (!OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
            {
                isShooting = false;
            }
        }
    }
}
