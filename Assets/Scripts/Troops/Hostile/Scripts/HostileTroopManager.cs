using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileTroopManager : MonoBehaviour
{
    public HostileTroop hostileTroop;

    public float currentHealth, maxHealth;

    public int damage, speed;

    public string nameOfHostile;

    private void Start()
    {
        if (hostileTroop != null)
        {
            switch (DifficultyManager.instance.typeOfDifficulty)
            {
                case TypeOfDifficulty.Easy:
                    SetDifficulty(hostileTroop.hostileSkirmisherEasy);
                    break;
                case TypeOfDifficulty.Medium:
                    SetDifficulty(hostileTroop.hostileSkirmisherNormal);
                    break;
                case TypeOfDifficulty.Hard:
                    SetDifficulty(hostileTroop.hostileSkirmisherHard);
                    break;
                default: break;
            }
        }
    }

    private void SetDifficulty(HostileSkirmisher skirmisher)
    {
        damage = Random.Range(skirmisher.minDamage, skirmisher.maxDamage);
        currentHealth = skirmisher.health;
        speed = skirmisher.speed;
        maxHealth = skirmisher.health;
        nameOfHostile = hostileTroop.nameOfTroop;
    }
}
