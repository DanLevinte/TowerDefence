using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieStayDeadState : State
{
    public override string GetStateName()
    {
        return "zombie_stayDead";
    }

    public override State RunCurrentState()
    {
        return this;
    }
}
