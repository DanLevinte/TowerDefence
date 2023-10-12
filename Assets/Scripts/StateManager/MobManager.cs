using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TypeOfTroop
{
    Friendly,
    Hostile,
    Tower
}

public class MobManager : MonoBehaviour
{
    public GameObject mob;
    public GameObject target;

    public GameObject canvas;
    public Image healthbar;

    public StateManager stateManager;

    public TypeOfTroop typeOfTroop;

    public LayerMask targetMask;

    public float targetRadius;

    public Sprite spriteOfMob;

    public bool onUI;

    public static MobManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (this.typeOfTroop == TypeOfTroop.Hostile)
        {
            //var ratio = 0.0f;
            //var hostile = GetComponent<HostileTroopManager>();
            ////this.healthbar.fillAmount = Mathf.Lerp(hostile.currentHealth, hostile.maxHealth, ratio);
        }
    }

    private void LateUpdate()
    {
        if (this.canvas != null && this.canvas.activeInHierarchy) { this.canvas.transform.rotation = Quaternion.identity; }
    }
}
