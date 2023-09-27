using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(menuName = "Troop/TroopManager")]
public class Troop : ScriptableObject
{
    public bool isArcher;
    public bool isMage;
    public bool isMachine;
    public bool isDefender;

    [ShowIf("isDefender")] public TroopDefender defender;
}
