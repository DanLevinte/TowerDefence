using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject target;
    public int damage;

    private void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, .01f);
        } else { Destroy(gameObject); }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DownEnemy"))
        {
            target.GetComponent<EnemyManager>().currentHealth -= damage;
            other.GetComponent<EnemyManager>().switchColor = true;
            target.GetComponent<MeshRenderer>().materials[0].color = Color.red;

            Destroy(gameObject);
        }
    }
}
