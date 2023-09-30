using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMovingState : State
{
    public MobManager mobManager;

    public KnightIdleState knightIdleState;
    public KnightAttackingState knightAttackState;

    public Path pathToMoveTo;

    public GameObject target;

    public int speed;

    public bool attack;

    public override State RunCurrentState()
    {
        if (this.mobManager.target == null) { knightIdleState.CheckForTargets(); }

        if (this.pathToMoveTo != null && this.mobManager.target == null) { MoveToPath(); }

        if (this.mobManager.target != null && this.pathToMoveTo != null) { MoveToTarget(); }

        if (OnPathPosition() && this.mobManager.target == null) { return knightIdleState; }

        if (attack && this.mobManager.target.GetComponent<MobManager>().target != null) { return knightAttackState; }

        return this;
    }

    public override string GetStateName()
    {
        return "knight_moving";
    }

    private void MoveToPath()
    {
        Vector3 path = new Vector3(pathToMoveTo.pathPos.x, this.mobManager.mob.transform.position.y, pathToMoveTo.pathPos.z);

        if (Vector3.Distance(this.mobManager.mob.transform.position, pathToMoveTo.pathPos) >= 1f)
        {
            this.mobManager.mob.transform.position = Vector3.MoveTowards(this.mobManager.mob.transform.position, path, .01f);
        }

        this.mobManager.mob.transform.LookAt(path);
    }

    private void MoveToTarget()
    {
        var target = this.mobManager.target.transform.position;

        Vector3 targetPos = new Vector3(target.x, this.mobManager.mob.transform.position.y, target.z);
        
        if (Vector3.Distance(this.mobManager.mob.transform.position, target) >= 1.65f)
        {
            this.mobManager.mob.transform.position = Vector3.MoveTowards(this.mobManager.mob.transform.position, targetPos, .01f);
        } else { attack = true; }

        this.mobManager.mob.transform.LookAt(targetPos);
    }

    private bool OnPathPosition()
    {
        if (Vector3.Distance(this.mobManager.transform.position, pathToMoveTo.pathPos) <= 1f) { return true; }
        else { return false; }
    }
}
