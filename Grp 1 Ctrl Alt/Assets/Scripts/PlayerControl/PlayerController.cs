using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float velocity;
    public float acceleration;
    public float snap;

    public float velocity_multiplier = 1f;
    public float acceleration_multiplier = 1f;
    public float snap_multiplier = 1f;

    public float velocity_cap = 10000000000;
    public float acceleration_cap = 1000;
    public float snap_cap = 200;

    public float bump;
    public float bumpDuration = 0.3f;
    private float bumpTimer = 0f;

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
        snap = Mathf.Clamp(snap, -snap_cap, snap_cap);
        acceleration += snap * snap_multiplier;
        acceleration = Mathf.Clamp(acceleration, -acceleration_cap, acceleration_cap);

        velocity += acceleration * Time.deltaTime * acceleration_multiplier;
        velocity = Mathf.Clamp(velocity, -velocity_cap, velocity_cap) + bump * Time.deltaTime;


        if (Physics.Raycast(transform.position, Vector3.right * Mathf.Sign(velocity), WallDetector, maskwall))
        {
            velocity = 0;
            acceleration = 0;
            snap = 0;
            return;
        }

        transform.Translate(Vector3.right * velocity * velocity_multiplier * Time.deltaTime);

        DoBumpProgress();
    }

    private void DoBumpProgress()
    {
        if (bumpTimer < 0) return;


        float speed = bump / bumpDuration;

        transform.Translate(Vector3.right * speed * Time.deltaTime);

        bumpTimer -= Time.deltaTime;
    }

    public void DoBump(float pBumps)
    {
        bumpTimer = bumpDuration;
        bump = pBumps;
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
