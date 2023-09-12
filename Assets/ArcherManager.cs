using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherManager : MonoBehaviour
{
    public GameObject target;
    public GameObject arrowPos;
    public GameObject arrowPrefab;

    public bool canShoot;
    public bool recharge;

    public Animator animator;

    private void Update()
    {
        if (target == null) { animator.SetBool("isIdle", true); }
        else
        {
            animator.SetBool("isIdle", false);
            Vector3 pos = new Vector3(target.transform.position.x, this.gameObject.transform.position.y, target.transform.position.z);
            gameObject.transform.LookAt(pos);

            if (canShoot) { StartCoroutine(CanShootArrow()); }
            else { StartCoroutine(Recharge()); }
        }
    }

    public IEnumerator Recharge()
    {
        recharge = false;

        yield return new WaitForSeconds(.5f);

        canShoot = true;
    }

    public IEnumerator CanShootArrow()
    {
        canShoot = false;

        yield return new WaitForSeconds(1);

        GameObject go = Instantiate(arrowPrefab, arrowPos.transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
        go.GetComponent<Arrow>().target = target;
        recharge = true;
    }
}
