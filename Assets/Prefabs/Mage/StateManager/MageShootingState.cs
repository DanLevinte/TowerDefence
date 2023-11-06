using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageShootingState : State
{
    public MageIdleState mageIdleState;
    public MageRestState restState;

    public GameObject fireballPrefab;
    public GameObject fireballPos;

    public bool canShoot = true;

    public override State RunCurrentState()
    {
        if (this.mageIdleState.mobManager.target != null) { ShootTarget(); }
        else { return mageIdleState; }

        if (!this.canShoot) { this.canShoot = true; return restState; }

        return this;
    }

    public override string GetStateName()
    {
        return "mage_isShooting";
    }

    public void CheckForTargets()
    {
        var detections = Physics.OverlapSphere(this.transform.position, this.mageIdleState.mobManager.GetComponent<FriendlyTroopManager>().radius
            , this.mageIdleState.mobManager.targetMask);

        GameObject tg = null;

        if (detections.Length > 0)
        {
            for (int i = 0; i <= detections.Length - 1; i++)
            {
                if (detections[i].gameObject == this.mageIdleState.mobManager.target && this.mageIdleState.mobManager.target.GetComponent<HostileTroopManager>().currentHealth > 0)
                {
                    tg = detections[i].gameObject;

                    break;
                }
            }
        }

        if (tg == null) { this.mageIdleState.mobManager.target = null; }
        else { this.mageIdleState.mobManager.target = tg; }
    }

    private void ShootTarget()
    {
        var detections = Physics.OverlapSphere(this.mageIdleState.mobManager.mob.transform.position,
            this.mageIdleState.mobManager.GetComponent<FriendlyTroopManager>().radius, this.mageIdleState.mobManager.targetMask);

        CheckForTargets();

        if (this.canShoot && this.mageIdleState.mobManager.target != null)
        {
            this.canShoot = false;

            Vector3 tg = new Vector3(this.mageIdleState.mobManager.target.transform.position.x,
                this.mageIdleState.mobManager.mob.transform.position.y, this.mageIdleState.mobManager.target.transform.position.z);

            this.mageIdleState.mobManager.mob.transform.LookAt(tg);

            GameObject go = Instantiate(this.fireballPrefab, this.fireballPos.transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
            go.GetComponent<Meteor>().target = this.mageIdleState.mobManager.target;
            go.GetComponent<Meteor>().damage = this.mageIdleState.mobManager.GetComponent<FriendlyTroopManager>().damage;
        }
    }
}
