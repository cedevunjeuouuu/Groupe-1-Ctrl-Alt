using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private Vector3 direction;

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

    }
}
