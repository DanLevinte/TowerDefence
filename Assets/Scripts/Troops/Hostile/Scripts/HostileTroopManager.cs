using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileTroopManager : MonoBehaviour
{
    public HostileTroop hostileTroop;

    public int damage, currentHealth, maxHealth, speed;

    public string nameOfHostile;

    private void Start()
    {
        nameOfHostile = hostileTroop.nameOfTroop;

        if (hostileTroop.isSkirmisher) 
        { 
            damage = Random.Range(hostileTroop.hostileSkirmisher.minDamage, hostileTroop.hostileSkirmisher.maxDamage);
            currentHealth = hostileTroop.hostileSkirmisher.health;
            speed = hostileTroop.hostileSkirmisher.speed;
            maxHealth = hostileTroop.hostileSkirmisher.health;
        }
    }
}
