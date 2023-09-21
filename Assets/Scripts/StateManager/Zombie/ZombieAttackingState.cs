using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttackingState : State
{
    public ZombieMovingState movingState;

    public MobManager mobManager;

    public LayerMask targetMask;

    public override State RunCurrentState()
    {
        if (mobManager.target != null) { RecheckTarget(); }
        else { return this.movingState; }

        return this;
    }

    public override string GetStateName()
    {
        return "zombie_attack";
    }

    private void RecheckTarget()
    {
        var detections = Physics.OverlapSphere(mobManager.transform.position, 1, targetMask);
        
        if (detections.Length != 0)
        {
            for (int i = 0; i <= detections.Length - 1 ; i++)
            {
                if (mobManager.target == detections[i].gameObject) 
                {
                    Vector3 pos = new Vector3(detections[i].transform.position.x, this.gameObject.transform.position.y, detections[i].transform.position.z);
                    this.mobManager.mob.transform.LookAt(pos);
                    break;
                }
            }
        }
    }
}
