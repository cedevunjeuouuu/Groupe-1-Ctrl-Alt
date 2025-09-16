using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager INSTANCE;
    public BeerRessource BeerRessourceReference;
    public EnergyRessource EnergyRessourceReference;

    [SerializeField] private float energyRegeneration = 25f;

    private int _allBeersConsumed;
    private int _score;
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
        print("glouglouglou");
    }

    void Loose()
    {
        int actualScore = _allBeersConsumed * _score;
        if (PlayerPrefs.GetInt("highScore3") < actualScore)
        {
            if (PlayerPrefs.GetInt("highScore2") < actualScore)
            {
                if (PlayerPrefs.GetInt("highScore1") < actualScore)
                {
                    PlayerPrefs.SetInt("highScore3", PlayerPrefs.GetInt("highScore2"));
                    PlayerPrefs.SetInt("highScore2", PlayerPrefs.GetInt("highScore1"));
                    PlayerPrefs.SetInt("highScore1", actualScore);
                }
                PlayerPrefs.SetInt("highScore3", PlayerPrefs.GetInt("highScore2"));
                PlayerPrefs.SetInt("highScore2", actualScore);
            }
            PlayerPrefs.SetInt("highScore3", actualScore);
            
        }
    }
}
