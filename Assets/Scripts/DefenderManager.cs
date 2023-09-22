using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderManager : MonoBehaviour
{
    public GameObject target;

    public List<Path> defendablePaths = new List<Path>();
    public Path pathToDefend;
}
