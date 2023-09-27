using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAttackingState : State
{
    public KnightRestState knightRestState;

    public float timer = 2;

    public override State RunCurrentState()
    {
        timer -= Time.deltaTime;

        if (timer <= 0) { AttackTarget(); return knightRestState; }

        return this;
    }

    public override string GetStateName()
    {
        return "knight_attack";
    }

    private void AttackTarget()
    {
        var target = this.GetComponentInParent<MobManager>().target.GetComponent<HostileTroopManager>();
        var troop = this.GetComponentInParent<FriendlyTroopManager>();

        target.health -= troop.damage;

        timer = 2;
    }
}
