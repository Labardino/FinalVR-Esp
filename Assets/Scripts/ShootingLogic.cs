using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingLogic : MonoBehaviour
{
    public static GameObject currentArrow;
    public static bool isShooting, arrowLoaded;
    public Transform stringNotch;
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
            }
            if(OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
            {
                arrowLoaded = isShooting = true;

                GameObject parent = other.gameObject.transform.parent.gameObject;
                other.gameObject.transform.SetAsLastSibling();
                currentArrow = parent.transform.GetChild(0).gameObject;
                if (currentArrow.name != other.gameObject.name)
                {
                    currentArrow.transform.up = -this.transform.forward;
                    currentArrow.transform.position = stringNotch.transform.position;
                    currentArrow.transform.parent = stringNotch;
                }
                else
                {
                    currentArrow = null;
                }
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
