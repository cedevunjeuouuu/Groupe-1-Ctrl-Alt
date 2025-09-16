using UnityEngine;
using UnityEngine.InputSystem;

public class CursorLockedMouseController : MonoBehaviour, IPlayerController
{
    public float position { get; set; }
    public float stability { get; set; }

    public float velocity;
    public float acceleration;

    public float velocity_cap = 50;

    private float value;

    public float sensibility = 1;

    public void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Update()
    {
        velocity += acceleration * Time.deltaTime;
        velocity = Mathf.Clamp(velocity, -velocity_cap, velocity_cap);
        position += velocity * Time.deltaTime;
    }

    public void OnMouseDelta(InputValue pValue)
    {
        value = pValue.Get<float>() / sensibility;
        acceleration = value;
        print($"bwa {value}");
    }

}
