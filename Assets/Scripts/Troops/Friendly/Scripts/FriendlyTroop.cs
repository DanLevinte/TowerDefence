using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(menuName = "Troop/Friendly/FriendlyTroopManager")]
public class FriendlyTroop : ScriptableObject
{
    public bool isArcher, isMage, isMachine, isDefender;

    [ShowIf("isDefender")] public FriendlyTroopDefender defender;
}
