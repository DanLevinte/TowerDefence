using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMesh : MonoBehaviour
{
    public GameObject target;
    public float lifespan = 1.25f;

    private void Update()
    {
        if (target != null)
        {
            lifespan -= Time.deltaTime;


        } else { lifespan = 0; }

        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.1f);

        if (lifespan <= 0) { Destroy(gameObject); }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DownEnemy"))
        {
            other.GetComponent<EnemyManager>().switchColor = true;
            target.GetComponent<MeshRenderer>().materials[0].color = Color.red;

            Destroy(gameObject, .25f);
        }
    }
}
