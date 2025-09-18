using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public float duration = 0.5f;
    public float strength = 0.5f;

    private Vector3 initialLocalPos;
    private Coroutine shakeCoroutine;

    void Start()
    {
        initialLocalPos = transform.localPosition;
    }
    public void Shake()
    {
        if (shakeCoroutine != null)
            StopCoroutine(shakeCoroutine);

        shakeCoroutine = StartCoroutine(DoShake());
    }

    private IEnumerator DoShake()
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float damper = 1f - (elapsed / duration);
            Vector2 randomPoint = Random.insideUnitCircle * strength * damper;
            transform.localPosition = initialLocalPos + new Vector3(randomPoint.x, randomPoint.y, 0f);
            yield return null;
        }

        transform.localPosition = initialLocalPos;
        shakeCoroutine = null;
    }
}
