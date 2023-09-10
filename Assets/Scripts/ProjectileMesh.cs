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
            transform.LookAt(target.transform.position);

        } else { lifespan = 0; Destroy(gameObject); }

        transform.rotation = Quaternion.Euler(90, transform.rotation.y, transform.rotation.z);

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
            transform.LookAt(target.transform.position);
            transform.rotation = Quaternion.Euler(90, transform.rotation.y, transform.rotation.z);

            //Destroy(gameObject, .25f);
        }
    }
}
