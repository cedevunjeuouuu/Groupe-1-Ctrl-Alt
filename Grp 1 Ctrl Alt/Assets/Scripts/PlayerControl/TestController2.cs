using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class TestController2 : MonoBehaviour, IPlayerController
{
    public float position { get; set; }
    public float stability { get; set; }

    public float velocity;
    public float acceleration;

    public float velocity_cap;

    public void Start() { }

    public void Update()
    {
        velocity += acceleration * Time.deltaTime;
        velocity = Mathf.Clamp(velocity, -velocity_cap, velocity_cap);
        position += velocity * Time.deltaTime;
    }

    public void OnMove(InputValue pValue)
    {
        print("bwa");
        acceleration = pValue.Get<Vector2>().x;
    }
}
