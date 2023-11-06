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
        if (troops.isDefender) 
        { 
            damage = Random.Range(troops.defender.minDamage, troops.defender.maxDamage);
            health = troops.defender.health;
            speed = troops.defender.speed;
            nameOfTroop = troops.nameOfTroop;
        }
        if (troops.isMachine)
        {
            damage = Random.Range(troops.machine.minDamage, troops.machine.maxDamage);
            health = troops.machine.health;
            speed = troops.machine.speed;
            radius = troops.machine.radius;
            nameOfTroop = troops.nameOfTroop;
        }
    }
}
