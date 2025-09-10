using DG.Tweening;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    [SerializeField] private Vector3 endPosition;
    [SerializeField] private float timeToCompleteMovement = 5f;
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
            // agir quand on touche le player
        }
    }
    
    // rajouter des fonctions genre appel de phare et tout pour oui
}
