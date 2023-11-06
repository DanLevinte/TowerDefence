using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfDifficulty
{
    Easy,
    Medium,
    Hard
}

public class DifficultyManager : MonoBehaviour
{
    public TypeOfDifficulty typeOfDifficulty;

    public static DifficultyManager instance;

    private void Awake()
    {
        instance = this;
    }
}
