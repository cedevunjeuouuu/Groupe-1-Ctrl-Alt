using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class WorldGeneration : MonoBehaviour
{
    [SerializeField] private GameObject[] easyLevels;
    [SerializeField] private GameObject[] mediumLevels;
    [SerializeField] private GameObject[] hardLevels;
    [SerializeField] private int numberOfMediumLevels = 10;
    [SerializeField] private float levelLenght;

    private void Start()
    {
        StartCoroutine(SpawnLevel());
    }

    IEnumerator SpawnLevel()
    {
        for (int i = 0; i < easyLevels.Length; i++)
        {
            Instantiate(easyLevels[i], transform);
            yield return new WaitForSeconds(levelLenght);
        }
        for (int i = 0; i < numberOfMediumLevels; i++)
        {
            Instantiate(mediumLevels[Random.Range(0,mediumLevels.Length)], transform);
            yield return new WaitForSeconds(levelLenght);
        }

        while (true)
        {
            Instantiate(hardLevels[Random.Range(0,hardLevels.Length)], transform);
            yield return new WaitForSeconds(levelLenght);
        }
        
    }
}
