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

        CheckForDamage(objectHit);

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
        MonoBehaviour[] behaviours = objectHit.GetComponents<MonoBehaviour>();
        foreach(MonoBehaviour behaviour in behaviours)
        {
            if(behaviour is IDamageable)
            {
                IDamageable damageable = (IDamageable)behaviour;
                damageable.Damage(10);

                break;
            }
        }
    }
    public void FireArrow()
    {
        lastPos = transform.position;

        stopped = false;
        this.transform.parent = null;
        this.rb.isKinematic = false;
        this.rb.useGravity = true;

        rb.AddForce(transform.forward * (BowAnim.blendValue * arrowSpeed));


        GrabArrow.arrowGrabbed = false;
        ShootingLogic.currentArrow = null;

        Destroy(this.gameObject, 8.0f);
    }
}
