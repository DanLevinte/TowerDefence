using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(menuName = "Enemy/EnemyObject")]
public class Enemy : ScriptableObject
{
    public string nameOfEnemy;
    public int health;
    public int speed;

    public bool canDropGold;
    [ShowIf("canDropGold")] public int chanceOfDroppingGold;
    [ShowIf("canDropGold")] public int minValueOfGold;
    [ShowIf("canDropGold")] public int maxValueOfGold;
}
