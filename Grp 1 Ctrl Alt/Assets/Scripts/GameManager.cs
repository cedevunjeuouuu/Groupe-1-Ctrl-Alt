using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager INSTANCE;
    public BeerRessource BeerRessourceReference;
    public EnergyRessource EnergyRessourceReference;
    public PPRessource PPRessourceReference;
    public SusRessource SusRessourceReference;
    public CameraShake camera;
    public bool canPee;

    [SerializeField] private float maxSpeed = 1.5f;
    [SerializeField] private float timeAcceleration = 0.05f;
    [SerializeField] private GameObject textCivil;
    [SerializeField] private GameObject textFou;
    [SerializeField] private Image imageFade;
    [SerializeField] private float energyRegeneration = 25f;
    [SerializeField] private float ppAdd = 25f;
    [SerializeField] private float ppPenalty = 25f;
    [SerializeField] private GameObject canvas;
    [SerializeField] private TMP_Text text;
    [SerializeField] private TMP_Text textDistance;
    [SerializeField] private TMP_Text textBeer;
    [SerializeField] private float timeToMenu = 5f;
    [SerializeField] private Light lightPolice;

    private int _allBeersConsumed = 1;
    private int _score;
    private bool lightState;
    private void Start()
    {
        if (INSTANCE != null)
        {
            Destroy(gameObject);
        }
        else
        {
            INSTANCE = this;
        }

        StartCoroutine(Score());
    }

    public GameObject GetCivil()
    {
        return textCivil;
    }
    public GameObject GetFou()
    {
        return textFou;
    }

    public void PPPenalty()
    {
        SusRessourceReference.Add(ppPenalty);
    }

    public void OnDrink(InputValue inputValue)
    {
        Drink();
    }
    void Drink()
    {
        if (BeerRessourceReference._actualBeer > 0)
        {
            _allBeersConsumed += 1;
            EnergyRessourceReference.Add(energyRegeneration);
            BeerRessourceReference.Remove(1);
            PPRessourceReference.Add(ppAdd);
        }
    }

    

    public void Loose(bool isPolice)
    {
        StopCoroutine(Score());
        camera.canShake = false;
        if (isPolice)
        {
            lightPolice.gameObject.SetActive(true);
            lightPolice.color = Color.blue;
            StartCoroutine(Police());
        }
        else
        {
            imageFade.DOFade(1f, 1f).SetUpdate(true); ;
        }
        canvas.SetActive(true);
        int actualScore = _allBeersConsumed * _score;
        text.text = "Score : " + actualScore;
        textBeer.text = _allBeersConsumed.ToString();
        textDistance.text = _score.ToString();
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
                else
                {
                    PlayerPrefs.SetInt("highScore3", PlayerPrefs.GetInt("highScore2"));
                    PlayerPrefs.SetInt("highScore2", actualScore);
                }
            }
            else
            {
                PlayerPrefs.SetInt("highScore3", actualScore);
            }
        }

        Time.timeScale = 0;
        StartCoroutine(WaitToMenu());
    }
    IEnumerator WaitToMenu()
    {
        yield return new WaitForSecondsRealtime(timeToMenu);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        StopCoroutine(Police());
    }
    IEnumerator Police()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(0.5f);
            if (lightState)
            {
                lightPolice.color = Color.blue;
                lightState = !lightState;
            }
            else
            {
                lightPolice.color = Color.red;
                lightState = !lightState;
            }
        }
    }
    IEnumerator Score()
    {
        int cpt = 0;
        while (true)
        {
            cpt++;
            _score += 1;
            if (cpt > 10 && Time.timeScale < maxSpeed)
            {
                cpt = 0;
                Time.timeScale += timeAcceleration;
            }
            yield return new WaitForSecondsRealtime(1f);
        }
    }
}
