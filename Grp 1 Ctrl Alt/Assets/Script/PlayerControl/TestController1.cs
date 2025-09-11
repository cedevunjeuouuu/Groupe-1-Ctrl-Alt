using UnityEngine;
using UnityEngine.InputSystem;

public class TestController1 : MonoBehaviour, IPlayerController
{
    public float position { get; set; }
    public float stability { get; set; }

    public float velocity;
    public float acceleration;

    public void Start() { }

    public void Update()
    {
        velocity += acceleration * Time.deltaTime;
        position += velocity * Time.deltaTime;
    }

    public void OnMove(InputValue pValue)
    {
        print("bwa");
        acceleration = pValue.Get<Vector2>().x;
    }
}
