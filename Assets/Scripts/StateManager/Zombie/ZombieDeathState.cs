using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeathState : State
{
    public ZombieStayDeadState zombieStayDeadState;
    public ZombieAttackingState attackingState;

    public float timer = 3;

    public override State RunCurrentState()
    {
        timer -= Time.deltaTime;

        if (timer <= 0) 
        {
            PoolManager.instance.updatePool = true;
            this.GetComponentInParent<MobManager>().canvas.SetActive(false);
            return zombieStayDeadState;
        }

        return this;
    }

    public override string GetStateName()
    {
        return "zombie_Death";
    }
}
