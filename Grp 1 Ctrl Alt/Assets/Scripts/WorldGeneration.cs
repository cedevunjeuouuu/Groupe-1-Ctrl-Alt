using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class WorldGeneration : MonoBehaviour
{
    
    [SerializeField] private GameObject[] levels;
    [SerializeField] private float levelLenght;

    private void Start()
    {
        StartCoroutine(SpawnLevel());
    }

    IEnumerator SpawnLevel()
    {
        int tabLenght = levels.Length;
        while (true)
        {
            Instantiate(levels[Random.Range(0,tabLenght)], transform);
            yield return new WaitForSeconds(levelLenght);
        }
        
    }
}
