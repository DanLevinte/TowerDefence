using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieIdleState : State
{
    public ZombieMovingState movingState;

    public override State RunCurrentState()
    {
        return this.movingState;
    }

    public override string GetStateName()
    {
        return "zombie_idle";
    }
}
