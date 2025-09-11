using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SusRessource : MonoBehaviour
{
    [SerializeField] private float startSus = 0f;
    [SerializeField] private float looseSpeed = 1f;
    [SerializeField] private Slider sliderRef;
    private float _actualEnergyValue;

    [SerializeField]
    private bool autodefill = false;

    private void Start()
    {
        _actualEnergyValue = startSus;
        sliderRef.value = _actualEnergyValue;

        if (autodefill) StartCoroutine(LooseUpdate());
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

    IEnumerator LooseUpdate()
    {
        while (true)
        {
            Remove(1f);
            yield return new WaitForSeconds(1f / looseSpeed);
        }
    }
}
