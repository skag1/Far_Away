using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPlate : ActivatingMechanism
{
    private float origX;
    private float origY;
    private ArrayList list;

    private void Awake()
    {
        origX = transform.localPosition.x;
        origY = transform.localPosition.y;
        list = new ArrayList();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("MoveableBox")) && transform.localPosition.y > origY - 0.05f)
        {
            list.Add(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("MoveableBox")) && transform.localPosition.y > origY - 0.05f)
        {
            transform.Translate(Vector2.down * Time.deltaTime);
            mechanism.Activate();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        list.Remove(collision.gameObject);
        if ((collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("MoveableBox")) && list.Count == 0)
        {
            transform.localPosition = new Vector2(origX, origY);
            mechanism.Deactivate();
        }
    }
}
