using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SetDifficulty : MonoBehaviour, IPointerClickHandler
{
    public TypeOfDifficulty typeOfDifficulty;

    public void OnPointerClick(PointerEventData eventData)
    {
        DifficultyManager.instance.typeOfDifficulty = this.typeOfDifficulty;
        DifficultyManager.instance.setDifficulty = true;
    }
}
