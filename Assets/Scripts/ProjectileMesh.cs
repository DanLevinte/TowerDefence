using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMesh : MonoBehaviour
{
    public GameObject target;
    public float lifespan = 5f;

    public int projDamage;

    private void Update()
    {
        if (target != null)
        {
            lifespan -= Time.deltaTime;
            Vector3 targetPos = new Vector3(target.transform.position.x, this.gameObject.transform.position.y, target.transform.position.z);
            transform.LookAt(targetPos);

        } else { lifespan = 0; Destroy(gameObject); }

        if (lifespan <= 0) { gameObject.SetActive(false); }

        if (this.gameObject.transform.parent == null && target != null) { transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.1f); }
        else { Destroy(gameObject); }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DownEnemy"))
        {
            other.GetComponent<EnemyManager>().switchColor = true;
            target.GetComponent<MeshRenderer>().materials[0].color = Color.red;
            this.gameObject.transform.SetParent(other.transform);

            other.GetComponent<EnemyManager>().currentHealth -= projDamage;
            Vector3 targetPos = new Vector3(target.transform.position.x, this.gameObject.transform.position.y, target.transform.position.z);
            transform.LookAt(targetPos);

            //Destroy(gameObject, .25f);
        }
    }
}
