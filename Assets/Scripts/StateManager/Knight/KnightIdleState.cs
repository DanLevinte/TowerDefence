using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightIdleState : State
{
    public DefenderManager defenderManager;

    public KnightMovingState movingState;

    public List<Path> defendablePaths = new List<Path>();

    public override State RunCurrentState()
    {
        if (ShouldBeMoving()) { movingState.pathToMoveTo = GetComponentInParent<DefenderManager>().pathToDefend; return movingState; }

        return this;
    }

    public override string GetStateName()
    {
        return "knight_idle";
    }

    private bool ShouldBeMoving()
    {
        if (defenderManager.pathToDefend != null &&
            Vector3.Distance(MobManager.instance.mob.transform.position, movingState.pathToMoveTo.pathPos) <= 1f)
        { return true; }
        else { return false; }
    }
}
