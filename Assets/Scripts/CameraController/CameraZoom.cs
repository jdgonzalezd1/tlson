using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera vCam;

    [SerializeField]
    private float sensitivity = 1f;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float maxZoom;

    [SerializeField]
    private float minZoom;

    private float targetZoom;

    private void Start()
    {
        targetZoom = vCam.m_Lens.OrthographicSize;
    }

    private void FixedUpdate()
    {
        targetZoom -= InputManager.Instance.GetMouseScrollY().y * sensitivity;
        targetZoom = Mathf.Clamp(targetZoom, maxZoom, minZoom);
        float newSize = Mathf.MoveTowards(vCam.m_Lens.OrthographicSize, targetZoom, speed);
        vCam.m_Lens.OrthographicSize = newSize;
    }

}
