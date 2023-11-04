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
        if (this.mobManager.target == null) { CheckForTargets(); }
        else { MoveToTarget(); }

        if (this.pathToMoveTo != null && this.mobManager.target == null) { MoveToPath(); Debug.Log("s"); }

        if (attack && this.mobManager.target.GetComponent<MobManager>().target != null) { attack = false; return knightAttackState; }

        if (this.pathToMoveTo != null && OnPathPosition(this.pathToMoveTo.pathPos) && this.mobManager.target == null) { return knightIdleState; }

        return this;
    }

    public override string GetStateName()
    {
        return "knight_moving";
    }

    public void CheckForTargets()
    {
        var detections = Physics.OverlapSphere(mobManager.mob.transform.position, 6, knightIdleState.targetMask);

        if (detections.Length != 0)
        {
            for (int i = 0; i <= detections.Length - 1; i++)
            {
                float dist = (this.transform.position - detections[i].transform.position).magnitude;

                if (dist <= 6 && detections[i].GetComponent<HostileTroopManager>().currentHealth >= 0 && detections[i].tag == "DownEnemy")
                {
                    if (detections[i].transform.position.magnitude < knightIdleState.targetRadius)
                    {
                        this.mobManager.target = detections[i].gameObject;
                        break;
                    }
                }
            }
        }
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

    private bool OnPathPosition(Vector3 location)
    {
        if (Vector3.Distance(this.mobManager.transform.position, location) <= 1f) { return true; }
        else { return false; }
    }
}
