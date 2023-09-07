using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public Vector3 pathPos;

    private void Start()
    {
        pathPos = transform.position; 
    }

    public static object Combine(string dataPath, string v)
    {
        throw new NotImplementedException();
    }
}
