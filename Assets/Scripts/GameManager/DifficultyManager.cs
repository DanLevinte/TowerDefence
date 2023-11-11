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

    public GameObject DifficultyUI;

    public GameObject poolManager;
    public GameObject tabManager;
    public GameObject gameInfo;

    public Difficulty difficulty;

    public static DifficultyManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        PoolManager.instance.mobParent.SetActive(false);
        poolManager.gameObject.SetActive(false);
        tabManager.gameObject.SetActive(false);
        gameInfo.SetActive(false);
    }

    private void Update()
    {
        if (setDifficulty) { SetDifficulty(); }
    }

    private void SetDifficulty()
    {
        DifficultyUI.SetActive(false);
        setDifficulty = false;

        UIManager.instance.bankCurrentMoney = this.difficulty.gold;
        UIManager.instance.raidsLimit = this.difficulty.raidManager.raidList.Count;
        UIManager.instance.livesLimit = this.difficulty.lives;
        UIManager.instance.changes = true;

        PoolManager.instance.mobParent.SetActive(true);
        poolManager.gameObject.SetActive(true);
        tabManager.gameObject.SetActive(true);
        gameInfo.SetActive(true);
    }
}
