using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfDifficulty
{
    Easy,
    Medium,
    Hard,
    Null
}

public class DifficultyManager : MonoBehaviour
{
    public TypeOfDifficulty typeOfDifficulty;

    public bool setDifficulty;

    public static DifficultyManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (setDifficulty) { SetDifficulty(); }
    }

    private void SetDifficulty()
    {
        switch (typeOfDifficulty)
        {
            case TypeOfDifficulty.Easy:
                break;
            case TypeOfDifficulty.Medium:
                break;
            case TypeOfDifficulty.Hard:
                break;
        }
    }
}
