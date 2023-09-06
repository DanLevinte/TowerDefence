using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    public List<Path> paths = new List<Path>();

    public static PathManager instance;

    private void Awake()
    {
        instance = this;
    }
}
