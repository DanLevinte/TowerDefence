using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballista : MonoBehaviour
{
    public GameObject target;
    public GameObject projectile;
    public GameObject projectilePos;

    public bool canShoot;

    private void Update()
    {
        if (target != null)
        {
            transform.LookAt(target.transform.position);

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
