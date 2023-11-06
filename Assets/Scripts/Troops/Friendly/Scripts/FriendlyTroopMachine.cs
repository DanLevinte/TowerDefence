using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Troop/Friendly/Friendly Machine")]
public class FriendlyTroopMachine : ScriptableObject
{
    public int health, minDamage, maxDamage, speed, radius;
}
