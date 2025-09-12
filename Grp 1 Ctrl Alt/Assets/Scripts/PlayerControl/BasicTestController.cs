using UnityEngine;
using UnityEngine.InputSystem;

public class BasicTestController : MonoBehaviour, IPlayerController
{
    private float velocity;
    public float position { get; set; }
    public float stability { get; set; } = 1f;

    public float velocitymultiplier;

    public void Update()
    {
        position += velocity * Time.deltaTime;
    }

    public void OnMove(InputValue pValue)
    {
        velocity = pValue.Get<Vector2>().x;
        print(velocity);
    }
}
