using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHurtState : State
{
    public ZombieAttackingState attackingState;

    public float timer;

    public override State RunCurrentState()
    {
        timer -= Time.deltaTime;

        if (timer <= 0) { return attackingState; }

        return this;
    }

    public override string GetStateName()
    {
        return "zombie_idle";
    }
}
