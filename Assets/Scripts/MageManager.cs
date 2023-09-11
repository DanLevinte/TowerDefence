using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageManager : MonoBehaviour
{
    public GameObject target;

    public Animator animator;
    private void Update()
    {
        if (target == null) { animator.SetBool("isIdle", true); }
        else 
        { 
            animator.SetBool("isIdle", false);
            Vector3 pos = new Vector3(target.transform.position.x, this.gameObject.transform.position.y, target.transform.position.z);
            gameObject.transform.LookAt(pos);
        }
    }
}
