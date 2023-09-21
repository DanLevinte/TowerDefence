using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttackingState : State
{
    public ZombieMovingState movingState;

    public MobManager mobManager;

    public override State RunCurrentState()
    {
        //if (mobManager.target == null) { return this.movingState; }

        return this;
    }

    public override string GetStateName()
    {
        return "zombie_attack";
    }
}
