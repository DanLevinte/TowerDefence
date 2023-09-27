using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Troop/Defender")]
public class TroopDefender : ScriptableObject
{
    public int health;

    public int minDamage;
    public int maxDamage;

    public float speed;
}
