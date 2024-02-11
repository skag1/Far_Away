using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Mechanism
{
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private SpriteRenderer spriteRenderer;

    public override void Activate()
    {
        boxCollider.enabled = false;
        spriteRenderer.enabled = false;
        isActivated = true;
    }

    public override void Deactivate()
    {
        boxCollider.enabled = true;
        spriteRenderer.enabled = true;
        isActivated = false;
    }
}
