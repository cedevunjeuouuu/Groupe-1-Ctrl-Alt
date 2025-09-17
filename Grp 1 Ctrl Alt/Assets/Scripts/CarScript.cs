using UnityEngine;

public class CarScript : MonoBehaviour
{
    [SerializeField]
    private float penality = 10f;

    [SerializeField]
    private float bump = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindFirstObjectByType<SusRessource>()?.Add(penality);
            Destroy(gameObject);
        }
    }   
}
