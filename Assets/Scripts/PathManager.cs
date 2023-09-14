using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    public List<Path> paths = new List<Path>();

    public List<Path> defendablePaths = new List<Path>();

    public static PathManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        for (int i = 0; i <= paths.Count - 1; i++)
        {
            defendablePaths.Add(paths[i]);
        }
    }
}
