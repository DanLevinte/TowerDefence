using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovingState : State
{
    public ZombieIdleState zombieIdleState;
    public ZombieAttackingState zombieAttackingState;

    public MobManager mobManager;

    public Path nextPath, designatedPos;
    public List <Path> pathsToTake = new List<Path>();

    public LayerMask targetMask;

    public float speed, targetRadius = Mathf.Infinity;

    public bool isTargetInRange;

    public override State RunCurrentState()
    {
        if (this.pathsToTake.Count == 0) { SetPathToTake(); }

        if (this.nextPath != null) { AdvanceOnPath(); }

        if (mobManager.target == null) { CheckForTargets(); }
        else { return zombieAttackingState; }

        return this;
    }

    public override string GetStateName()
    {
        return "zombie_move";
    }

    private void CheckForTargets()
    {
        var detections = Physics.OverlapSphere(mobManager.transform.position, 3, targetMask);

        if (detections.Length != 0)
        {
            for (int i = 0; i <= detections.Length - 1; i++)
            {
                float dist = (transform.position - detections[i].transform.position).magnitude;

                if (dist <= 3)
                {
                    if (detections[i].transform.position.magnitude < targetRadius)  // Find the lowest.
                    {
                        mobManager.target = detections[i].gameObject;
                        isTargetInRange = true;
                        break;
                    }
                }
            }
        }
    }

    private void AdvanceOnPath()
    {
        Vector3 targetPos = new(this.nextPath.pathPos.x, this.mobManager.mob.transform.position.y, this.nextPath.pathPos.z);

        Vector3 pos = new Vector3(this.nextPath.transform.position.x, this.mobManager.mob.transform.position.y, this.nextPath.transform.position.z);
        this.mobManager.mob.transform.LookAt(pos);

        if (Vector3.Distance(targetPos, this.mobManager.mob.transform.position) == 0) { CleanPath(); }
        else { this.mobManager.mob.transform.position = Vector3.MoveTowards(this.mobManager.mob.transform.position, targetPos, speed); }
    }

    private void CleanPath()
    {
        for (int i = 0; i <= this.pathsToTake.Count - 1; i++)
        {
            if (this.nextPath == this.pathsToTake[i]) { this.pathsToTake.Remove(this.pathsToTake[i]); this.nextPath = null; break; }
        }

        for (int i = 0; i <= this.pathsToTake.Count - 1; i++)
        {
            if (this.nextPath == null) { this.nextPath = this.pathsToTake[i]; break; }
        }
    }

    private void SetPathToTake()
    {
        for (int i = 0; i <= PathManager.instance.paths.Count - 1; i++)
        {
            this.pathsToTake.Add(PathManager.instance.paths[i]);
        }

        for (int i = 0; i <= this.pathsToTake.Count - 1; i++)
        {
            if (this.nextPath == null) { this.nextPath = this.pathsToTake[i]; }

            if (i == this.pathsToTake.Count - 1) { this.designatedPos = this.pathsToTake[i]; }
        }

    }
}