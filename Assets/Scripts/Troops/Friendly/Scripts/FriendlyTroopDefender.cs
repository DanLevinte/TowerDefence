using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Troop/Friendly/Friendly Defender")]
public class FriendlyTroopDefender : ScriptableObject
{
    public int health, minDamage, maxDamage, speed, radius;
}
