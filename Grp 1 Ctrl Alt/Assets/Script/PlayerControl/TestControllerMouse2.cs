using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class TestControllerMouse2 : MonoBehaviour, IPlayerController
{
    public float position { get; set; }
    public float stability { get; set; }

    public float velocity;
    public float acceleration;

    public float velocity_cap = 50;

    private float screenSize;
    private float value;

    public void Start()
    {
        screenSize = Screen.width / 2f;
    }

    public void Update()
    {
        velocity += acceleration * Time.deltaTime;
        velocity = Mathf.Clamp(velocity, -velocity_cap, velocity_cap);
        position += velocity * Time.deltaTime;
    }

    public void OnMouseDelta(InputValue pValue)
    {
        value = pValue.Get<float>();
        //value *= value * Mathf.Sign(value);
        acceleration = value / 5;

    }

}
