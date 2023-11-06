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
        if (troops.isArcher)
        {
            damage = Random.Range(troops.archer.minDamage, troops.archer.maxDamage);
            health = troops.archer.health;
            speed = troops.archer.speed;
            radius = troops.archer.radius;
            nameOfTroop = troops.nameOfTroop;
        }  
        if (troops.isMage)
        {
            damage = Random.Range(troops.mage.minDamage, troops.mage.maxDamage);
            health = troops.mage.health;
            speed = troops.mage.speed;
            radius = troops.mage.radius;
            nameOfTroop = troops.nameOfTroop;
        }
    }
}
