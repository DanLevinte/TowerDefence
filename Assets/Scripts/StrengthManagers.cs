using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthManagers : MonoBehaviour
{
    public GameObject defenderToUpgrade;

    public bool canUpgrade;

    public GameObject strengthButton;

    public static StrengthManagers instance;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (canUpgrade && defenderToUpgrade != null) { SetUpPower(); }
    }

    private void SetUpPower()
    {
        canUpgrade = false;
        var def = defenderToUpgrade.GetComponent<MobInfoOnTab>().mob.GetComponent<FriendlyTroopManager>();
        
        if (strengthButton.GetComponent<BuyStrength>().strength == Strength.Damage) { def.damage += 1; }
        else { def.radius += 1; }
    }
}
