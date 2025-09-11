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

    private void Start()
    {
        _actualEnergyValue = startEnergy;
        StartCoroutine(LooseUpdate());
    }

    public void Add(float value) // quand on boit une biere
    {
        _actualEnergyValue += value;
    }

    public void Remove(float value)
    {
        _actualEnergyValue -= value;
    }

    IEnumerator LooseUpdate()
    {
        while (true)
        {
            Remove(1f);
            sliderRef.DOValue(_actualEnergyValue, 1f / looseSpeed).SetEase(Ease.Linear);
            yield return new WaitForSeconds(1f / looseSpeed);
        }
    }
}
