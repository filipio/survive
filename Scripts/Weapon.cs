using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private KeyCode weaponHotkey;

    public KeyCode WeaponHotkey {  get { return weaponHotkey; } }

    [SerializeField]
    private float fireDelay = 0.25f;

    private float fireTimer;
    private WeaponAmmo ammo;

    public event Action OnFire = delegate { };

    private void Awake()
    {
        ammo = GetComponent<WeaponAmmo>();
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;
        if(Input.GetButton("Fire1"))
        {
            if (CanFire())
            {
                Fire();
            }
        }
    }

    private void Fire()
    {
        fireTimer = 0;
        print("fire!!!");
        OnFire();
    }

    private bool CanFire()
    {
        if(ammo != null && ammo.IsAmmoReady() == false)
        {
            return false;
        }
        return fireTimer >= fireDelay;
    }
}
