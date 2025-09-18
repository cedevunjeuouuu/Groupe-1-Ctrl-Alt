using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PPRessource : MonoBehaviour
{
    [SerializeField] private float startEnergy = 0f;
    [SerializeField] private float looseSpeed = 1f;
    [SerializeField] private Slider sliderRef;
    [SerializeField] private GameObject ppParticle;
    private float _actualPPValue;

    [SerializeField]
    private bool autodefill = false;

    private void Start()
    {
        _actualPPValue = startEnergy;
        if (autodefill) StartCoroutine(GainUpdate());
    }

    public void Add(float value)
    {
        _actualPPValue += value;
        _actualPPValue = MathF.Min(sliderRef.maxValue, _actualPPValue);
        sliderRef.value = _actualPPValue;

    }

    public void Remove(float value)
    {
        _actualPPValue -= value;
        _actualPPValue = MathF.Max(sliderRef.minValue, _actualPPValue);
        sliderRef.value = _actualPPValue;
    }

    IEnumerator GainUpdate()
    {
        while (true)
        {
            Add(1f);
            if (_actualPPValue >= 100f)
            {
                if (!GameManager.INSTANCE.canPee)
                {
                    GameManager.INSTANCE.PPPenalty();
                }
                ppParticle.SetActive(true);
                DOTween.To(() => _actualPPValue, x => {_actualPPValue = x; sliderRef.value = x; }, 0f, 1f).SetEase(Ease.Linear)
                    .OnComplete(() => StartCoroutine(PP()));
            }
            yield return new WaitForSecondsRealtime(1f / looseSpeed);
            
        }
    }

    IEnumerator PP()
    {
        yield return new WaitForSecondsRealtime(3f);
        ppParticle.SetActive(false);
    }
}
