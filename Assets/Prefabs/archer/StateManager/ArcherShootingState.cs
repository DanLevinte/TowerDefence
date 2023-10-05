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
        if (idleState.mobManager.target == null) { return idleState; }
        else { ShootTarget(); }

        if (!this.canShoot) { this.canShoot = true; return restState; }

        //OnDrawGizmos();

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
        if (this.canShoot)
        {
            this.canShoot = false;

            Vector3 tg = new Vector3(idleState.mobManager.target.transform.position.x, this.idleState.mobManager.mob.transform.position.y, idleState.mobManager.target.transform.position.z);

            this.transform.LookAt(tg);

            GameObject go = Instantiate(this.arrowPrefab, this.arrowPos.transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
            go.GetComponent<Arrow>().target = idleState.mobManager.target;
        } 
    }
}
