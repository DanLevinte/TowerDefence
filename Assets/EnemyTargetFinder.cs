using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetFinder : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Knight") && GetComponentInParent<EnemyManager>().target == null)
        {
            this.GetComponentInParent<EnemyManager>().target = other.gameObject;
            //var poolManager = PoolManager.instance.enemiesOffPool;
            //for (int i = 0; i <= poolManager.Count - 1; i++)
            //{
            //    var character = other.gameObject.GetComponent<Character>();
            //    if (!character.inFight && character.target == null)
            //    {
            //        if (poolManager[i].GetComponent<EnemyManager>().target == null &&
            //            poolManager[i].GetComponent<EnemyManager>() == this.transform.parent.GetComponent<EnemyManager>())
            //        {
            //
            //        }
            //    }
            //}
        }     
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Knight") && this.GetComponentInParent<EnemyManager>().target == null)
        {
            var poolManager = PoolManager.instance.enemiesOffPool;

            for (int i = 0; i <= poolManager.Count - 1; i++)
            {
                var character = other.gameObject.GetComponent<Character>();
                if (!character.inFight && character.target == null || character.inFight && character.target == null)
                {
                    if (poolManager[i].GetComponent<EnemyManager>().target == null &&
                        poolManager[i].GetComponent<EnemyManager>() == this.transform.parent.GetComponent<EnemyManager>())
                    {
                        this.GetComponentInParent<EnemyManager>().target = other.gameObject;
                    }
                }
            }
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
