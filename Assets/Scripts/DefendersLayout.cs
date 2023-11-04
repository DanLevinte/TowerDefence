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
        if (BankManager.instance.currentMoney >= price)
        {
            this.gameObject.GetComponent<Image>().raycastTarget = false;
            this.gameObject.GetComponentInParent<Image>().raycastTarget = false;

            var parent = this.gameObject.transform.parent.transform;

            GameObject go = Instantiate(defenderPrefab, parent.position, Quaternion.identity);

            for (int i = 0; i <= go.transform.childCount - 1; i++)
            {
                if (go.transform.GetChild(i).GetComponent<MobManager>() != null)
                {
                    TabManager.instance.tabPoolManager.friendlyDefendersUI.Add(go.transform.GetChild(i).gameObject);
                    TabManager.instance.tabPoolManager.addDefenders = true;
                    break;
                }
            }

            if (TowerManager.instance.towerInUse != null)
            {
                go.transform.SetParent(TowerManager.instance.towerInUse.transform);
                go.transform.localPosition = new Vector3(0, 1, 0);
                go.transform.localScale = new Vector3(0.5f, 1, .5f);
            }

            TowerManager.instance.towerInUse.spawnedTower = go;
            BankManager.instance.currentMoney -= price;

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
