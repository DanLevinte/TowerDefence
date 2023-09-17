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

    public float id;

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
        id = Random.Range(0, 900);

        for (int i = 0; i <= PathManager.instance.paths.Count - 1; i++)
        {
            paths.Add(PathManager.instance.paths[i]);
        }

        for (int i = 0; i <= paths.Count - 1; i++)
        {
            if (nextPath == null) { nextPath = paths[i]; }

            if (i == paths.Count - 1) { designatedPos = paths[i]; }
        }

        enemyState = EnemyState.isWalking;

        currentHealth = enemy.health;
    }

    private void Update()
    {
        if (enemyState == EnemyState.isWalking && nextPath != null && target == null) 
        {
            Vector3 targetPos = new(this.nextPath.pathPos.x, this.gameObject.transform.position.y, this.nextPath.pathPos.z);

            Vector3 pos = new Vector3(this.nextPath.transform.position.x, this.gameObject.transform.position.y, this.nextPath.transform.position.z);
            this.gameObject.transform.LookAt(pos);       

            if (Vector3.Distance(targetPos, this.transform.position) == 0) { CleanPath(); Debug.Log(id); }
            else { this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos, speed); }
        }

        if (this.enemyState == EnemyState.isWalking && this.target != null)
        {
            Vector3 targetPos = new(this.target.transform.position.x, this.gameObject.transform.position.y, this.target.transform.position.z);
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos, speed);

            LookAtObject(target);

            if (Vector3.Distance(targetPos, this.transform.position) <= 1.5f) { this.enemyState = EnemyState.isAttacking; }
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
        for (int i = 0; i <= paths.Count - 1 ; i++)
        {
            if (this.nextPath == this.paths[i]) { this.paths.Remove(this.paths[i]); this.nextPath = null; break; }
        }

        for (int i = 0; i <= this.paths.Count - 1; i++)
        {
            if (this.nextPath == null) { nextPath = this.paths[i]; break; }
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
