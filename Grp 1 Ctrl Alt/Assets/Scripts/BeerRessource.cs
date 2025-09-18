using System;
using TMPro;
using UnityEngine;

public class BeerRessource : MonoBehaviour
{
    [SerializeField] private int startBeer = 2;
    [SerializeField] private TMP_Text textNumberOfBeer; 
    [HideInInspector] public int _actualBeer;
    private void Start()
    {
        _actualBeer = startBeer;
        UpdateUi();
    }
    public void Add(int value) 
    {
        _actualBeer += value;
        UpdateUi();
    }

    public void Remove(int value)
    {
        _actualBeer -= value;
        UpdateUi();
        
    }

    void UpdateUi()
    {
        textNumberOfBeer.text = "" + _actualBeer;
    }
}
