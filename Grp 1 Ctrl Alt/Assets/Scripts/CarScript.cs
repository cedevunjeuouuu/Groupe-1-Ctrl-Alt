using DG.Tweening;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    [SerializeField] private Vector3 endPosition;
    [SerializeField] private float timeToCompleteMovement = 5f;
    [SerializeField]
    private float penality = 10f;

    private void Awake()
    {
        transform.DOMove(endPosition, timeToCompleteMovement).SetEase(Ease.Linear).onComplete = EndMove;
    }

    void EndMove()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<SusRessource>().Add(penality);
        }
    }

    // rajouter des fonctions genre appel de phare et tout pour immersion qui sont appelés quand on se rapproche du player
}
