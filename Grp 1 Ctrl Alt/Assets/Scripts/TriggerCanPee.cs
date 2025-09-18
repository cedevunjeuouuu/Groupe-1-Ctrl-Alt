using UnityEngine;

public class TriggerCanPee : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.INSTANCE.canPee = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.INSTANCE.canPee = false;
        }
    }
}
