using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponProjectileLauncher : WeaponComponent
{
    [SerializeField]
    private Projectile projectilePrefab;
    [SerializeField]
    private float moveSpeed = 40;
    [SerializeField]
    private float maxDistance;
    [SerializeField]
    private int layerMask;

    private RaycastHit hitInfo;

    protected override void OnWeaponFire()
    {
        Vector3 direction = GetDirection();
        var projectile = projectilePrefab.Get<Projectile>(transform.position, Quaternion.Euler(direction));
        projectile.GetComponent<Rigidbody>().velocity = direction * moveSpeed;
    }

    private Vector3 GetDirection()
    {
        var ray = Camera.main.ViewportPointToRay(Vector3.one / 2f);
        Vector3 target = ray.GetPoint(300);

        if(Physics.Raycast(ray, out hitInfo, maxDistance, layerMask))
        {
            target = hitInfo.point;
        }

        Vector3 direction = target - transform.position;
        direction.Normalize();

        return direction;
    }
}
