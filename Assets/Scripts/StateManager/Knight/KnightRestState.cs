using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightRestState : State
{
    public KnightAttackingState knightAttackingState;

    public float timer = .25f;

    public override State RunCurrentState()
    {
        timer -= Time.deltaTime;

        if (timer <= 0) { timer = .25f; return knightAttackingState; }

        return this;
    }

    public override string GetStateName()
    {
        return "knight_rest";
    }
}
