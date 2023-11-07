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

        StrengthManagers.instance.defenderToUpgrade = this.transform.parent.transform.parent.gameObject;
        var mob = GetComponentInParent<MobInfoOnTab>().mob.GetComponent<FriendlyTroopManager>();
        damageText.SetText(string.Empty);
        radiusText.SetText(string.Empty);
        damageText.SetText(mob.damage.ToString());
        radiusText.SetText(mob.radius.ToString());
    }
}
