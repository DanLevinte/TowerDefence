using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightIdleState : State
{
    public DefenderManager defenderManager;

    public KnightMovingState movingState;

    public List<Path> defendablePaths = new List<Path>();

    public LayerMask targetMask;

    public GameObject basePos;

    public float targetRadius = Mathf.Infinity;

    private void Start()
    {
        this.basePos = this.GetComponentInParent<Defenders>().defenderPos;
    }

    public override State RunCurrentState()
    {
        if (ShouldBeMoving()) { movingState.pathToMoveTo = GetComponentInParent<DefenderManager>().pathToDefend; return movingState; }

        if (movingState.mobManager.target == null) { movingState.mobManager.CheckForTargets(); }

        if (movingState.mobManager.target != null) { return movingState; }

        return this;
    }

    public override string GetStateName()
    {
        return "knight_idle";
    }

    private bool ShouldBeMoving()
    {
        if (this.defenderManager.pathToDefend != null && Vector3.Distance(movingState.mobManager.transform.position, defenderManager.pathToDefend.pathPos) >= 1f)
        { return true; }
        else { return false; }
    }
}
