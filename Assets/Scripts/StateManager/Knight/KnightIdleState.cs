using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightIdleState : State
{
    public KnightMovingState movingState;

    public List<Path> defendablePaths = new List<Path>();
    public Path pathToDefend;

    public override State RunCurrentState()
    {
        return this;
    }

    public override string GetStateName()
    {
        return "knight_idle";
    }
}
