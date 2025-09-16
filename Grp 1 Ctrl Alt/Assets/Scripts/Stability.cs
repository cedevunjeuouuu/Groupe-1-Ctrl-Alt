using UnityEngine;
using System;

public class Stability : MonoBehaviour
{
    [SerializeReference]
    private PlayerController player;

    [SerializeField]
    private Quaternion UnstableRotationPositive;
    [SerializeField]
    private Quaternion UnstableRotationNegative;

    private Quaternion BaseRotation;

    [SerializeReference]
    private Transform sprite;

    public float unstability;

    public void Awake()
    {
        player ??= GetComponent<PlayerController>();

        BaseRotation = player.transform.localRotation;

    }

    public void Update()
    {
        unstability = MathF.Abs(player.velocity / player.velocity_cap);

        var rotation = player.velocity > 0 ? UnstableRotationPositive : UnstableRotationNegative;

        sprite.localRotation = Quaternion.Lerp(BaseRotation, rotation, unstability);

        if (unstability >= 0.99)
        {
            //loose the game
        }
    }
}
