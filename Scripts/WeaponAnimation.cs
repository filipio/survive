using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
[RequireComponent(typeof(Animator))]
public class WeaponAnimation : WeaponComponent
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    protected override void OnWeaponFire()
    {
        animator.SetTrigger("fire");
    }
}
