using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenMobInfo : MonoBehaviour, IPointerClickHandler
{
    public GameObject mobInfo;
    public GameObject mobPhoto;

    public void OnPointerClick(PointerEventData evenetData)
    {
        mobInfo.SetActive(true);
        mobPhoto.SetActive(false);
    }
}
