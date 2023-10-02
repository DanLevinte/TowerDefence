using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightIdleState : State
{
    public DefenderManager defenderManager;

    public KnightMovingState movingState;

    public List<Path> defendablePaths = new List<Path>();

    public LayerMask targetMask;

    public GameObject basePos;

    public float targetRadius = Mathf.Infinity;

    private void Start()
    {
        this.basePos = this.GetComponentInParent<Defenders>().defenderPos;
    }

    public override State RunCurrentState()
    {
        if (ShouldBeMoving()) { movingState.pathToMoveTo = GetComponentInParent<DefenderManager>().pathToDefend; return movingState; }

        if (movingState.mobManager.target == null) { CheckForTargets(); }

        if (movingState.mobManager.target != null) { return movingState; }

        return this;
    }

    public override string GetStateName()
    {
        return "knight_idle";
    }

    private bool ShouldBeMoving()
    {
        if (defenderManager.pathToDefend != null && Vector3.Distance(movingState.mobManager.transform.position, defenderManager.pathToDefend.pathPos) >= 1f)
        { return true; }
        else { return false; }
    }

    public void CheckForTargets()
    {
        var detections = Physics.OverlapSphere(movingState.mobManager.mob.transform.position, 6, targetMask);

        if (detections.Length != 0)
        {
            for (int i = 0; i <= detections.Length - 1; i++)
            {
                float dist = (this.transform.position - detections[i].transform.position).magnitude;

                if (dist <= 6 && detections[i].GetComponent<HostileTroopManager>().currentHealth >= 0 && detections[i].tag == "DownEnemy")
                {
                    if (detections[i].transform.position.magnitude < targetRadius)
                    {
                        this.movingState.mobManager.target = detections[i].gameObject;
                        Debug.Log(detections[i].name);
                        break;
                    }
                }
            }
        }
    }
}
