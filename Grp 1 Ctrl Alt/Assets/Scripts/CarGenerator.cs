using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class CarGenerator : MonoBehaviour
{
    [SerializeField] private int spawnProbability = 50;
    [SerializeField] private float spawnSpeed = 1;
    [SerializeField] private GameObject[] allCars;

    private void Start()
    {
        spawnProbability = Mathf.Clamp(spawnProbability,0, 100);
        StartCoroutine(SpawnCoroutine());
    }

    IEnumerator SpawnCoroutine()
    {
        if (Random.Range(0, 100 - spawnProbability) == 1)
        {
            if (allCars.Length != 0)
            {
                Instantiate(allCars[Random.Range(0, allCars.Length)], transform);
            }
        }
        yield return new WaitForSeconds(1f / spawnSpeed);
    }
}
