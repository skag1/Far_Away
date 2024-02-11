using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillManager : MonoBehaviour
{
    [SerializeField] private TimeChanger timeChanger;

    private void Start()
    {
        timeChanger.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("TimeChanger"))
        {
            timeChanger.enabled = true;
            Debug.Log("What... What is this?");
            Destroy(other.gameObject, 0.1f);
        }
    }
}
