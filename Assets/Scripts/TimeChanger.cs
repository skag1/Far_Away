using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeChanger : MonoBehaviour
{
    [SerializeField] private GameObject past;
    [SerializeField] private GameObject present;
    [SerializeField] private TMP_Text tmpEC;
    [SerializeField] private int energyPoints;
    private int isPresent = 1;

    private void Awake()
    {
        past.SetActive(false);
        present.SetActive(true);
    }

    private void Update()
    {
        tmpEC.text = "Energy Crystalls: " + energyPoints.ToString();

        if (Input.GetKeyDown(KeyCode.T) && energyPoints > 0)
        {
            isPresent *= -1;
            energyPoints--;
        }

        if(isPresent == 1)
        {
            past.SetActive(false);
            present.SetActive(true);
        }
        else
        {
            past.SetActive(true);
            present.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnergyCrystall"))
        {
            energyPoints++;
            Destroy(other.gameObject, 0.1f);
        }
    }
}
