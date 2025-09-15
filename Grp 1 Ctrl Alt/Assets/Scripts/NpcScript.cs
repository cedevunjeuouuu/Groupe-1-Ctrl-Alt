using System.Collections;
using DG.Tweening;
using UnityEngine;

public class NpcScript : MonoBehaviour
{
    [SerializeField] private float penality = 10f;
    [SerializeField] private GameObject textBubble;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindFirstObjectByType<SusRessource>().Add(penality);
            textBubble.SetActive(true);
            StartCoroutine(WaitForEndInteraction()); // temporaire
        }
    }

    IEnumerator WaitForEndInteraction() // temporaire a remplacer par un input
    {
        yield return new WaitForSeconds(3f);
        StopInteraction();
    }

    void StopInteraction()
    {
        textBubble.SetActive(false);
    }
}
