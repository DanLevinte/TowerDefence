using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class WizardLayout : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject magePrefab;
    public GameObject mageInfo;

    public TextMeshProUGUI priceText;
    public int price;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (BankManager.instance.currentMoney >= price)
        {
            this.gameObject.GetComponent<Image>().raycastTarget = false;
            this.gameObject.GetComponentInParent<Image>().raycastTarget = false;

            var parent = this.gameObject.transform.parent.transform;

            GameObject go = Instantiate(magePrefab, parent.position, Quaternion.identity);
            TabManager.instance.tabPoolManager.friendlyDefendersUI.Add(go);
            TabManager.instance.tabPoolManager.addDefenders = true;

            if (TowerManager.instance.towerInUse != null)
            {
                go.transform.SetParent(TowerManager.instance.towerInUse.transform);
                go.transform.localPosition = new Vector3(0, 0, 0);
            }

            TowerManager.instance.towerInUse.spawnedTower = go;
            BankManager.instance.currentMoney -= price;

            Destroy(gameObject.transform.parent.gameObject);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        priceText.SetText(price.ToString());
        mageInfo.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mageInfo.gameObject.SetActive(false);
    }
}
