using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(menuName = "Troop/Hostile/HostileTroopManager")]
public class HostileTroop : ScriptableObject
{
    public bool isMage, isArcher, isSkirmisher, isAirborne;

    [ShowIf("isSkirmisher")] public HostileSkirmisher hostileSkirmisher;
}