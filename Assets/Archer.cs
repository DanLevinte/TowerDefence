using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    public GameObject target;
    public MageManager mageManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DownEnemy"))
        {
            mageManager.target = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("DownEnemy"))
        {
            mageManager.target = null;
        }
    }
}
