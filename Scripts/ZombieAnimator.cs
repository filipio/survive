using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimator : MonoBehaviour
{
    [SerializeField]
    private float movingSpeedFactor = 1f;
    [SerializeField]
    private float attackSpeedFactor = 1f;

    private Animator animator;
    private float minRandomRange = -0.1f;
    private float maxRandomRange = 0.1f;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        GetComponent<Health>().OnTookHit += ZombieAnimator_OnTookHit;
        GetComponent<Health>().OnDied += ZombieAnimator_OnDied;
        GetComponent<ZombieAttack>().OnAttack += ZombieAnimator_OnAttack;
    }

    private void OnEnable()
    {
        print(string.Format("Setting moving factor to {0}", movingSpeedFactor));
        float randomNoise = Random.Range(minRandomRange, maxRandomRange);
        animator.SetFloat("MovementSpeed", movingSpeedFactor + randomNoise);
        animator.SetFloat("AttackSpeed", attackSpeedFactor + randomNoise);
    }

    private void ZombieAnimator_OnAttack()
    {
        animator.SetInteger("AttackId", UnityEngine.Random.Range(1, 3));
        animator.SetTrigger("Attack");
    }

    private void ZombieAnimator_OnDied()
    {
        animator.SetTrigger("Die");
    }

    private void ZombieAnimator_OnTookHit()
    {
        animator.SetTrigger("Hit");
    }
}
