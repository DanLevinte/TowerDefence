using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialFeatures : MonoBehaviour
{
    private void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0F));

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Path") { Debug.Log(hit.collider.name); }
        }

    }
}
