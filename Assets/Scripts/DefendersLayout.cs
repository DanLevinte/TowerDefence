using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class DefendersLayout : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject defenderPrefab;
    public GameObject defenderInfo;

    public TextMeshProUGUI priceText;
    public int price;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (UIManager.instance.bankCurrentMoney >= price)
        {
            this.gameObject.GetComponent<Image>().raycastTarget = false;
            this.gameObject.GetComponentInParent<Image>().raycastTarget = false;

            var parent = this.gameObject.transform.parent.transform;

            GameObject go = Instantiate(defenderPrefab, parent.position, Quaternion.identity);

            if (TowerManager.instance.towerInUse != null)
            {
                go.transform.SetParent(TowerManager.instance.towerInUse.transform);
                go.transform.localPosition = new Vector3(0, 1, 0);
                go.transform.localScale = new Vector3(0.5f, 1, .5f);
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
        defenderInfo.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        defenderInfo.gameObject.SetActive(false);
    }
}
