using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BallistaLayout : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Ballista");
        this.gameObject.GetComponent<Image>().raycastTarget = false;
        this.gameObject.GetComponentInParent<Image>().raycastTarget = false;
        Destroy(gameObject.transform.parent.gameObject);
    }
}
