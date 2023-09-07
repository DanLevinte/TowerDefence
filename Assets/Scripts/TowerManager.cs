using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public Tower towerInUse;

    public static TowerManager instance;

    private void Awake()
    {
        instance = this;
    }
}
