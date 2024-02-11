using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : Mechanism
{
    [SerializeField] private Transform destination;
    [SerializeField] private SpriteRenderer spriteRenderer;

    public override void Activate()
    {
        isActivated = true;
        spriteRenderer.color = Color.blue;
    }

    public override void Deactivate()
    {
        isActivated = false;
    }

    public Transform GetDestination()
    {
        if (isActivated)
        {
            return destination;
        }
        else return null;
    }
}
