using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float centerSensibility = 0.1f;
    [SerializeField] private float speedIntensity = 100f;
    [SerializeField] private float fallIntensity = 100f;
    [SerializeField] private Rigidbody rb;
    private float _center = 0f;

    private void Update()
    {
        _center = rb.linearVelocity.x;
        rb.AddForce(speedIntensity / _center, 0, 0);
    }
}
