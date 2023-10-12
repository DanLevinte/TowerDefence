using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabPoolManager : MonoBehaviour
{
    public List<GameObject> poolMobsUI = new List<GameObject>();
    public List<GameObject> tabPool;

    TabManager tabManager;

    private void Awake()
    {
        tabManager = GetComponent<TabManager>();
    }

    private void Start()
    {
        poolMobsUI = PoolManager.instance.enemiesOffPool;
    }

    private void Update()
    {
        if (PoolManager.instance.onValueChange) { UpdateTabPool(); }
    }

    private void UpdateTabPool()
    {
        for (int i = 0; i <= poolMobsUI.Count - 1; i++)
        {
            if (!tabPool.Contains(poolMobsUI[i]) && !poolMobsUI[i].GetComponent<MobManager>().onUI)
            {
                Debug.Log("in");
                poolMobsUI[i].GetComponent<MobManager>().onUI = true;
                GameObject go = Instantiate(tabManager.mobPrefab, tabManager.container.transform.position, Quaternion.identity);
                go.transform.SetParent(tabManager.container.transform);
                go.transform.localScale = new Vector3(1, 1, 1);
                tabPool.Add(go);

                var mobOnUI = go.GetComponent<MobInfoOnTab>();

                mobOnUI.mob = poolMobsUI[i];

                var mobOnMap = mobOnUI.mob.GetComponent<MobManager>();

                switch (mobOnMap.typeOfTroop)
                {
                    case TypeOfTroop.Hostile:

                        mobOnUI.spriteOfMob = mobOnMap.spriteOfMob;

                        var mobHostile = mobOnUI.mob.GetComponent<HostileTroopManager>();

                        mobOnUI.nameOfMob.SetText(mobHostile.nameOfHostile);
                        mobOnUI.health = mobHostile.currentHealth;
                        break;
                    case TypeOfTroop.Friendly:
                        break;
                    case TypeOfTroop.Tower:
                        break;
                    default:
                        break;
                }
            } else { Debug.Log("off"); continue; }
        }

        PoolManager.instance.onValueChange = false;
    }
}
