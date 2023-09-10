using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BallistaLayout : MonoBehaviour, IPointerClickHandler
{
    public GameObject ballistaPrefab;

    public void OnPointerClick(PointerEventData eventData)
    {
        this.gameObject.GetComponent<Image>().raycastTarget = false;
        this.gameObject.GetComponentInParent<Image>().raycastTarget = false;

        var parent = this.gameObject.transform.parent.transform;

        GameObject go = Instantiate(ballistaPrefab, parent.position, Quaternion.identity);

        go.transform.SetParent(TowerManager.instance.towerInUse.transform);
        go.transform.localPosition = new Vector3(0, 0, 0);

        TowerManager.instance.towerInUse.spawnedTower = go;

        Destroy(gameObject.transform.parent.gameObject);
    }
}
