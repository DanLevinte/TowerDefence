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
                StartCoroutine(SetColOff());
            }
        }
    }

    private IEnumerator SetColOff()
    {
        this.GetComponent<BoxCollider>().enabled = false;

        yield return new WaitForSeconds(2);

        this.GetComponent<BoxCollider>().enabled = true;
    }
}
