using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject target;

    private void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, .01f);
        }
    }
}
