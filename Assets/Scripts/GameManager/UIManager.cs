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

    public bool changes = false, earlyRaid;

    public GameObject startRaidButton;

    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        MakeUIChanges();
    }

    private void Update()
    {
        if (changes) { MakeUIChanges(); }
    }

    private void MakeUIChanges()
    {
        changes = false;
        bankMoney.SetText(bankCurrentMoney.ToString());
        livesText.SetText(livesLimit.ToString());
        raidsText.SetText(raidsCurrent.ToString() + "/" + raidsLimit.ToString());
    }

    public void StartEarlyRaid()
    {
        earlyRaid = true;
    }
}
