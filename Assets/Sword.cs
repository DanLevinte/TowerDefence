using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public int damage;
    public bool isGivingDamage = false;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("DownEnemy"))
        {
            other.GetComponent<EnemyManager>().currentHealth -= damage;
            other.GetComponent<EnemyManager>().switchColor = true;
            other.GetComponent<MeshRenderer>().materials[0].color = Color.red;
            isGivingDamage = true;
        }
    }
}
