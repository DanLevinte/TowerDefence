using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAttackingState : State
{
    public KnightRestState knightRestState;
    public KnightIdleState knightIdleState;

    public bool returnToIdleState;

    public float timer = 2;

    public override State RunCurrentState()
    {
        timer -= Time.deltaTime;

        if (timer <= 0) { AttackTarget(); return knightRestState; }

        if (returnToIdleState) { returnToIdleState = false; return knightIdleState; }

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

        if (target.health >= 0)
        {
            target.health -= troop.damage;
        } else
        {
            this.gameObject.GetComponentInParent<MobManager>().target.GetComponent<MobManager>().target = null;
            this.gameObject.GetComponentInParent<MobManager>().target = null;
            returnToIdleState = true;
            knightIdleState.movingState.attack = false;
        }

        timer = 2;
    }
}
