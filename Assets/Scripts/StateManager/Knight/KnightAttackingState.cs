using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAttackingState : State
{
    public override State RunCurrentState()
    {
        return this;
    }

    public override string GetStateName()
    {
        return "knight_attack";
    }
}
