using System.Collections;
using DG.Tweening;
using UnityEngine;

public class NpcScript : MonoBehaviour
{
    [SerializeField] private float penality = 10f;
    [SerializeField] private float energyPenality = 10f;
    [SerializeField] private bool isCivil;
    private GameObject textBubble;

    void Awake()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        if (isCivil)
        {
            textBubble = GameManager.INSTANCE.GetCivil();
        }
        else
        {
            textBubble = GameManager.INSTANCE.GetFou();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.INSTANCE.camera.Shake();
            FindFirstObjectByType<SusRessource>().Add(penality);
            textBubble.SetActive(true);
            StartCoroutine(WaitForEndInteraction());
        }
    }

    IEnumerator WaitForEndInteraction()
    {
        yield return new WaitForSecondsRealtime(3f);
        textBubble.SetActive(false);
    }

}
