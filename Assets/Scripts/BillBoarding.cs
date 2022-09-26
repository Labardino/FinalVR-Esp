using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoarding : MonoBehaviour
{
    private GameObject playerpos;
    // Start is called before the first frame update
    void Start()
    {
        playerpos = FindObjectOfType<OVRCameraRig>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(this.transform.position - (playerpos.transform.position - this.transform.position));
        this.transform.LookAt(playerpos.transform.position);
    }
}
