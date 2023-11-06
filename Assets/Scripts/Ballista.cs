using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballista : MonoBehaviour
{
    public GameObject target;
    public GameObject projectile;
    public GameObject projectilePos;
    public GameObject ballistaBody;

    public LayerMask targetMask;

    public int targetRadius;

    public bool canShoot;

    private void Update()
    {
        if (this.target != null) { this.ShootTarget(); } 
        else { this.FindTarget(); }
    }

    private void ShootTarget()
    {
        var detections = Physics.OverlapSphere(this.transform.position, this.GetComponent<FriendlyTroopManager>().radius, this.targetMask);

        GameObject tg = null;

        if (detections.Length > 0)
        {
            for (int i = 0; i <= detections.Length - 1; i++)
            {
                if (detections[i].gameObject == this.target && this.target.GetComponent<HostileTroopManager>().currentHealth > 0)
                {
                    Vector3 targetPos = new Vector3(this.target.transform.position.x, this.gameObject.transform.position.y, this.target.transform.position.z);
                    this.ballistaBody.transform.LookAt(targetPos);

                    if (this.canShoot) { this.StartCoroutine(ShootProjectile()); }
                    tg = detections[i].gameObject;
                    
                    break;
                }
            }
        }

        if (tg == null) { this.target = null; }
    }

    private void FindTarget()
    {
        var detections = Physics.OverlapSphere(this.transform.position, this.targetRadius, this.targetMask);

        if (detections.Length > 0)
        {
            for (int i = 0; i <= detections.Length - 1; i++)
            {
                if (detections[i].tag == "DownEnemy" && detections[i].GetComponent<HostileTroopManager>().currentHealth > 0)
                {
                    this.target = detections[i].gameObject;
                    break;
                }
            }
        }
    }

    private IEnumerator ShootProjectile()
    {
        this.canShoot = false;

        yield return new WaitForSeconds(2);

        GameObject go = Instantiate(this.projectile, this.projectilePos.transform.position, this.projectile.transform.rotation);
        go.GetComponent<ProjectileMesh>().target = this.target;
        go.GetComponent<ProjectileMesh>().projDamage = this.GetComponent<FriendlyTroopManager>().damage;

        this.canShoot = true;
    }
}
