using UnityEngine;
using DG.Tweening;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private Vector3 endPosition;
    [SerializeField]
    private float timeToCompleteMovement = 5f;

    private void Awake()
    {
        transform.DOMove(endPosition, timeToCompleteMovement).SetEase(Ease.Linear).onComplete = EndMove;
    }

    void EndMove()
    {
        Destroy(gameObject);
    }
}
