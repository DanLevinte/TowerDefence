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

    public GameObject loseText;
    public GameObject winText;

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

        if (livesLimit <= 0) { ShowText(loseText); }

        if (raidsCurrent == raidsLimit && PoolManager.instance.enemiesOnPool.Count == 0 && livesLimit > 0) 
        { CheckIfTargetsAreDead(); }
    }

    private void CheckIfTargetsAreDead()
    {
        GameObject tg = null;

        for (int i = 0; i <= PoolManager.instance.enemiesOffPool.Count - 1; i++)
        {
            if (PoolManager.instance.enemiesOffPool[i].GetComponent<HostileTroopManager>().currentHealth > 0) { break; }
            else { tg = PoolManager.instance.enemiesOffPool[i]; }
        }

        if (tg != null) { ShowText(winText); Debug.Log("ss"); }
    }

    private void ShowText(GameObject text)
    {
        text.SetActive(true);
        DifficultyManager.instance.poolManager.gameObject.SetActive(false);
        DifficultyManager.instance.tabManager.gameObject.SetActive(false);
        DifficultyManager.instance.gameInfo.SetActive(false);
        PoolManager.instance.mobParent.SetActive(false);
        startRaidButton.SetActive(false);
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
        if (PoolManager.instance.raidList.Count > 0) { earlyRaid = true; }
        else { startRaidButton.SetActive(false); }
    }
}
