using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class BallistaLayout : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject ballistaPrefab;
    public Image ballistaInfo;

    public TextMeshProUGUI priceText;
    public int price;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (UIManager.instance.bankCurrentMoney >= price)
        {
            this.gameObject.GetComponent<Image>().raycastTarget = false;
            this.gameObject.GetComponentInParent<Image>().raycastTarget = false;

            var parent = this.gameObject.transform.parent.transform;

            GameObject go = Instantiate(ballistaPrefab, parent.position, Quaternion.identity);
            TabManager.instance.tabPoolManager.friendlyDefendersUI.Add(go);
            TabManager.instance.tabPoolManager.addDefenders = true;

            if (TowerManager.instance.towerInUse != null)
            {
                go.transform.SetParent(TowerManager.instance.towerInUse.transform);
                go.transform.localPosition = new Vector3(0, 0, 0);
            }

            TowerManager.instance.towerInUse.spawnedTower = go;
            UIManager.instance.bankCurrentMoney -= price;
            UIManager.instance.changes = true;

            Destroy(gameObject.transform.parent.gameObject);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        priceText.SetText(price.ToString());
        ballistaInfo.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ballistaInfo.gameObject.SetActive(false);
    }
}
