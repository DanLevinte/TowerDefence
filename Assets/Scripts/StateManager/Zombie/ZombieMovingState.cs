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

        if (this.mobManager.target == null) { CheckForTargets(); }
        else { return zombieAttackingState; }

        if (designatedPos == null && nextPath == null) { return null; }

        if (this.GetComponentInParent<HostileTroopManager>().currentHealth <= 0) { return zombieAttackingState.hurtState.deathState; }

        return this;
    }

    public override string GetStateName()
    {
        return "zombie_move";
    }

    private void CheckForTargets()
    {
        var detections = Physics.OverlapSphere(this.mobManager.transform.position, 3, targetMask);

        if (detections.Length != 0)
        {
            for (int i = 0; i <= detections.Length - 1; i++)
            {
                float dist = (this.transform.position - detections[i].transform.position).magnitude;

                if (dist <= 3 && detections[i].tag == "Knight" && detections[i].GetComponent<FriendlyTroopManager>().health >= 0)
                {
                    if (detections[i].transform.position.magnitude < targetRadius)
                    {
                        var targets = PoolManager.instance.enemiesOffPool;

                        for (int k = 0; k <= targets.Count - 1; k++)
                        {
                            if (targets[k].GetComponent<HostileTroopManager>().currentHealth <= 0) { targets.Remove(targets[k]); }
                        }

                        for (int j = 0; j <= targets.Count - 1; j++)
                        {
                            if (targets[j].GetComponent<MobManager>().target != detections[i].gameObject)
                            {
                                this.mobManager.target = detections[i].gameObject;
                            }
                            else { this.mobManager.target = null; break; }
                        }
                    }
                }
            }
        }
    }

    private void AdvanceOnPath()
    {
        Vector3 targetPos = new(this.nextPath.pathPos.x, this.mobManager.mob.transform.position.y, this.nextPath.pathPos.z);
        this.mobManager.mob.transform.LookAt(targetPos);

        if (Vector3.Distance(this.designatedPos.transform.position, this.nextPath.transform.position) == 0) 
        { 
            this.mobManager.gameObject.SetActive(false);
            this.nextPath = null;
            this.designatedPos = null;
            return;
        }

        if (Vector3.Distance(targetPos, this.mobManager.mob.transform.position) == 0) { CleanPath(); }
        else { this.mobManager.mob.transform.position = Vector3.MoveTowards
                (this.mobManager.mob.transform.position, targetPos, GetComponentInParent<HostileTroopManager>().speed * Time.deltaTime); 
        }
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
