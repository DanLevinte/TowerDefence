using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabPoolManager : MonoBehaviour
{
    public List<GameObject> poolEnemyMobsUI = new List<GameObject>();
    public List<GameObject> tabPool;

    public List<GameObject> friendlyDefendersUI = new List<GameObject>();

    public bool updateEnemyHealthbars;
    public bool addDefenders;

    TabManager tabManager;

    private GameObject defender;

    private void Awake()
    {
        tabManager = GetComponent<TabManager>();
    }

    private void Start()
    {
        poolEnemyMobsUI = PoolManager.instance.enemiesOffPool;
    }

    private void Update()
    {
        if (PoolManager.instance.onValueChange) { UpdateEnemyTabPool(); }

        if (updateEnemyHealthbars) { UpdateEnemyHealthbars(); }

        if (addDefenders) { AddDefendersToBar(); }
    }

    private void AddDefendersToBar()
    {
        addDefenders = false;

        for (int i = 0; i <= friendlyDefendersUI.Count - 1; i++)
        {
            if (!friendlyDefendersUI[i].GetComponent<MobManager>().onUI)
            {
                friendlyDefendersUI[i].GetComponent<MobManager>().onUI = true;
                GameObject go = Instantiate(tabManager.mobPrefab, tabManager.friendlyContainer.transform.position, Quaternion.identity);
                go.transform.SetParent(tabManager.friendlyContainer.transform);
                go.transform.localScale = new Vector3(1, 1, 1);
                tabPool.Add(go);
                defender = go;

                StartCoroutine(SetText(i));
            }
        }
    }

    private IEnumerator SetText(int i)
    {
        yield return new WaitForSeconds(.1f);

        var mobOnUI = defender.GetComponent<MobInfoOnTab>();

        mobOnUI.mob = friendlyDefendersUI[i];

        var mobOnMap = mobOnUI.mob.GetComponent<MobManager>();

        mobOnUI.spriteOfMob = mobOnMap.spriteOfMob;

        defender.GetComponent<MobInfoOnTab>().imageOfMob.sprite = mobOnUI.spriteOfMob;

        mobOnUI.nameOfMob.SetText(mobOnUI.mob.GetComponent<FriendlyTroopManager>().nameOfTroop);
    }

    private void UpdateEnemyHealthbars()
    {
        for (int i = 0; i <= tabPool.Count - 1; i++)
        {
            var mobUI = tabPool[i].GetComponent<MobInfoOnTab>();
            var mobHostile = mobUI.mob.GetComponent<HostileTroopManager>();

            switch (mobUI.mob.GetComponent<MobManager>().typeOfTroop)
            {
                case TypeOfTroop.Hostile:
                    mobUI.healthSprite.fillAmount = mobHostile.currentHealth / mobHostile.maxHealth;
                    Debug.Log(mobHostile);
                    break;
                case TypeOfTroop.Friendly:
                    break;
                case TypeOfTroop.Tower:
                    break;
                default:
                    break;
            }

            if (mobUI.healthSprite.fillAmount == 0)
            {
                Destroy(tabPool[i].gameObject);
                tabPool.Remove(tabPool[i]);
            }
        }

        updateEnemyHealthbars = false;
    }

    private void UpdateEnemyTabPool()
    {
        for (int i = 0; i <= poolEnemyMobsUI.Count - 1; i++)
        {
            if (!tabPool.Contains(poolEnemyMobsUI[i]) && !poolEnemyMobsUI[i].GetComponent<MobManager>().onUI)
            {
                poolEnemyMobsUI[i].GetComponent<MobManager>().onUI = true;
                GameObject go = Instantiate(tabManager.mobPrefab, tabManager.foeContainer.transform.position, Quaternion.identity);
                go.transform.SetParent(tabManager.foeContainer.transform);
                go.transform.localScale = new Vector3(1, 1, 1);
                tabPool.Add(go);

                var mobOnUI = go.GetComponent<MobInfoOnTab>();

                mobOnUI.mob = poolEnemyMobsUI[i];

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
            } else { continue; }
        }

        PoolManager.instance.onValueChange = false;
    }
}
