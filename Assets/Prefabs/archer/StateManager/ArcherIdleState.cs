using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherIdleState : State
{
    public ArcherShootingState shootingState;

    public MobManager mobManager;

    public override State RunCurrentState()
    {
        if (this.mobManager.target != null) { return shootingState; }
        else { this.mobManager.CheckForTargets(this.mobManager.mob.GetComponent<FriendlyTroopManager>().radius); }

        return this;
    }

    public override string GetStateName()
    {
        return "archer_isIdle";
    }
}
