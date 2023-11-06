using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Troop/Friendly/Friendly Archer")]
public class FriendlyTroopArcher : ScriptableObject
{
    public int health, minDamage, maxDamage, speed, radius;
}
