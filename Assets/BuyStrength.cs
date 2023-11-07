using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public enum Strength
{
    Radius,
    Damage
}

public class BuyStrength : MonoBehaviour, IPointerClickHandler
{
    public TextMeshProUGUI priceText;
    public TextMeshProUGUI strengthText;
    public int price;

    public Strength strength;

    public void OnPointerClick(PointerEventData eventData)
    {
       if (UIManager.instance.bankCurrentMoney >= price)
       {
            UIManager.instance.bankCurrentMoney -= price;
            StrengthManagers.instance.strengthButton = this.gameObject;
            StrengthManagers.instance.canUpgrade = true;
            price *= 2;
            priceText.SetText(price.ToString());

            int strength = int.Parse(strengthText.text);

            strengthText.SetText(((strength += 1).ToString()));
       }
    }
}
