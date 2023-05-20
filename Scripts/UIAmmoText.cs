using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIAmmoText : MonoBehaviour
{
    private TextMeshProUGUI tmProText;
    private WeaponAmmo currentWeaponAmmo;

    private void Awake()
    {
        tmProText = GetComponent<TMPro.TextMeshProUGUI>();
        Inventory.OnWeaponChanged += Inventory_OnWeaponChanged;
    }

    private void Inventory_OnWeaponChanged(Weapon weapon)
    {
        if(currentWeaponAmmo != null)
        {
            currentWeaponAmmo.OnAmmoChanged -= CurrentWeaponAmmo_OnAmmoChanged;
        }

        currentWeaponAmmo = weapon.GetComponent<WeaponAmmo>();
        if (currentWeaponAmmo != null)
        {
            currentWeaponAmmo.OnAmmoChanged += CurrentWeaponAmmo_OnAmmoChanged;
            tmProText.text = currentWeaponAmmo.GetAmmoText();
        } else {
            tmProText.text = "Unlimited";
        }
    }

    private void CurrentWeaponAmmo_OnAmmoChanged()
    {
        tmProText.text = currentWeaponAmmo.GetAmmoText();
    }
}
