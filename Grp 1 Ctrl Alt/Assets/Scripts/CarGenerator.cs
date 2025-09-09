using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class CarGenerator : MonoBehaviour
{
    [SerializeField] private int spawnProbability = 50;
    [SerializeField] private float spawnSpeed = 1;

    private void Start()
    {
        spawnProbability = Mathf.Clamp(spawnProbability,0, 100);
        StartCoroutine(SpawnCoroutine());
    }

    IEnumerator SpawnCoroutine()
    {
        if (Random.Range(0, 100 - spawnProbability) == 1)
        {
            // spawn une voiture qui se deplace vers le joueur à la position du spawner
        }
        yield return new WaitForSeconds(1f / spawnSpeed);
    }
    
}
