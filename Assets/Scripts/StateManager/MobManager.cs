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

    public bool isHurt;

    public static MobManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (this.typeOfTroop == TypeOfTroop.Hostile)
        {
            var troop = this.mob.GetComponent<HostileTroopManager>();
            this.healthbar.fillAmount = (troop.currentHealth / troop.maxHealth);
        }

        if (isHurt) { TabManager.instance.tabPoolManager.updateHealthbars = true; isHurt = false; }
    }

    private void LateUpdate()
    {
        if (this.canvas != null && this.canvas.activeInHierarchy) { this.canvas.transform.rotation = Quaternion.identity; }
    }
}
