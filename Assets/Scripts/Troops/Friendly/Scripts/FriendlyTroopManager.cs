using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyTroopManager : MonoBehaviour
{
    public FriendlyTroop troops;

    public string nameOfTroop;

    public int damage, health, speed, radius;

    private void Start()
    {
        if (troops != null) 
        { 
            damage = Random.Range(troops.defender.minDamage, troops.defender.maxDamage);
            health = troops.defender.health;
            speed = troops.defender.speed;
            nameOfTroop = troops.nameOfTroop;
            radius = troops.defender.radius;
        }
    }
}
