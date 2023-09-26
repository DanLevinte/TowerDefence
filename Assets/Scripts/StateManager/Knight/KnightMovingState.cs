using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMovingState : State
{
    public KnightIdleState knightIdleState;
    public KnightAttackingState knightAttackState;

    public Path pathToMoveTo;

    public GameObject target;

    public bool attack;

    public override State RunCurrentState()
    {
        if (MobManager.instance.target == null) { knightIdleState.CheckForTargets(); }

        if (pathToMoveTo != null && MobManager.instance.target == null) { MoveToPath(); }

        if (MobManager.instance.target != null && pathToMoveTo != null) { MoveToTarget(); }

        if (OnPathPosition()) { return knightIdleState; }

        if (attack) { return knightAttackState; }

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

        MobManager.instance.mob.transform.LookAt(path);
    }

    private void MoveToTarget()
    {
        var target = MobManager.instance.target.transform.position;

        Vector3 targetPos = new Vector3(target.x, MobManager.instance.mob.transform.position.y, target.z);
        
        if (Vector3.Distance(MobManager.instance.mob.transform.position, target) >= 1f)
        {
            MobManager.instance.mob.transform.position = Vector3.MoveTowards(MobManager.instance.mob.transform.position, targetPos, .01f);
        } else { attack = true; }

        MobManager.instance.mob.transform.LookAt(targetPos);
    }

    private bool OnPathPosition()
    {
        if (Vector3.Distance(MobManager.instance.mob.transform.position, pathToMoveTo.pathPos) <= 1f) { return true; }
        else { return false; }
    }
}
