
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SusRessource : MonoBehaviour
{
    [SerializeField] private float startSus = 0f;
    [SerializeField] private Slider sliderRef;
    private float _actualEnergyValue;

    private void Start()
    {
        _actualEnergyValue = startEnergy;
        sliderRef.value = _actualEnergyValue;
    }

    public void Add(float value) // quand on boit une biere
    {
        _actualEnergyValue += value;
        sliderRef.value = _actualEnergyValue;

        if (_actualEnergyValue > 100f)
        {
            // do stuff
        }
    }

    public void Remove(float value)
    {
        _actualEnergyValue -= value;
        _actualEnergyValue = Mathf.Max(_actualEnergyValue, 0f);
        sliderRef.value = _actualEnergyValue;
    }
}
