using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public enum EnemyState
{
    isWalking,
    isHurt,
    isDead,
    isFinished,
    isAttacking
}

public class EnemyManager : MonoBehaviour
{
    public Rigidbody rb;

    public Path currentPath;
    public Path nextPath;
    public Path designatedPos;

    public int maxHealthPoints;

    public float speed;

    public bool switchColor;

    public EnemyState enemyState;

    [Expandable]
    public Enemy enemy;
    public int currentHealth;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        var path = PathManager.instance.paths;

        for (int i = 0; i <= path.Count - 1; i++)
        {
            if (nextPath == null) { nextPath = path[i]; }

            if (i == path.Count - 1) { designatedPos = path[i]; }
        }

        enemyState = EnemyState.isWalking;

        currentHealth = enemy.health;
    }

    private void Update()
    {
        if (enemyState == EnemyState.isWalking && nextPath != null) 
        {
            Vector3 targetPos = new(nextPath.pathPos.x, gameObject.transform.position.y, nextPath.pathPos.z);
        
            if (Vector3.Distance(targetPos, transform.position) == 0) { CleanPath(); }
            else { transform.position = Vector3.MoveTowards(transform.position, targetPos, speed); }
        }

        if (switchColor) { StartCoroutine(SetHurtColor()); }

        if (currentHealth <= 0) { enemyState = EnemyState.isDead; }

        if (enemyState == EnemyState.isDead) { KillEnemy(); }

        Collider[] hitCols = Physics.OverlapSphere(transform.position, 1);
        foreach  (Collider hitCol in hitCols)
        {
            Debug.Log(hitCols);
        }
    }

    private void CleanPath()
    {
        var path = PathManager.instance.paths;

        for (int i = 0; i <= path.Count - 1 ; i++)
        {
            if (nextPath == path[i]) { path.Remove(path[i]); nextPath = null; break; }
        }

        for (int i = 0; i <= path.Count - 1; i++)
        {
            if (nextPath == null) { nextPath = path[i]; break; }
        }
    }

    private void KillEnemy()
    {
        int chanceOfGettingMoney = Random.Range(0, enemy.chanceOfDroppingGold);

        if (chanceOfGettingMoney <= enemy.chanceOfDroppingGold)
        {
            int money = Random.Range(enemy.minValueOfGold, enemy.maxValueOfGold);
            MoneyManager.instance.bank += money;
        }

        enemyState = EnemyState.isFinished;

        Destroy(gameObject);
    }

    private IEnumerator SetHurtColor()
    {
        switchColor = false;

        yield return new WaitForSeconds(.25f);

        GetComponent<MeshRenderer>().materials[0].color = Color.white;
        enemyState = EnemyState.isWalking;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            GetComponent<MeshRenderer>().materials[0].color = Color.red;
            enemyState = EnemyState.isHurt;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            GetComponent<MeshRenderer>().materials[0].color = Color.white;
        }
    }
}
