using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    [SerializeField]
    private float delayBetweenAttacks = 1.5f;
    [SerializeField]
    private float maximumAttackRange = 1.5f;
    [SerializeField]
    private float delayBetweenAnimationAndDamage = 0.25f;

    private int damage = 1;
    private Health playerHealth;
    private Health health;
    private float attackTimer;
    private bool isZombieAlive = true;

    public event Action OnAttack = delegate { };

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerMovement>().GetComponent<Health>();
        GetComponent<Health>().OnDied += ZombieAttack_OnDied;
    }

    private void ZombieAttack_OnDied()
    {
        isZombieAlive = false;
    }

    private void Update()
    {
        attackTimer += Time.deltaTime;
        if(CanAttack())
        {
            attackTimer = 0;
            Attack();
        } 
    }

    private bool CanAttack()
    {
        return isZombieAlive && 
            attackTimer >= delayBetweenAttacks &&
        Vector3.Distance(transform.position, playerHealth.transform.position) <= maximumAttackRange;
    }

    private void Attack()
    {
        OnAttack();
        StartCoroutine(DelayDamageAfterDelay());
        
    }

    private IEnumerator DelayDamageAfterDelay()
    {
        yield return new WaitForSeconds(delayBetweenAnimationAndDamage);
        playerHealth.TakeHit(damage);
    }
}
