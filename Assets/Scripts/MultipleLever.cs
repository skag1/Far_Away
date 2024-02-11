using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleLever : ActivatingMechanism
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Mechanism[] mechanisms;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            spriteRenderer.color = Color.red;
            for (int i = 0; i < mechanisms.Length; i++)
            {
                mechanisms[i].Activate();
            }
        }
    }
}
