using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloseMobInfo : MonoBehaviour, IPointerExitHandler
{
    public GameObject image;

    public void OnPointerExit(PointerEventData eventData)
    {
        StartCoroutine(SetMobInfoOff());
    }

    private IEnumerator SetMobInfoOff()
    {
        yield return new WaitForSeconds(1);
        image.SetActive(true);
        gameObject.SetActive(false);
    }
}
