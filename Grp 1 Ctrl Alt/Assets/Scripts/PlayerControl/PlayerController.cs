using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float velocity;
    public float acceleration;

    public float velocity_cap;

    [SerializeField]
    private float sensibility;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    public void Update()
    {
        velocity += acceleration * Time.deltaTime;
        velocity = Mathf.Clamp(velocity, -velocity_cap, velocity_cap);
        float position = velocity * Time.deltaTime;


        print(Physics.Raycast(transform.position, Vector3.right * Mathf.Sign(velocity), Mathf.Abs(velocity)));
    }

    public void OnMouseDelta(InputValue pValue)
    {
        float value = pValue.Get<float>() / sensibility;
        acceleration = value;
        print($"bwa {value}");
    }

}
