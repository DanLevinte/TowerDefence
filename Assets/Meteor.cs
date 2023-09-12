using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public GameObject target;
    public int damage;

    private void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, .01f);
        } else { Destroy(gameObject); }
    }

    private void OnParticleCollision(GameObject other)
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
