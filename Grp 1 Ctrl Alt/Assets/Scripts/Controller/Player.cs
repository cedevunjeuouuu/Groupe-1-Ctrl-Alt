using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
  
    [Range(0f, 3f)]
    [SerializeField] private float alcoholLevel = 1f;
    [SerializeField] private float maxMoveSpeed = 100f;
    [Range(0f, 3f)]
    [SerializeField] private float chaos = 1f;
    [SerializeField] private float mouseSensibility = 10f;
    [SerializeField] private float balanceForce = 60f;
    [SerializeField] private float maxAngle = 45f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float bumpForce = 50f;
    [SerializeField] private float xMinPos = -100f;
    [SerializeField] private float xMaxPos = 100f;
    private float mouseX;
   
    private float noiseOffset;
    private float suddenTorqueTimer = 0f;
    private float targetSpeed;

    void Start()
    {
        rb.maxAngularVelocity = 30f;
        noiseOffset = Random.Range(0f, 100f);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OnMouseDelta(InputValue value)
    {
        mouseX = value.Get<float>() / mouseSensibility;
    }

    void FixedUpdate()
    {
        float noise = Mathf.PerlinNoise(Time.time * alcoholLevel * 5f + noiseOffset, 0f) * 2f - 1f;
        suddenTorqueTimer -= Time.fixedDeltaTime;
        float suddenTorque = 0f;
        if (suddenTorqueTimer <= 0f)
        {
            suddenTorque = (Random.value * 2f - 1f) * Mathf.Pow(alcoholLevel, 1.5f) * 200f * chaos;
            suddenTorqueTimer = Random.Range(0.02f, 0.15f / chaos);
        }
        float totalTorque = (noise * Mathf.Pow(alcoholLevel, 1.3f) * 100f * chaos) + suddenTorque;
        rb.AddTorque(Vector3.forward * totalTorque, ForceMode.Acceleration);
        rb.AddTorque(Vector3.forward * -mouseX * balanceForce, ForceMode.Acceleration);
        float angle = transform.localEulerAngles.z;
        if (angle > 180f)
        {
            angle -= 360f;
        }
        float angleFraction = angle / maxAngle;
        targetSpeed = -Mathf.Pow(Mathf.Abs(angleFraction), 1.5f) * maxMoveSpeed * Mathf.Sign(angleFraction);
        
        Vector3 move = new Vector3(targetSpeed * Time.fixedDeltaTime, 0f, 0f);
        rb.MovePosition(rb.position + move);
        
        
    }

    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, xMinPos, xMaxPos), transform.position.y, transform.position.z);
    }
}
