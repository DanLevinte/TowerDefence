using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovingState : State
{
    public MobManager mobManager;

    public Path nextPath;
    public Path designatedPos;
    public List <Path> pathsToTake = new List<Path>();

    public float speed;

    public override State RunCurrentState()
    {
        if (this.pathsToTake.Count == 0) { SetPathToTake(); }

        if (this.nextPath != null) { AdvanceOnPath(); }

        return this;
    }

    public override string GetStateName()
    {
        return "zombie_move";
    }

    private void AdvanceOnPath()
    {
        Vector3 targetPos = new(this.nextPath.pathPos.x, this.mobManager.mob.transform.position.y, this.nextPath.pathPos.z);

        Vector3 pos = new Vector3(this.nextPath.transform.position.x, this.mobManager.mob.transform.position.y, this.nextPath.transform.position.z);
        this.gameObject.transform.LookAt(pos);

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
