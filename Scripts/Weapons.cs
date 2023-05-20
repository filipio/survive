using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField]
    private Transform firstPersonWeaponPoint;
    [SerializeField]
    private Transform thirdPersonWeaponPoint;

    public bool isFpsMode;

    private void Update()
    {
        if(isFpsMode)
        {
            transform.position = firstPersonWeaponPoint.position;
            transform.rotation = firstPersonWeaponPoint.rotation;
        } else
        {
            transform.position = thirdPersonWeaponPoint.position;
            transform.rotation = thirdPersonWeaponPoint.rotation;
        }
    }
}
