using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherRestState : State
{
    public ArcherShootingState shootingState;
    public ArcherIdleState idleState;

    public float timer = 1;

    public override State RunCurrentState()
    {
        timer -= Time.deltaTime;

        if (idleState.mobManager.target != null && timer <= 0) { timer = 1; return shootingState; }
        else if (idleState.mobManager.target == null && timer <= 0) { return idleState; }

        return this;
    }

    public override string GetStateName()
    {
        return "archer_isIdle";
    }
}
