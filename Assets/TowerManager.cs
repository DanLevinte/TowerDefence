using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerManager : MonoBehaviour, IPointerClickHandler
{
    public GameObject canvas;
    public GameObject buildTowerLayout;

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject go = Instantiate(buildTowerLayout, eventData.delta, Quaternion.identity);
        go.transform.position = eventData.position;
        go.transform.parent = canvas.transform;
    }
}
