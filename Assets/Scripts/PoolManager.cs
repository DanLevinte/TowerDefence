using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public Transform poolStartup;

    public List<GameObject> enemiesOnPool = new List<GameObject>();

    public float timer;

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0) { CallEnemy(); }
    }

    private void CallEnemy()
    {
        if (enemiesOnPool != null)
        {
            for (int i = 0; i <= enemiesOnPool.Count - 1; i++)
            {
                if (enemiesOnPool[i] != null)
                {
                    GameObject go = Instantiate(enemiesOnPool[0], poolStartup.position, Quaternion.identity);
                    enemiesOnPool.Remove(enemiesOnPool[0]);
                    timer = 2;
                    break;
                }
            }
        }
    }
}
