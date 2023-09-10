using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public int bank;

    public static MoneyManager instance;

    private void Awake()
    {
        instance = this;
    }
}
