using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabManager : MonoBehaviour
{
    public GameObject FriendlyUI_box;
    public GameObject friendlyContainer;

    public GameObject FoeUI_box;
    public GameObject foeContainer;

    public GameObject mobPrefab;

    public TabPoolManager tabPoolManager;

    public static TabManager instance;

    private void Awake()
    {
        instance = this;
        tabPoolManager = GetComponent<TabPoolManager>();
    }
}
