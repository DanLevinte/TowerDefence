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
        Debug.Log("Ballista");
        this.gameObject.GetComponent<Image>().raycastTarget = false;
        this.gameObject.GetComponentInParent<Image>().raycastTarget = false;

        var parent = this.gameObject.transform.parent.transform;

        GameObject go = Instantiate(ballistaPrefab, parent.position, Quaternion.identity);

        go.transform.SetParent(TowerManager.instance.towerInUse.transform);
        go.transform.localScale = new Vector3(.5f, 1, .5f);
        go.transform.localPosition = new Vector3(0, 1, 0);

        Destroy(gameObject.transform.parent.gameObject);
    }
}
