using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public Transform poolStartup;

    public List<GameObject> enemiesOnPool = new List<GameObject>();

    public List<GameObject> enemiesOffPool = new List<GameObject>();
    public bool updatePool, onValueChange;

    public float timer;
    public float spawnRate;

    public static PoolManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (enemiesOnPool != null) { timer -= Time.deltaTime; }

        if (timer <= 0) { CallEnemy(); }

        if (updatePool) { UpdatePool(); }
    }

    private void CallEnemy()
    {
        if (enemiesOnPool != null)
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
