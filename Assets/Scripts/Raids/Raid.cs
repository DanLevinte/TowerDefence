using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Raid/Raid")]
public class Raid : ScriptableObject
{
    public List<GameObject> enemies;

    public float spawnRate;
}
