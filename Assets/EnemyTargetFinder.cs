using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetFinder : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Knight") && GetComponentInParent<EnemyManager>().target == null)
        {


            if (!other.GetComponent<Character>().inFight && other.GetComponent<Character>().target == null)
            { GetComponentInParent<EnemyManager>().target = other.gameObject; }
        }     
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Knight") && GetComponentInParent<EnemyManager>().target == null)
        {
            if (!other.GetComponent<Character>().inFight && other.GetComponent<Character>().target == null) 
            { GetComponentInParent<EnemyManager>().target = other.gameObject; Debug.Log(gameObject.transform.parent.name); }
            else { GetComponentInParent<EnemyManager>().target = null; }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Knight") && GetComponentInParent<EnemyManager>().target == null)
        {
            if (!other.GetComponent<Character>().inFight && other.GetComponent<Character>().target == null) 
            { GetComponentInParent<EnemyManager>().target = null; }
        }
    }
}
