using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnergyRessource : MonoBehaviour
{
    [SerializeField] private float startEnergy = 100f;
    [SerializeField] private float looseSpeed = 1f;
    [SerializeField] private Slider sliderRef;
    private float _actualEnergyValue;

    private void Start()
    {
        _actualEnergyValue = startEnergy;
        StartCoroutine(LooseUpdate());
    }

    public void Add(float value) // quand on boit une biere
    {
        _actualEnergyValue += value;
        sliderRef.value = _actualEnergyValue;
    }

    public void Remove(float value)
    {
        _actualEnergyValue -= value;
        sliderRef.value = _actualEnergyValue;
    }

    IEnumerator LooseUpdate()
    {
        while (true)
        {
            Remove(1f);
            yield return new WaitForSeconds(1f / looseSpeed);
        }
    }
}
