using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSizeManipulator : MonoBehaviour
{
    [SerializeField] private float leftCameraSize;
    [SerializeField] private float rightCameraSize;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(other.transform.position.x > transform.position.x)
            {
                CameraController.changeCameraSizeEvent?.Invoke(rightCameraSize);
            }
            else
            {
                CameraController.changeCameraSizeEvent?.Invoke(leftCameraSize);
            }
        }
    }
}
