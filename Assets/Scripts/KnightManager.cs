using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KnightStates
{
    IsIdle,
    IsPursuing,
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

            if (target == null && pathToDefend !=  null)
            {
                //Vector3 path = new Vector3(pathToDefend.pathPos.x, transform.position.y, pathToDefend.pathPos.z);
                //transform.position = Vector3.MoveTowards(transform.position, path, .01f);
                //
                //Vector3 pos = new Vector3(pathToDefend.transform.position.x, gameObject.transform.position.y, pathToDefend.transform.position.z);
                //gameObject.transform.LookAt(pos);

                if (Vector3.Distance(transform.position, pathToDefend.pathPos) <= 1f) { animator.SetBool("isMoving", false); }
            }
            if (target != null)
            {
                //Vector3 targetPos = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
                //transform.position = Vector3.MoveTowards(transform.position, targetPos, .01f);
                //
                //Vector3 targetRot = new Vector3(target.transform.position.x, gameObject.transform.position.y, target.transform.position.z);
                //this.gameObject.transform.LookAt(targetRot);
                
                KnightFollow(target);

                if (Vector3.Distance(transform.position, target.transform.position) <= 1.75f) { animator.SetBool("isMoving", false); knightStates = KnightStates.IsAttacking; }
            }
        }

        if (knightStates == KnightStates.IsAttacking) { animator.SetBool("isAttacking", true); }

        if (target != null && knightStates != KnightStates.IsAttacking) { knightStates = KnightStates.IsFollowing; }
    }

    private void KnightFollow(GameObject pos)
    {
        Vector3 targetMove = new Vector3(pos.transform.position.x, transform.position.y, pos.transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetMove, .01f);

        Vector3 targetLook = new Vector3(pos.transform.position.x, gameObject.transform.position.y, pos.transform.position.z);
        gameObject.transform.LookAt(targetLook);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DownEnemy") && target == null) { target = other.gameObject; }
    }
}
