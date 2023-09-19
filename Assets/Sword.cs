using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public int damage;
    public bool isGivingDamage = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemySearcher"))
        {
            if (this.GetComponentInParent<KnightManager>().target == other.gameObject)
            {
                other.GetComponentInParent<EnemyManager>().currentHealth -= damage;
                other.GetComponentInParent<EnemyManager>().switchColor = true;
                other.GetComponentInParent<MeshRenderer>().materials[0].color = Color.red;
                isGivingDamage = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (this.GetComponentInParent<KnightManager>().target == other.gameObject)
        {
            Debug.Log("ex");
            this.GetComponent<BoxCollider>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = true;
            isGivingDamage = false;
        }
    }
}
