using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightIdleState : State
{
    public DefenderManager defenderManager;

    public KnightMovingState movingState;

    public List<Path> defendablePaths = new List<Path>();

    public LayerMask targetMask;

    public float targetRadius;

    public bool isTargetInRange;

    public GameObject target;

    public override State RunCurrentState()
    {
        if (ShouldBeMoving()) { movingState.pathToMoveTo = GetComponentInParent<DefenderManager>().pathToDefend; return movingState; }

        if (MobManager.instance.target != null) { Debug.Log("s"); }

        return this;
    }

    public override string GetStateName()
    {
        return "knight_idle";
    }

    private bool ShouldBeMoving()
    {
        if (defenderManager.pathToDefend != null && Vector3.Distance(MobManager.instance.mob.transform.position, defenderManager.pathToDefend.pathPos) >= 1f)
        { return true; }
        else { return false; }
    }

    public void CheckForTargets()
    {
        var detections = Physics.OverlapSphere(MobManager.instance.mob.transform.position, 3, targetMask);

        if (detections.Length != 0)
        {
            for (int i = 0; i <= detections.Length - 1; i++)
            {
                float dist = (transform.position - detections[i].transform.position).magnitude;

                if (dist <= 3)
                {
                    if (detections[i].transform.position.magnitude < targetRadius)
                    {
                        MobManager.instance.target = detections[i].gameObject;
                        isTargetInRange = true;
                        Debug.Log(detections[i].name);
                        break;
                    }
                }
            }
        }
    }
}
