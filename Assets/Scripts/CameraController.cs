using System;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static Action<float, float, float> cameraShake;
    public static Action<float> changeCameraSizeEvent;
    public static Action<Transform> changeFollowTargetEvent;

    [HideInInspector] public CinemachineFramingTransposer transposer;
    private CinemachineBasicMultiChannelPerlin channelPerlin;

    private CinemachineVirtualCamera cam;
    private float camSize;

    private void OnEnable()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
        transposer = cam.GetCinemachineComponent<CinemachineFramingTransposer>();
        channelPerlin = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cameraShake += shake;
        changeCameraSizeEvent += changeCameraSize;
        changeFollowTargetEvent += changeFollowTarget;
    }

    private void OnDisable()
    {
        cameraShake -= shake;
        changeCameraSizeEvent -= changeCameraSize;
        changeFollowTargetEvent -= changeFollowTarget;
    }

    void shake(float strength, float time, float fadeTime)
    {
        StartCoroutine(shakeCam(strength, time, fadeTime));
    }
    
    void changeCameraSize(float newSize)
    {
        StopCoroutine(changeSize(newSize));
        camSize = cam.m_Lens.OrthographicSize;
        StartCoroutine(changeSize(newSize));
    }

    void changeFollowTarget(Transform followObject)
    {
        if (followObject != null) cam.m_Follow = followObject;
    }

    private IEnumerator changeSize(float newSize)
    {
        if (cam.m_Lens.OrthographicSize == newSize) yield break;

        for(float i = 0; i < 1f; i += Time.deltaTime)
        {
            cam.m_Lens.OrthographicSize = Mathf.Lerp(camSize, newSize, EaseInOut(i));
            yield return null;
        }
    }

    private IEnumerator shakeCam(float strength, float time, float fadeTime)
    {
        channelPerlin.m_AmplitudeGain = strength;

        yield return new WaitForSeconds(time);

        //затухание
        for (float i = 0; i < fadeTime; i += Time.deltaTime)
        {
            channelPerlin.m_AmplitudeGain-= Time.deltaTime * strength / fadeTime;
            yield return null;
        }
        channelPerlin.m_AmplitudeGain = 0;
    }

    //функция сглаживания
    float EaseInOut(float x)
    {
        return x < 0.5 ? x * x * 2 : (1 - (1 - x) * (1 - x) * 2);
    }
}