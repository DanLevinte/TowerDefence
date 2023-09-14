using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Defenders : MonoBehaviour, IPointerClickHandler
{
    public KnightManager knightManager;
    public GameObject defenderToBeSpawned;
    public GameObject defenderPos;
    public GameObject areaOfRoam;

    private void Start()
    {
        GameObject go = Instantiate(defenderToBeSpawned, defenderPos.transform.position, Quaternion.identity);
        knightManager = go.GetComponent<KnightManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        areaOfRoam.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DownEnemy"))
        {
            knightManager.target = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("DownEnemy"))
        {
            knightManager.target = null;
        }
    }
}
