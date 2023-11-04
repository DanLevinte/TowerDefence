using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieStayDeadState : State
{
    public GameObject mob;

    public override string GetStateName()
    {
        return "zombie_stayDead";
    }

    public override State RunCurrentState()
    {
        this.mob.SetActive(false);

        return this;
    }
}
