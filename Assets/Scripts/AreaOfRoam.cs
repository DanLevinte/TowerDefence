using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AreaOfRoam : MonoBehaviour, IPointerExitHandler
{
    private void Start()
    {
        Invoke("SetColOff", .1f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { gameObject.SetActive(false); }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Path"))
        {
            GetComponentInParent<Defenders>().defenderManager.defendablePaths.Add(other.GetComponent<Path>());
            other.GetComponent<Path>().canAct = true;
        }
    }

    private void SetColOff()
    {
        GetComponent<BoxCollider>().enabled = false;
    }
}
