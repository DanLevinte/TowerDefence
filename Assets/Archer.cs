using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    public GameObject target;
    public ArcherManager archerManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DownEnemy"))
        {
            archerManager.target = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("DownEnemy"))
        {
            archerManager.target = null;
        }
    }
}
