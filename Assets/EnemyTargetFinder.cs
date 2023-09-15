using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetFinder : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Knight"))
        {
            GetComponentInParent<EnemyManager>().target = other.gameObject;
        } 
            
    }
}
