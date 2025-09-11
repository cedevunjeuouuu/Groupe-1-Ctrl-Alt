using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager INSTANCE;
    public BeerRessource BeerRessourceReference;
    public EnergyRessource EnergyRessourceReference;

    [SerializeField] private float energyRegeneration = 25f;

    private void Start()
    {
        if (INSTANCE != null)
        {
            Destroy(gameObject);
        }
        else
        {
            INSTANCE = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Drink()
    {
        EnergyRessourceReference.Add(energyRegeneration);
        BeerRessourceReference.Remove(1);
    }
}
