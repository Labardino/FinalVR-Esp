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
    private float arrowSpeed = 1500f;


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
        if (Physics.Linecast(lastPos, arrowTip.position, out hit, LayerMask.NameToLayer("Bow"), QueryTriggerInteraction.Ignore))
        {
            StopMoving(hit.collider.gameObject);
        }
        lastPos = arrowTip.position;
    }

    void StopMoving(GameObject objectHit)
    {
        stopped = true;

        this.transform.parent = objectHit.transform;

        this.transform.localScale = Vector3.one * 2;

        rb.isKinematic = true;
        rb.useGravity = false;

        CheckForDamage(objectHit);

    }
    void CheckForDamage(GameObject objectHit)
    {
        MonoBehaviour[] behaviours = objectHit.GetComponents<MonoBehaviour>();
        foreach(MonoBehaviour behaviour in behaviours)
        {
            if(behaviour is IDamageable)
            {
                IDamageable damageable = (IDamageable)behaviour;
                damageable.Damage(50);
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
        FindObjectOfType<AudioManager>().Play("Arrow");
        Destroy(this.gameObject, 4.0f);
    }
}
