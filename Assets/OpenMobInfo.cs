using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class OpenMobInfo : MonoBehaviour, IPointerClickHandler
{
    public GameObject mobInfo;
    public GameObject mobPhoto;

    public TextMeshProUGUI damageText;
    public TextMeshProUGUI radiusText;

    public void OnPointerClick(PointerEventData evenetData)
    {
        mobInfo.SetActive(true);
        mobPhoto.SetActive(false);

        var mob = GetComponentInParent<MobInfoOnTab>().mob.GetComponent<FriendlyTroopManager>();
        damageText.SetText(string.Empty);
        radiusText.SetText(string.Empty);
        damageText.SetText(damageText.text + mob.damage.ToString());
        radiusText.SetText(radiusText.text + mob.radius.ToString());
    }
}
