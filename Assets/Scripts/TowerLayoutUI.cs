using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerLayoutUI : MonoBehaviour, IPointerExitHandler, IPointerClickHandler
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { Destroy(gameObject); }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TowerManager.instance.towerInUse = null;
        Destroy(this.gameObject);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        TowerManager.instance.towerInUse = null;
        Destroy(this.gameObject);
    }
}
