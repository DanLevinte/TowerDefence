using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DownEnemy")) { other.GetComponent<EnemyManager>().currentHealth -= damage; }
    }
}
