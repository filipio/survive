using Cinemachine;
using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera vcam;
    [SerializeField]
    CinemachineFreeLook freeLookCamera;
    [SerializeField]
    private float mouseSensitivity = 1f;

    private CinemachineComposer composer;

    private void Awake()
    {
        composer = vcam.GetCinemachineComponent<CinemachineComposer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            freeLookCamera.Priority = 100;
            freeLookCamera.m_RecenterToTargetHeading.m_enabled = false;
        } else if (Input.GetMouseButtonUp(1))
        {
            freeLookCamera.Priority = 0;
            freeLookCamera.m_RecenterToTargetHeading.m_enabled = true;
        }


        if(Input.GetMouseButton(1) == false)
        {
            var vertical = Input.GetAxis("Mouse Y") * mouseSensitivity;
            composer.m_TrackedObjectOffset.y += vertical;
            composer.m_TrackedObjectOffset.y = Math.Clamp(composer.m_TrackedObjectOffset.y, -10f, 10f);
        }
    }
}
