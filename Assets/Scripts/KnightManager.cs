using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KnightStates
{
    IsIdle,
    IsWaiting,
    IsFollowing,
    IsRetreating,
    IsHurting,
    IsAttacking,
    isDying
}

public class KnightManager : MonoBehaviour
{
    public Path pathToDefend;
    public GameObject target;

    public KnightStates knightStates;

    public List<Path> defendablePaths = new List<Path>();

    public Animator animator;

    private void Start()
    {
        knightStates = KnightStates.IsIdle;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && TowerManager.instance.pathToManage != null)
        {
            pathToDefend = TowerManager.instance.pathToManage;
        }

        if (pathToDefend != null && knightStates == KnightStates.IsIdle)
        {
            knightStates = KnightStates.IsFollowing;
        }

        if (knightStates == KnightStates.IsFollowing) 
        {
            animator.SetBool("isMoving", true);
            transform.position = Vector3.MoveTowards(transform.position, pathToDefend.pathPos, .01f);

            Vector3 pos = new Vector3(pathToDefend.transform.position.x, this.gameObject.transform.position.y, pathToDefend.transform.position.z);
            gameObject.transform.LookAt(pos);

            if (Vector3.Distance(transform.position, pathToDefend.pathPos) <= .1f) { animator.SetBool("isMoving", false); }
        }
    }
}
