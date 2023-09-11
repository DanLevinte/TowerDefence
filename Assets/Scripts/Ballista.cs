using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballista : MonoBehaviour
{
    public GameObject target;
    public GameObject projectile;
    public GameObject projectilePos;
    public GameObject ballistaBody;

    public bool canShoot;

    private void Update()
    {
        if (target != null)
        {
            Vector3 targetPos = new Vector3(target.transform.position.x, this.gameObject.transform.position.y, target.transform.position.z);
            ballistaBody.transform.LookAt(targetPos);

            if (canShoot) { StartCoroutine(ShootProjectile()); }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DownEnemy")) 
        {
            target = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("DownEnemy"))
        {
            target = null;
        }
    }

    private IEnumerator ShootProjectile()
    {
        canShoot = false;

        yield return new WaitForSeconds(2);

        GameObject go = Instantiate(projectile, projectilePos.transform.position, projectile.transform.rotation);
        go.GetComponent<ProjectileMesh>().target = target;

        canShoot = true;
    }
}
