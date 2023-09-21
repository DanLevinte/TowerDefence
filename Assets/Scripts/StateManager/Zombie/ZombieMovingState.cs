using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovingState : State
{
    public override State RunCurrentState()
    {
        return this;
    }

    public override string GetStateName()
    {
        return "zombie_move";
    }
}
