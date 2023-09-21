using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobManager : MonoBehaviour
{
    public GameObject mob;
    public GameObject target;

    public StateManager stateManager;

    public static MobManager instance;

    private void Awake()
    {
        instance = this;
    }
}
