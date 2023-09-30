using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttackingState : State
{
    public ZombieMovingState movingState;
    public ZombieHurtState hurtState;

    public MobManager mobManager;

    public LayerMask targetMask;

    public float timer = 2.5f;

    public override State RunCurrentState()
    {
        if (mobManager.target != null) { RecheckTarget(); }
        else { return this.movingState; }

        timer -= Time.deltaTime;

        if (timer <= 0) { AttackTarget(); return hurtState; }

        return this;
    }

    public override string GetStateName()
    {
        return "zombie_attack";
    }

    private void AttackTarget()
    {
        var target = this.GetComponentInParent<MobManager>().target.GetComponent<FriendlyTroopManager>();
        var troop = this.GetComponentInParent<HostileTroopManager>();

        target.health -= troop.damage;

        timer = 2.5f;
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
