using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(menuName = "Troop/Friendly/FriendlyTroopManager")]
public class FriendlyTroop : ScriptableObject
{
    public string nameOfTroop;

    public bool isArcher, isMage, isMachine, isDefender;

    [ShowIf("isDefender")] public FriendlyTroopDefender defender;

    [ShowIf("isMachine")] public FriendlyTroopMachine machine;

    [ShowIf("isArcher")] public FriendlyTroopArcher archer;
}
