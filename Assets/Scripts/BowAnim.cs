using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BowAnim : MonoBehaviour
{
    public Animator anim;
    public Transform start, end, mid;
    public Vector3 dist, direction;
    public static float blendValue;

    // Update is called once per frame
    void Update()
    {
        if(ShootingLogic.arrowLoaded)
        {
            blendValue = Mathf.Clamp(PullBow(), 0.0f, 1.0f);
            anim.SetFloat("Blend", blendValue);

        }
        else
        {
            anim.SetFloat("Blend", 0);
        }
    }

    float PullBow()
    {
        direction = end.position - start.position;
        float magnitude = direction.magnitude;
        direction.Normalize();

        dist = this.transform.position - start.position;
        return Vector3.Dot(dist, direction) / magnitude;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.transform.gameObject == mid.transform.gameObject && ShootingLogic.arrowLoaded)
        {
            FindObjectOfType<AudioManager>().Play("tenseBow");
        }
    }
}
