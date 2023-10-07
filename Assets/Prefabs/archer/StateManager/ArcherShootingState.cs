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

    public void CheckForTargets()
    {
        var detections = Physics.OverlapSphere(this.transform.position, this.idleState.mobManager.targetRadius, this.idleState.mobManager.targetMask);

        GameObject tg = null;

        if (detections.Length > 0)
        {
            for (int i = 0; i <= detections.Length - 1; i++)
            {
                if (detections[i].gameObject == this.idleState.mobManager.target && this.idleState.mobManager.target.GetComponent<HostileTroopManager>().currentHealth > 0)
                {
                    tg = detections[i].gameObject;

                    break;
                }
            }
        }

        if (tg == null) { this.idleState.mobManager.target = null; }
        else { this.idleState.mobManager.target = tg; }
    }

    private void ShootTarget()
    {
        var detections = Physics.OverlapSphere(this.idleState.mobManager.mob.transform.position, this.idleState.mobManager.targetRadius, this.idleState.mobManager.targetMask);

        CheckForTargets();

        if (this.canShoot && idleState.mobManager.target != null)
        {
            this.canShoot = false;

            Vector3 tg = new Vector3(idleState.mobManager.target.transform.position.x, this.idleState.mobManager.mob.transform.position.y, idleState.mobManager.target.transform.position.z);

            this.idleState.mobManager.mob.transform.LookAt(tg);

            GameObject go = Instantiate(this.arrowPrefab, this.arrowPos.transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
            go.GetComponent<ProjectileMesh>().target = idleState.mobManager.target;
            go.transform.localScale = new Vector3(1.7f, 1.7f, 1.7f);
        } 
    }
}
