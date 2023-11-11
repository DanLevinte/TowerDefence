using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMesh : MonoBehaviour
{
    public GameObject target;
    public float lifespan = 2.5f;
    public float speed;

    public int projDamage;

    public LayerMask targetMask;

    private void Update()
    {
        if (this.target != null)
        {
            FollowTarget();
        } else { this.lifespan = 0; Destroy(this.gameObject); }

        if (this.lifespan <= 0) { this.gameObject.SetActive(false); }
    }

    private void FollowTarget()
    {
        this.lifespan -= Time.deltaTime;
        this.gameObject.transform.rotation = Quaternion.identity;

        this.transform.position = Vector3.MoveTowards(this.transform.position, this.target.transform.position, this.speed * Time.deltaTime);

        var detections = Physics.OverlapSphere(this.transform.position, 1.5f, this.targetMask);

        if (detections.Length != 0)
        {
            for (int i = 0; i <= detections.Length - 1; i++)
            {
                if (detections[i].gameObject == this.target) 
                {
                    var targetManager = detections[i].gameObject.GetComponent<HostileTroopManager>();

                    this.target.GetComponent<MobManager>().isHurt = true;
                    this.target.GetComponent<MobManager>().isHit = true;

                    targetManager.currentHealth -= this.projDamage;
                    this.target = null;
                    break;
                }
            }
        }
    }
}
