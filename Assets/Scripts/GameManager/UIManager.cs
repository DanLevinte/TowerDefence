using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI livesText;
    public int livesLimit;

    public TextMeshProUGUI bankMoney;
    public int bankCurrentMoney;

    public TextMeshProUGUI raidsText;
    public int raidsLimit;
    public int raidsCurrent;

    public bool changes = false;

    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        livesText.SetText(livesLimit.ToString());
        bankMoney.SetText(bankCurrentMoney.ToString());
    }

    private void Update()
    {
        if (changes) { MakeUIChanges(); }
    }

    private void MakeUIChanges()
    {
        changes = false;
        bankMoney.SetText(bankCurrentMoney.ToString());
    }
}
