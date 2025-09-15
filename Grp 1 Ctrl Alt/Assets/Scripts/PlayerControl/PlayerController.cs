using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float velocity;
    public float acceleration;
    public float snap;

    public float velocity_cap;

    [SerializeField]
    private float sensibility;

    private LayerMask maskwall;

    [SerializeField]
    private float WallDetector;

    public enum ControlScheme
    {
        Velocity,
        Acceleration,
        Snap,
    }

    [SerializeField]
    private ControlScheme controlScheme;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        maskwall = LayerMask.GetMask("Wall"); // need to find a better way to do this stuff this feels so bad

    }


    public void Update()
    {
        acceleration += snap;
        velocity += acceleration * Time.deltaTime;
        velocity = Mathf.Clamp(velocity, -velocity_cap, velocity_cap);


        if (Physics.Raycast(transform.position, Vector3.right * Mathf.Sign(velocity), WallDetector, maskwall))
        {
            velocity = 0;
        }

        transform.Translate(Vector3.right * velocity * Time.deltaTime);
    }

    public void OnMouseDelta(InputValue pValue)
    {
        float value = pValue.Get<float>() / sensibility;
        snap = value;

        switch (controlScheme)
        {
            case ControlScheme.Velocity:
                velocity = value;
                break;
            case ControlScheme.Acceleration:
                acceleration = value;
                break;
            case ControlScheme.Snap:
                snap = value;
                break;
            default:
                throw new System.NotImplementedException();
        }
    }

}
