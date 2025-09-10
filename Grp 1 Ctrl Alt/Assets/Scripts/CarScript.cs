using DG.Tweening;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    [SerializeField] private Vector3 endPosition;
    [SerializeField] private float timeToCompleteMovement;
    private void Awake()
    {
        transform.DOMove(endPosition, timeToCompleteMovement).SetEase(Ease.Linear);
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
