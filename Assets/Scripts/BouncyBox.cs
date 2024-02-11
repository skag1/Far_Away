using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBox : MonoBehaviour
{
    [SerializeField] private float bouncePower;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.transform.position.y - 0.5f > transform.position.y)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bouncePower, ForceMode2D.Impulse);
        }
    }
}
