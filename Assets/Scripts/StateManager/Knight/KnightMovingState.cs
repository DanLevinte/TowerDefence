using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMovingState : State
{
    public KnightIdleState knightIdleState;

    public Path pathToMoveTo;

    public GameObject target;

    public override State RunCurrentState()
    {
        if (target == null) { knightIdleState.CheckForTargets(); }

        if (pathToMoveTo != null && target == null) { MoveToPath(); }

        if (target != null && pathToMoveTo != null) { MoveToTarget(); }

        if (OnPathPosition()) { return knightIdleState; }

        return this;
    }

    public override string GetStateName()
    {
        return "knight_moving";
    }

    private void MoveToPath()
    {
        Vector3 path = new Vector3(pathToMoveTo.pathPos.x, MobManager.instance.mob.transform.position.y, pathToMoveTo.pathPos.z);

        if (Vector3.Distance(MobManager.instance.mob.transform.position, pathToMoveTo.pathPos) >= 1f)
        {
            MobManager.instance.mob.transform.position = Vector3.MoveTowards(MobManager.instance.mob.transform.position, path, .01f);
        }

        Vector3 pos = new Vector3(pathToMoveTo.transform.position.x, MobManager.instance.mob.transform.position.y, pathToMoveTo.transform.position.z);
        MobManager.instance.mob.transform.LookAt(pos);
    }

    private void MoveToTarget()
    {

    }

    private bool OnPathPosition()
    {
        if (Vector3.Distance(MobManager.instance.mob.transform.position, pathToMoveTo.pathPos) <= 1f) { return true; }
        else { return false; }
    }
}
