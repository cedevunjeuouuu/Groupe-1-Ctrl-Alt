using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

public class BeerBottle : MonoBehaviour
{
    [SerializeField] private float animspeed = 2f;
    [SerializeField] private float animForce = 10f;
    private bool isUp;
    private void Start()
    {
        StartCoroutine(Anim());
    }

    IEnumerator Anim()
    {
        while (true)
        {
            if (isUp)
            {
                transform.DOMoveY(transform.position.y - animForce, 1f / animspeed);
            }
            else
            {
                transform.DOMoveY(transform.position.y + animForce, 1f / animspeed);
            }
            isUp = !isUp;
            yield return new WaitForSeconds(1f / animspeed);
            
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.INSTANCE.BeerRessourceReference.Add(1);
            Destroy(gameObject);
        }
    }
  
}
