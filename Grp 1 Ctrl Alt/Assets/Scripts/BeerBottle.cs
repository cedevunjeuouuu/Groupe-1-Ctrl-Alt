using System;
using UnityEngine;

public class BeerBottle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("boop");

        if (other.CompareTag("Player"))
        {
            GameManager.INSTANCE.BeerRessourceReference.Add(1);
        }
    }
}
