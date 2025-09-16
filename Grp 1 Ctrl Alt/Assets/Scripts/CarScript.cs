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
            other.GetComponent<PlayerController>().DoBump(bump * Mathf.Sign(transform.position.x - other.transform.position.x));
        }
    }

    // rajouter des fonctions genre appel de phare et tout pour immersion qui sont appelés quand on se rapproche du player
}
