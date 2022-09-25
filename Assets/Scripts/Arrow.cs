using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Oculus.Voice.Windows;

public class Arrow : MonoBehaviour
{
    public Transform arrowTip;
    public Rigidbody rb;
    private Vector3 lastPos = Vector3.zero;
    private bool stopped;
    private float arrowSpeed = 1000f;

    public Test testo;

    private void Start()
    {
        lastPos = this.transform.position;
    }

    private void FixedUpdate()
    {
        if (stopped)
            return;
        rb.MoveRotation(Quaternion.LookRotation(rb.velocity, transform.up));

        RaycastHit hit;
        if (Physics.Linecast(lastPos, arrowTip.position, out hit, LayerMask.NameToLayer("Bow")))
        {
            StopMoving(hit.collider.gameObject);
        }
        lastPos = arrowTip.position;
    }

    void StopMoving(GameObject objectHit)
    {
        stopped = true;

        this.transform.parent = objectHit.transform;
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
    void CheckForDamage(GameObject objectHit)
    {

    }
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

        Destroy(this.gameObject, 8.0f);
    }
}
