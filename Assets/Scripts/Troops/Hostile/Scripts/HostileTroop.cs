using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(menuName = "Troop/Hostile/HostileTroopManager")]
public class HostileTroop : ScriptableObject
{
    public string nameOfTroop;

    public bool isMage, isArcher, isSkirmisher, isAirborne;

    public int minGold, maxGold;

    [ShowIf("isSkirmisher")] public HostileSkirmisher hostileSkirmisher;
}
