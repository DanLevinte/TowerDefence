using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankManager : MonoBehaviour
{
    public int currentMoney;

    public static BankManager instance;

    private void Awake()
    {
        instance = this;
    }
}
