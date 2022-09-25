using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Arrow : MonoBehaviour
{
    public Transform arrowTip;
    public Rigidbody rb;
    private Vector3 lastPos = Vector3.zero;
    private bool stopped;
    private float arrowSpeed = 1000f;

    public Test testo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (stopped)
            return;
        rb.MoveRotation(Quaternion.LookRotation(rb.velocity, transform.up));

        if (Physics.Linecast(lastPos, arrowTip.position, LayerMask.NameToLayer("Bow")))
        {
            StopMoving();
        }

        lastPos = arrowTip.position;
    }

    void StopMoving()
    {
        stopped = true;
        rb.isKinematic = true;
        rb.useGravity = false;

    }
    //IEnumerator StopArrow()
    //{
    //    yield return new WaitForSeconds(1f);
    //    stopped = true;
    //    rb.isKinematic = true;
    //    rb.useGravity = false;
    //}
    public void FireArrow()
    {
        stopped = false;
        this.transform.parent = null;
        this.rb.isKinematic = false;
        this.rb.useGravity = true;

        rb.AddForce(transform.forward * (BowAnim.blendValue * arrowSpeed));
        testo = FindObjectOfType<Test>();
        testo.CustomDebug();

        GrabArrow.arrowGrabbed = false;
        ShootingLogic.currentArrow = null;

        Destroy(this.gameObject, 5.0f);
    }
}
