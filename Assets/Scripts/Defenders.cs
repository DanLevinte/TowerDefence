using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Defenders : MonoBehaviour, IPointerClickHandler
{
    public DefenderManager defenderManager;
    public GameObject defenderToBeSpawned;
    public GameObject defenderPos;
    public GameObject areaOfRoam;

    private void Start()
    {
        GameObject go = Instantiate(defenderToBeSpawned, defenderPos.transform.position, Quaternion.identity);
        this.defenderManager = go.GetComponent<DefenderManager>();
        this.defenderManager.transform.SetParent(this.transform);
    }

    private void Update()
    {
        if (areaOfRoam.activeInHierarchy) { GetComponent<BoxCollider>().enabled = false; }
        else { GetComponent<BoxCollider>().enabled = true; }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        this.areaOfRoam.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DownEnemy"))
        {
            this.defenderManager.target = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("DownEnemy"))
        {
            this.defenderManager.target = null;
        }
    }
}
