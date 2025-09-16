using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomHouse : MonoBehaviour
{
    [SerializeField] private GameObject[] allRoofs;
    [SerializeField] private GameObject[] allFloors;
    [SerializeField] private GameObject[] allGroundFloor;
    [SerializeField] private float floorHeight;
    [SerializeField] private int minFloorNumber = 0;
    [SerializeField] private int maxFloorNumber = 2;

    private void Start()
    {
        CreateHouse();
    }

    void CreateHouse()
    {
        if (allGroundFloor.Length != 0 && allFloors.Length != 0 && allRoofs.Length != 0)
        {
            float actualHeight = floorHeight;
            Instantiate(allGroundFloor[Random.Range(0, allGroundFloor.Length)], transform);
            int randomNb = Random.Range(minFloorNumber, maxFloorNumber + 1);
            for (int i = 0; i < randomNb; i++)
            {
                GameObject actualFloor = Instantiate(allFloors[Random.Range(0, allFloors.Length)], transform);
                actualFloor.transform.position = new Vector3(actualFloor.transform.position.x , actualFloor.transform.position.y 
                    + actualHeight, actualFloor.transform.position.z);
                actualHeight += floorHeight;
            }
            GameObject roof = Instantiate(allRoofs[Random.Range(0, allRoofs.Length)], transform);
            roof.transform.position = new Vector3(roof.transform.position.x , roof.transform.position.y + actualHeight, roof.transform.position.z);
        }
    }
}
