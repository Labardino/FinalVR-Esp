using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingLogic : MonoBehaviour
{
    public static GameObject currentArrow;
    public static bool arrowLoaded = false, arrowShot;
    public Transform stringNotch;
    public Arrow arrowScript;

    // Update is called once per frame
    void Update()
    {
        if (!OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
        {
            if (arrowScript && arrowLoaded)
            {
                arrowScript.FireArrow();
            }
            arrowLoaded = false;
            arrowShot = true;

        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if(OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
            {
                if (currentArrow.gameObject.GetInstanceID() != other.gameObject.GetInstanceID())
                {
                    currentArrow.transform.forward = -this.transform.forward;
                    currentArrow.transform.position = stringNotch.transform.position;
                    currentArrow.transform.parent = stringNotch;
                    arrowScript = currentArrow.GetComponent<Arrow>();
                    arrowLoaded = true;
                }
                else
                {
                    currentArrow = null;
                }
            }
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
    //    { 
    //        if (!OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
    //        {
    //            arrowLoaded = false;
    //        }
    //    }
    //}
}
