using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public enum EnemyState
{
    isIdle,
    isWalking,
    isHurt,
    isDead,
    isFinished,
    isAttacking,
    NoAction
}

public class EnemyManager : MonoBehaviour
{
    public Rigidbody rb;
    public Path nextPath;
    public Path designatedPos;

    public GameObject target;
    private GameObject killer;

    public int maxHealthPoints;

    public float speed;

    public bool switchColor;

    public List<Path> paths = new List<Path>();

    public EnemyState enemyState;

    [Expandable]
    public Enemy enemy;
    public int currentHealth;

    public Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        paths = PathManager.instance.paths;

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
        if (enemyState == EnemyState.isWalking && nextPath != null && target == null) 
        {
            Vector3 targetPos = new(nextPath.pathPos.x, gameObject.transform.position.y, nextPath.pathPos.z);

            Vector3 pos = new Vector3(nextPath.transform.position.x, gameObject.transform.position.y, nextPath.transform.position.z);
            gameObject.transform.LookAt(pos);       

            if (Vector3.Distance(targetPos, transform.position) == 0) { CleanPath(); }
            else { this.transform.position = Vector3.MoveTowards(transform.position, targetPos, speed); }
        }

        if (enemyState == EnemyState.isWalking && target != null)
        {
            Vector3 targetPos = new(target.transform.position.x, gameObject.transform.position.y, target.transform.position.z);
            this.transform.position = Vector3.MoveTowards(transform.position, targetPos, speed);

            LookAtObject(target);

            if (Vector3.Distance(targetPos, transform.position) <= 1.5f) { enemyState = EnemyState.isAttacking; }
        }

        if (switchColor) { StartCoroutine(SetHurtColor()); }

        if (currentHealth <= 0) { enemyState = EnemyState.isDead; }

        if (enemyState == EnemyState.isDead) { KillEnemy(); }

        if (enemyState == EnemyState.isFinished) { StartCoroutine(SetDyingAnimation()); }

        SetStateAnimation();
    }

    private void LookAtObject(GameObject target)
    {
        Vector3 pos = new Vector3(target.transform.position.x, gameObject.transform.position.y, target.transform.position.z);
        gameObject.transform.LookAt(pos);
    }

    private IEnumerator SetDyingAnimation()
    {
        LookAtObject(killer);

        yield return new WaitForSeconds(2.8f);

        enemyState = EnemyState.NoAction;
        animator.SetBool("isDying", false);
        Destroy(gameObject);
    }

    private void SetStateAnimation()
    {
        switch (enemyState)
        {
            case EnemyState.isWalking:
                SetAnimation(true, false, false);
                break;
            case EnemyState.isAttacking:
                SetAnimation(false, true, false);
                break;
            case EnemyState.isFinished:
                SetAnimation(false, false, true);
                break;
            default:
                break;
        }
    }

    private void SetAnimation(bool isMoving, bool isAttacking, bool isDead)
    {
        animator.SetBool("isMoving", isMoving);
        animator.SetBool("isAttacking", isAttacking);
        animator.SetBool("isDying", isDead);
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

        if (this.target != null) { killer = target; this.target.GetComponent<KnightManager>().target = null; this.target = null; }

        enemyState = EnemyState.isFinished;
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

        if (other.gameObject.CompareTag("Sword"))
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
