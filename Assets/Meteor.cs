using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public GameObject target;
    public int damage;

    public LayerMask targetMask;

    private void Update()
    {
        if (target != null)
        {
            FollowTarget();
        } else { Destroy(this.gameObject); }
    }

    private void FollowTarget()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, 10 * Time.deltaTime);

        var detections = Physics.OverlapSphere(this.transform.position, .5f, this.targetMask);

        if (detections.Length != 0)
        {
            for (int i = 0; i <= detections.Length - 1; i++)
            {
                if (detections[i].gameObject == this.target)
                {
                    var targetManager = detections[i].gameObject.GetComponent<HostileTroopManager>();

                    this.target.GetComponent<MobManager>().isHurt = true;
                    targetManager.currentHealth -= this.damage;
                    this.target = null;
                    break;
                }
            }
        }
    }
}
