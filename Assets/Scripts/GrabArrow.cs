using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabArrow : MonoBehaviour
{
    public static bool arrowGrabbed;
    public GameObject arrowPrefab;
    public Transform vrHand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (!arrowGrabbed)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger))
                {
                    GameObject arrowObject = Instantiate(arrowPrefab, vrHand);
                    ShootingLogic.currentArrow = arrowObject;
                    arrowGrabbed = true;
                }
            }
        }
    }
}
