using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum ShowHide
{
    Show,
    Hide
}

public enum BarType
{
    Enemies,
    Friendly
}



public class ShowMobBar : MonoBehaviour, IPointerClickHandler
{
    public RectTransform mobBar;
    public ShowHide showHide;
    public BarType barType;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (barType == BarType.Enemies)
        {
            if (showHide == ShowHide.Show)
            {
                mobBar.anchoredPosition = new Vector2(150, 0);
                GetComponentInParent<MobBarButtonController>().hiddenButton.SetActive(true);
                this.gameObject.SetActive(false);
            }
            else
            {
                mobBar.anchoredPosition = new Vector2(150, -150);
                GetComponentInParent<MobBarButtonController>().shownButton.SetActive(true);
                this.gameObject.SetActive(false);
            }
        } else
        {
            if (showHide == ShowHide.Show)
            {
                mobBar.anchoredPosition = new Vector2(-150, 0);
                GetComponentInParent<MobBarButtonController>().hiddenButton.SetActive(true);
                this.gameObject.SetActive(false);
            }
            else
            {
                mobBar.anchoredPosition = new Vector2(-150, -150);
                GetComponentInParent<MobBarButtonController>().shownButton.SetActive(true);
                this.gameObject.SetActive(false);
            }
        }
    }
}
