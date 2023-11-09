using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherShootingState : State
{
    public ArcherIdleState idleState;
    public ArcherRestState restState;

    public GameObject arrowPrefab;
    public GameObject arrowPos;

    public bool canShoot;

    public override State RunCurrentState()
    {
        Debug.Log(gameObject.name);
        if (this.idleState.mobManager.target == null) { return idleState; }
        else { ShootTarget(); }

        if (!this.canShoot) { this.canShoot = true; return restState; }

        return this;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, this.idleState.mobManager.targetRadius);
    }


    public override string GetStateName()
    {
        return "archer_isShooting";
    }

    private void ShootTarget()
    {
        this.idleState.mobManager.CheckRadiusTargets();

        if (this.canShoot && this.idleState.mobManager.target != null)
        {
            this.canShoot = false;

            Vector3 tg = new Vector3(this.idleState.mobManager.target.transform.position.x, this.idleState.mobManager.mob.transform.position.y, this.idleState.mobManager.target.transform.position.z);

            this.idleState.mobManager.mob.transform.LookAt(tg);

            GameObject go = Instantiate(this.arrowPrefab, this.arrowPos.transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
            go.GetComponent<ProjectileMesh>().target = this.idleState.mobManager.target;
            go.GetComponent<ProjectileMesh>().projDamage = this.idleState.mobManager.GetComponent<FriendlyTroopManager>().damage;
            go.transform.localScale = new Vector3(1.7f, 1.7f, 1.7f);
        } 
    }
}
