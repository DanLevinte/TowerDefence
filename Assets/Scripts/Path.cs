using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Path : MonoBehaviour, IPointerClickHandler
{
    public Vector3 pathPos;

    public bool canAct;

    private void Start()
    {
        pathPos = transform.position; 
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (canAct) { TowerManager.instance.pathToManage = this; }
    }    

    public static object Combine(string dataPath, string v)
    {
        throw new NotImplementedException();
    }
}
