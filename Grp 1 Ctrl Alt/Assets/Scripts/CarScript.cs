using UnityEngine;

public class CarScript : MonoBehaviour
{
    [SerializeField]
    private float penality = 10f;

    [SerializeField]
    private float bump = 10f;

    [SerializeField]
    private bool wantToDestroy = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.INSTANCE.camera.Shake();
            FindFirstObjectByType<SusRessource>()?.Add(penality);
            if (wantToDestroy)
            {
                Destroy(gameObject);
            }
            
        }
    }   
}
