using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TypeOfTroop
{
    Friendly,
    Hostile
}

public class MobManager : MonoBehaviour
{
    public GameObject mob;
    public GameObject target;

    public GameObject canvas;
    public Image healthbar;

    public StateManager stateManager;

    public TypeOfTroop typeOfTroop;

    public static MobManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (typeOfTroop == TypeOfTroop.Hostile)
        {
            var ratio = 0.0f;
            var hostile = GetComponent<HostileTroopManager>();
            healthbar.fillAmount = Mathf.Lerp(hostile.currentHealth, hostile.maxHealth, ratio);
        }

    }

    private void LateUpdate()
    {
        if (this.canvas.activeInHierarchy) { this.canvas.transform.rotation = Quaternion.identity; }
    }
}
