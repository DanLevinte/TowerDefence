using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerLayoutUI : MonoBehaviour, IPointerExitHandler
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { Destroy(gameObject); }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(gameObject);
    }
}
