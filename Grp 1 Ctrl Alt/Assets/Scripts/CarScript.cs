using UnityEngine;

public class CarScript : MonoBehaviour
{
    [SerializeField]
    private float penality = 10f;

    [SerializeField]
    private float bump = 10f;

    [SerializeField]
    private bool wantToDestroy = false;
    private bool isFirstTime = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.INSTANCE.camera.Shake();
            if (isFirstTime)
            {
                FindFirstObjectByType<SusRessource>()?.Add(penality);
                isFirstTime = false;
            }
            if (wantToDestroy)
            {
                Destroy(gameObject);
            }
            
        }
    }   
}
