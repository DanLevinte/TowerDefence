using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerLayoutUI : MonoBehaviour, IPointerExitHandler, IPointerClickHandler
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { Destroy(gameObject); }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(this.gameObject);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //this.gameObject.GetComponent<Image>().raycastTarget = false;
        Destroy(this.gameObject);
        //StartCoroutine(DestroyLayout());
    }

    private IEnumerator DestroyLayout()
    {
        yield return new WaitForSeconds(.2f);
    
        Destroy(gameObject);
    }
}
