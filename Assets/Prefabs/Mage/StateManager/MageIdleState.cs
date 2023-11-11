using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageIdleState : State
{
    public MageShootingState mageShootingState;
    public MobManager mobManager;

    public override State RunCurrentState()
    {
        if (this.mobManager.target == null) { this.mobManager.CheckForTargets(this.mobManager.mob.GetComponent<FriendlyTroopManager>().radius); }
        else { return mageShootingState; }

        return this;
    }

    public override string GetStateName()
    {
        return "mage_isIdle";
    }
}
