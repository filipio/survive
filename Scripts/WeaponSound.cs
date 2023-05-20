using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
[RequireComponent(typeof(AudioSource))]
public class WeaponSound : WeaponComponent
{
    [SerializeField]
    private SimpleAudioEvent audioEvent;

    private AudioSource audioSource;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    protected override void OnWeaponFire()
    {
        audioEvent.Play(audioSource);
    }
}
