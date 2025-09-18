using UnityEngine;

public class Mover : MonoBehaviour
{

    public static float speed = 80;

    void Update()
    {
        transform.position += Vector3.back * speed * Time.deltaTime;
    }
}
