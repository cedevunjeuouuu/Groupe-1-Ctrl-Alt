using System;
using UnityEngine;

public class BeerBottle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.INSTANCE.BeerRessourceReference.Add(1);
            Destroy(gameObject);
        }
    }
}
