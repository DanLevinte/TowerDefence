using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopManager : MonoBehaviour
{
    public Troop troops;

    public int damage;
    public int health;

    private void Start()
    {
         damage = Random.Range(troops.defender.minDamage, troops.defender.maxDamage);
    }
}
