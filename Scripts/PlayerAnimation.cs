using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    [SerializeField]
    private float drawWeaponSpeed;

    private void Awake()
    {
        GetComponent<Health>().OnDied += PlayerAnimation_OnDied;
    }

    private void PlayerAnimation_OnDied()
    {
        animator.SetTrigger("Death");
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1")) {
            StartCoroutine(FadeToShootingLayer());
        }

        if (Input.GetButtonUp("Fire1"))
        {
            StartCoroutine(FadeFromShootingLayer());
        }
    }

    private IEnumerator FadeFromShootingLayer()
    {
        float currentWeight = animator.GetLayerWeight(1);
        float elapsed = 0;

        while (elapsed < drawWeaponSpeed)
        {
            elapsed += Time.deltaTime;
            currentWeight -= Time.deltaTime / drawWeaponSpeed;
            animator.SetLayerWeight(1, currentWeight);
            yield return null;
        }

        animator.SetLayerWeight(1, 0);
    }

    private IEnumerator FadeToShootingLayer()
    {
        float currentWeight = animator.GetLayerWeight(1);
        float elapsed = 0;

        while(elapsed < drawWeaponSpeed)
        {
            elapsed += Time.deltaTime;
            currentWeight += Time.deltaTime / drawWeaponSpeed;
            animator.SetLayerWeight(1, currentWeight);
            yield return null;
        }

        animator.SetLayerWeight(1, 1);
    }
}
