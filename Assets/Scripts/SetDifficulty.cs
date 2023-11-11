using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SetDifficulty : MonoBehaviour, IPointerClickHandler
{
    public Difficulty difficulty;

    public void OnPointerClick(PointerEventData eventData)
    {
        DifficultyManager.instance.typeOfDifficulty = this.difficulty.typeOfDifficulty;
        DifficultyManager.instance.setDifficulty = true;
        DifficultyManager.instance.difficulty = this.difficulty;
    }
}
