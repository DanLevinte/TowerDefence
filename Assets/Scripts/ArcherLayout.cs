using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ArcherLayout : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject archerPrefab;
    public GameObject archerInfo;

    public void OnPointerClick(PointerEventData eventData)
    {
        this.gameObject.GetComponent<Image>().raycastTarget = false;
        this.gameObject.GetComponentInParent<Image>().raycastTarget = false;

        var parent = this.gameObject.transform.parent.transform;

        GameObject go = Instantiate(archerPrefab, parent.position, Quaternion.identity);

        go.transform.SetParent(TowerManager.instance.towerInUse.transform);
        go.transform.localPosition = new Vector3(0, 0, 0);

        TowerManager.instance.towerInUse.spawnedTower = go;

        Destroy(gameObject.transform.parent.gameObject);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        archerInfo.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        archerInfo.gameObject.SetActive(false);
    }
}
