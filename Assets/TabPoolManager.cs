using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabPoolManager : MonoBehaviour
{
    public List<GameObject> poolMobsUI = new List<GameObject>();
    //public List<GameObject> 

    private void Start()
    {
        poolMobsUI = PoolManager.instance.enemiesOffPool;
    }

    private void Update()
    {
        if (PoolManager.instance.onValueChange)
        {
            
        }
    }
}
