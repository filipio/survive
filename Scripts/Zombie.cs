using System;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Zombie : Spawnable
{
    public static Action<int> OnZombieDead = delegate { };
    private static int currentDeadZombies = 0;

    void Start()
    {
        GetComponent<Health>().OnDied += Zombie_OnDied;
    }

    private void Zombie_OnDied()
    {
        currentDeadZombies += 1;
        OnZombieDead(currentDeadZombies);
    }
}
