using UnityEngine;


public class ControllerManager : MonoBehaviour
{
    public Transform target = null!;

    public IPlayerController controller;

    public void Start()
    {
        controller = GetComponent<IPlayerController>();
    }


    public void Update()
    {
        target.position = new Vector3(controller.position * 100f, target.position.y, target.position.z);
    }
}
