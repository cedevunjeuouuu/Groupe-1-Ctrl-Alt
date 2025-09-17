using UnityEngine;
using DG.Tweening;
using System;

public class CarMover : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;

    [SerializeReference]
    private Transform sprite;

    private Transform player;

    [SerializeField]
    private float offset = 0f;

    public void Awake()
    {
        player = FindFirstObjectByType<Player>().transform;
    }

    public void Update()
    {
        var pos = sprite.position;

        sprite.position = new Vector3(pos.x, pos.y, speed * transform.position.z + offset);
    }
}
