using System;
using System.Collections;
using UnityEngine;

public class Bump : MonoBehaviour
{
    [SerializeField] private float bumpForce = 800f;
    [SerializeField] private float bumpDuration = 0.1f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.transform.position.x < transform.position.x)
            {
                BumpLeft(other.GetComponent<Rigidbody>());
            }
            else
            {
                BumpRight(other.GetComponent<Rigidbody>());
            }
        }
    }

    void BumpRight(Rigidbody rb)
    {
        rb.linearVelocity = new Vector3(bumpForce, 0,0);
        StartCoroutine(StopBump(rb));
    }
    void BumpLeft(Rigidbody rb)
    {
        rb.linearVelocity = new Vector3(-bumpForce, 0, 0);
        StartCoroutine(StopBump(rb));
    }

    IEnumerator StopBump(Rigidbody rb)
    {
        yield return new WaitForSeconds(bumpDuration);
        rb.linearVelocity = new Vector3(0, 0, 0);
    }
}
