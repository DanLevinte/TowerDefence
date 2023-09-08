using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballista : MonoBehaviour
{
    public GameObject target;
    public GameObject arrow;

    private void Update()
    {
        if (target != null)
        {
            GetComponent<ParticleSystem>().Play();
            transform.LookAt(target.transform.position);
        } else { GetComponent<ParticleSystem>().Pause(); }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DownEnemy")) 
        {
            target = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("DownEnemy"))
        {
            target = null;
        }
    }


}
