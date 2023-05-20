using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private Weapon[] weapons;

    public static event Action<Weapon> OnWeaponChanged = delegate { };


    private void Start()
    {
        SwitchToWeapon(weapons[0]);
        OnWeaponChanged(weapons[0]);
    }

    // Update is called once per frame
    void Update()
    { 
        foreach(var weapon in weapons)
        {
            if(Input.GetKeyDown(weapon.WeaponHotkey))
            {
                
                SwitchToWeapon(weapon);
                OnWeaponChanged(weapon);
                break;
            }
        }
    }

    private void SwitchToWeapon(Weapon weaponToSwitchTo)
    {
        foreach(var weapon in weapons)
        {
            weapon.gameObject.SetActive(weapon == weaponToSwitchTo);
        }
    }
}
