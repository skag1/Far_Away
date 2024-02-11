using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : ActivatingMechanism
{
    [SerializeField] SpriteRenderer spriteRenderer;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            mechanism.Activate();
            spriteRenderer.color = Color.red;
        }
    }
}
