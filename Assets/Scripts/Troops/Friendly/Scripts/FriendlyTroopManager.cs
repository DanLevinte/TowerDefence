using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyTroopManager : MonoBehaviour
{
    public FriendlyTroop troops;

    public string nameOfTroop;

    public int damage, health, maxHealth, speed, radius;

    private void Start()
    {
        if (troops != null) 
        { 
            switch(DifficultyManager.instance.typeOfDifficulty)
            {
                case TypeOfDifficulty.Easy: SetDifficulty(troops.defenderEasy);
                    break;
                case TypeOfDifficulty.Medium: SetDifficulty(troops.defenderNormal);
                    break;
                case TypeOfDifficulty.Hard: SetDifficulty(troops.defenderHard);
                    break;
                default: break;
            }
        }
    }

    private void SetDifficulty(FriendlyTroopDefender troopManager)
    {
        damage = Random.Range(troopManager.minDamage, troopManager.maxDamage);
        health = troopManager.health;
        maxHealth = troopManager.health;
        speed = troopManager.speed;
        nameOfTroop = troops.nameOfTroop;
        radius = troopManager.radius;
    }
}
