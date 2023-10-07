using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageIdleState : State
{
    public MageShootingState mageShootingState;
    public MobManager mobManager;

    public override State RunCurrentState()
    {
        if (this.mobManager.target == null) { CheckForTargets(); }
        else { return mageShootingState; }

        return this;
    }

    public override string GetStateName()
    {
        return "mage_isIdle";
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
                }
                else { this.mobManager.target = null; }
            }
        }
    }
}
