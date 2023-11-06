using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHurtState : State
{
    public ZombieAttackingState attackingState;
    public ZombieDeathState deathState;

    public float timer = 1;

    public override State RunCurrentState()
    {
        timer -= Time.deltaTime;

        if (timer <= 0) { timer = 1; return attackingState; }

        if (this.gameObject.GetComponentInParent<HostileTroopManager>().currentHealth <= 0) 
        { return deathState; }

        return this;
    }

    public override string GetStateName()
    {
        return "zombie_hurt";
    }
}
