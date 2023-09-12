using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageManager : MonoBehaviour
{
    public GameObject target;
    public bool canShoot;
    public bool recharging;

    public GameObject meteorPos;
    public GameObject meteorPrefab;

    public Animator animator;
    private void Update()
    {
        if (target == null) { animator.SetBool("isIdle", true); }
        else 
        { 
            animator.SetBool("isIdle", false);
            Vector3 pos = new Vector3(target.transform.position.x, this.gameObject.transform.position.y, target.transform.position.z);
            gameObject.transform.LookAt(pos);

            if (canShoot) { StartCoroutine(ShootMeteor()); }
            if (recharging) { StartCoroutine(Recharging()); }
        }
    }

    private IEnumerator ShootMeteor()
    {
        canShoot = false;
        yield return new WaitForSeconds(1);

        GameObject go = Instantiate(meteorPrefab, meteorPos.transform.position, Quaternion.identity);
        go.GetComponent<Meteor>().target = target;

        recharging = true;
    }

    private IEnumerator Recharging()
    {
        recharging = false;
        yield return new WaitForSeconds(1.5f);

        canShoot = true;
    }
}
