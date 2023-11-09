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

        Vector3 tg = new Vector3(this.idleState.mobManager.target.transform.position.x, this.idleState.mobManager.mob.transform.position.y, this.idleState.mobManager.target.transform.position.z);

        this.idleState.mobManager.mob.transform.LookAt(tg);

        if (this.idleState.mobManager.target != null && timer <= 0) { timer = 1; return shootingState; }
        else if (this.idleState.mobManager.target == null && timer <= 0) { return idleState; }

        return this;
    }

    public override string GetStateName()
    {
        return "archer_isShooting";
    }
}
