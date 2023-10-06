using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject target;
    public int damage;

    private void Update()
    {
        if (this.target != null)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, this.target.transform.position, .01f);
        } else { Destroy(this.gameObject); }
    }
}
