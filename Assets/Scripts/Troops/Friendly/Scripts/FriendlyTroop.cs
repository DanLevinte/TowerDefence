using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(menuName = "Troop/Friendly/FriendlyTroopManager")]
public class FriendlyTroop : ScriptableObject
{
    public string nameOfTroop;

    public bool isArcher, isMage, isMachine, isDefender;

    public FriendlyTroopDefender defenderEasy;
    public FriendlyTroopDefender defenderNormal;
    public FriendlyTroopDefender defenderHard;
}
