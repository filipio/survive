using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsToggle : MonoBehaviour
{
    [SerializeField]
    private GameObject[] firstPersonObjects;
    [SerializeField]
    private GameObject[] thirdPersonObjects;
    [SerializeField]
    private KeyCode toggleKey = KeyCode.F1;
    private bool isFpsMode;
    private Weapons weapons;

    private void Awake()
    {
        weapons = FindObjectOfType<Weapons>();
    }

    private void OnEnable()
    {
        ToggleObjectsForCurrentMode();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(toggleKey))
        {
            Toggle();
        }
    }

    private void Toggle()
    {
        isFpsMode = !isFpsMode;
        weapons.isFpsMode = isFpsMode;
        ToggleObjectsForCurrentMode();
    }

    private void ToggleObjectsForCurrentMode()
    {
        foreach (var gameObject in firstPersonObjects)
        {
            gameObject.SetActive(isFpsMode);
        }

        foreach (var gameObject in thirdPersonObjects)
        {
            gameObject.SetActive(!isFpsMode);
        }
    }
}
