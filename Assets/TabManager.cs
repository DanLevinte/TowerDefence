using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabManager : MonoBehaviour
{
    public GameObject UI_box;
    public GameObject container;
    public GameObject mobPrefab;

    public TabPoolManager tabPoolManager;

    public static TabManager instance;

    private void Awake()
    {
        instance = this;
        tabPoolManager = GetComponent<TabPoolManager>();
    }
}
