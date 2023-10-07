using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageRestState : State
{
    public MageShootingState mageShootingState;
    public float timer = 3.5f;

    public override State RunCurrentState()
    {
        this.timer -= Time.deltaTime;

        Vector3 tg = new Vector3(this.mageShootingState.mageIdleState.mobManager.target.transform.position.x,
            this.mageShootingState.mageIdleState.mobManager.mob.transform.position.y, this.mageShootingState.mageIdleState.mobManager.target.transform.position.z);

        this.mageShootingState.mageIdleState.mobManager.mob.transform.LookAt(tg);

        if (this.timer <= 0) { this.timer = 3.5f; return mageShootingState; }

        return this;
    }

    public override string GetStateName()
    {
        return "mage_isShooting";
    }
}
