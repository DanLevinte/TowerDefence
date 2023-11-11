using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Difficulty/Difficulty")]
public class Difficulty : ScriptableObject
{
    public TypeOfDifficulty typeOfDifficulty;
    public int gold;
    public int lives;

    public RaidManager raidManager;
}
