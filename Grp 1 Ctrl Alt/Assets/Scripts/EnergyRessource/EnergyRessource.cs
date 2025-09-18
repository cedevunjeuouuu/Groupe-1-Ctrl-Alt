using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class EnergyRessource : MonoBehaviour
{
    [SerializeField] private float startEnergy = 100f;
    [SerializeField] private float looseSpeed = 1f;
    [SerializeField] private Slider sliderRef;
    private float _actualEnergyValue;

    [SerializeField]
    private bool autodefill = false;

    private void Start()
    {
        _actualEnergyValue = startEnergy;
        if (autodefill) StartCoroutine(LooseUpdate());
    }

    public void Add(float value) // quand on boit une biere
    {
        _actualEnergyValue += value;
        _actualEnergyValue = MathF.Min(sliderRef.maxValue, _actualEnergyValue);
        sliderRef.value = _actualEnergyValue;

    }

    public void Remove(float value)
    {
        _actualEnergyValue -= value;
        _actualEnergyValue = MathF.Max(sliderRef.minValue, _actualEnergyValue);
        sliderRef.value = _actualEnergyValue;
    }

    IEnumerator LooseUpdate()
    {
        while (true)
        {
            Remove(1f);
            if (_actualEnergyValue <= 0f)
            {
                GameManager.INSTANCE.Loose(false);
            }
            yield return new WaitForSecondsRealtime(1f / looseSpeed);
        }
    }
}
