using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class MobInfoOnTab : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject mob;

    public TextMeshProUGUI nameOfMob;
    public Sprite spriteOfMob;
    public float health;

    public Image imageOfMob;
    public Image healthSprite;

    public Button additionalUpgradeButton;

    public bool onTab;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (mob.GetComponent<HostileTroopManager>() == null) { additionalUpgradeButton.gameObject.SetActive(true); }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        additionalUpgradeButton.gameObject.SetActive(false);
    }
}
