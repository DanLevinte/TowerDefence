using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Raid/Raid Manager")]
public class RaidManager : ScriptableObject
{
    public List<Raid> raidList = new List<Raid>();
}
