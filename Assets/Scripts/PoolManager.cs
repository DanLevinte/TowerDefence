using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public Transform poolStartup;

    public RaidManager raidManager;
    public Raid currentRaid;

    public List<GameObject> enemiesOffPool = new List<GameObject>();
    public List<GameObject> enemiesOnPool = new List<GameObject>();

    public List<Raid> raidList = new List<Raid>();

    public bool updatePool, onValueChange;

    public float timer, spawnRate, raidRest;

    public static PoolManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (currentRaid == null) { currentRaid = raidManager.raidList[0]; }

        if (currentRaid != null)
        {
            for (int i = 0; i <= currentRaid.enemies.Count - 1; i++)
            {
                enemiesOnPool.Add(currentRaid.enemies[i]);
            }
        }

        for (int i = 0; i <= raidManager.raidList.Count - 1; i++)
        {
            raidList.Add(raidManager.raidList[i]);
        }

        UIManager.instance.raidsCurrent = 1;
        UIManager.instance.raidsLimit = raidManager.raidList.Count;
    }

    private void Update()
    {
        if (enemiesOnPool.Count > 0) { timer -= Time.deltaTime; }
        
        if (enemiesOnPool.Count == 0) { raidRest -= Time.deltaTime; UIManager.instance.startRaidButton.SetActive(true); }

        if (enemiesOnPool.Count == 0 && raidRest <= 0 || UIManager.instance.earlyRaid) { SwitchToNextRaid(); UIManager.instance.startRaidButton.SetActive(false); }

        if (timer <= 0 && enemiesOnPool.Count > 0) { CallEnemy(); }

        if (updatePool) { UpdatePool(); }
    }

    private void SwitchToNextRaid()
    {
        UIManager.instance.earlyRaid = false;

        for (int i = 0; i <= raidList.Count - 1; i++)
        {
            if (currentRaid == raidList[i]) { currentRaid = null; raidList.Remove(raidList[i]); }

            if (raidList[i] == raidManager.raidList[raidList.Count]) { break; }

            currentRaid = raidList[i];

            UIManager.instance.raidsCurrent++;
            UIManager.instance.changes = true;

            for (int j = 0; j <= currentRaid.enemies.Count - 1; j++)
            {
                enemiesOnPool.Add(currentRaid.enemies[i]);
            }

            spawnRate--;
            break;
        }

        raidRest = 10;
    }

    private void CallEnemy()
    {
        UIManager.instance.earlyRaid = false;
        if (enemiesOnPool.Count > 0)
        {
            for (int i = 0; i <= enemiesOnPool.Count - 1; i++)
            {
                if (enemiesOnPool[i] != null)
                {
                    onValueChange = true;
                    GameObject go = Instantiate(enemiesOnPool[0], poolStartup.position, Quaternion.identity);
                    enemiesOnPool.Remove(enemiesOnPool[0]);
                    enemiesOffPool.Add(go);
                    timer = spawnRate;
                    break;
                }
            }
        }
    }

    private void UpdatePool()
    {
        for (int i = 0; i <= enemiesOffPool.Count - 1; i++)
        {
            if (enemiesOffPool[i].GetComponent<HostileTroopManager>().currentHealth <= 0) { enemiesOffPool.Remove(enemiesOffPool[i]); }
        }

        updatePool = false;
    }
}
