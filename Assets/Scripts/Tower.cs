using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tower : MonoBehaviour, IPointerClickHandler
{
    public GameObject canvas;
    public GameObject buildTowerLayout;

    public GameObject spawnedTower;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (spawnedTower == null)
        {
            GameObject go = Instantiate(buildTowerLayout, eventData.delta, Quaternion.identity);
            go.transform.position = eventData.position;
            go.transform.SetParent(canvas.transform);
            TowerManager.instance.towerInUse = this;
        }
    }
}
