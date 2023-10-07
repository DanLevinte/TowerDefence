using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherIdleState : State
{
    public ArcherShootingState shootingState;

    public MobManager mobManager;

    public override State RunCurrentState()
    {
        if (this.mobManager.target != null) { return shootingState; }
        else { CheckForTargets(); }

        return this;
    }

    public override string GetStateName()
    {
        return "archer_isIdle";
    }

    public void CheckForTargets()
    {
        var detections = Physics.OverlapSphere(this.mobManager.mob.transform.position, this.mobManager.targetRadius, this.mobManager.targetMask);

        if (detections.Length != 0)
        {
            for (int i = 0; i <= detections.Length - 1; i++)
            {
                float dist = (this.transform.position - detections[i].transform.position).magnitude;

                if (dist <= this.mobManager.targetRadius && detections[i].GetComponent<HostileTroopManager>().currentHealth > 0 && detections[i].tag == "DownEnemy")
                {
                    this.mobManager.target = detections[i].gameObject;
                    break;
                } else { this.mobManager.target = null; }
            }
        }
    }
}
