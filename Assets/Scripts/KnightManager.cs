using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightManager : MonoBehaviour
{
    public Path pathToDefend;
    public GameObject target;

    public List<Path> defendablePaths = new List<Path>();

    private void Update()
    {
        if (pathToDefend == null && Input.GetMouseButtonDown(0) && TowerManager.instance.pathToManage != null)
        {
            pathToDefend = TowerManager.instance.pathToManage;
        }
    }
}
