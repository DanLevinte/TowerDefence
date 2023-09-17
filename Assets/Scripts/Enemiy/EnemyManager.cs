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
        this.rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        this.id = Random.Range(0, 900);

        for (int i = 0; i <= PathManager.instance.paths.Count - 1; i++)
        {
            this.paths.Add(PathManager.instance.paths[i]);
        }

        for (int i = 0; i <= paths.Count - 1; i++)
        {
            if (this.nextPath == null) { this.nextPath = paths[i]; }

            if (i == paths.Count - 1) { this.designatedPos = paths[i]; }
        }

        this.enemyState = EnemyState.isWalking;

        this.currentHealth = enemy.health;
    }

    private void Update()
    {
        if (this.enemyState == EnemyState.isWalking && this.nextPath != null && this.target == null) 
        {
            Vector3 targetPos = new(this.nextPath.pathPos.x, this.gameObject.transform.position.y, this.nextPath.pathPos.z);

            Vector3 pos = new Vector3(this.nextPath.transform.position.x, this.gameObject.transform.position.y, this.nextPath.transform.position.z);
            this.gameObject.transform.LookAt(pos);       

            if (Vector3.Distance(targetPos, this.transform.position) == 0) { CleanPath(); }
            else { this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos, speed); }
        }

        if (this.enemyState == EnemyState.isWalking && this.target != null)
        {
            Vector3 targetPos = new(this.target.transform.position.x, this.gameObject.transform.position.y, this.target.transform.position.z);
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos, speed);

            this.LookAtObject(target);

            if (Vector3.Distance(targetPos, this.transform.position) <= 1.5f) { this.enemyState = EnemyState.isAttacking; }
        }

        if (this.switchColor) { this.StartCoroutine(SetHurtColor()); }

        if (this.currentHealth <= 0) { this.enemyState = EnemyState.isDead; }

        if (this.enemyState == EnemyState.isDead) { this.KillEnemy(); }

        if (this.enemyState == EnemyState.isFinished) { this.StartCoroutine(SetDyingAnimation()); }

        this.SetStateAnimation();
    }

    private void LookAtObject(GameObject tg)
    {
        Vector3 pos = new Vector3(tg.transform.position.x, this.gameObject.transform.position.y, tg.transform.position.z);
        this.gameObject.transform.LookAt(pos);
    }

    private IEnumerator SetDyingAnimation()
    {
        this.LookAtObject(this.killer);

        yield return new WaitForSeconds(2.8f);

        this.enemyState = EnemyState.NoAction;
        this.animator.SetBool("isDying", false);
        Destroy(this.gameObject);
    }

    private void SetStateAnimation()
    {
        switch (this.enemyState)
        {
            case EnemyState.isWalking:
                this.SetAnimation(true, false, false);
                break;
            case EnemyState.isAttacking:
                this.SetAnimation(false, true, false);
                break;
            case EnemyState.isFinished:
                this.SetAnimation(false, false, true);
                break;
            default:
                break;
        }
    }

    private void SetAnimation(bool isMoving, bool isAttacking, bool isDead)
    {
        this.animator.SetBool("isMoving", isMoving);
        this.animator.SetBool("isAttacking", isAttacking);
        this.animator.SetBool("isDying", isDead);
    }

    private void CleanPath()
    {
        for (int i = 0; i <= this.paths.Count - 1 ; i++)
        {
            if (this.nextPath == this.paths[i]) { this.paths.Remove(this.paths[i]); this.nextPath = null; break; }
        }

        for (int i = 0; i <= this.paths.Count - 1; i++)
        {
            if (this.nextPath == null) { this.nextPath = this.paths[i]; break; }
        }
    }

    private void KillEnemy()
    {
        int chanceOfGettingMoney = Random.Range(0, this.enemy.chanceOfDroppingGold);

        if (chanceOfGettingMoney <= this.enemy.chanceOfDroppingGold)
        {
            int money = Random.Range(enemy.minValueOfGold, enemy.maxValueOfGold);
            MoneyManager.instance.bank += money;
        }

        if (this.target != null) { this.killer = target; this.target.GetComponent<KnightManager>().target = null; this.target = null; }

        this.enemyState = EnemyState.isFinished;
    }

    private IEnumerator SetHurtColor()
    {
        this.switchColor = false;

        yield return new WaitForSeconds(.25f);

        this.GetComponent<MeshRenderer>().materials[0].color = Color.white;
        this.enemyState = EnemyState.isWalking;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            this.GetComponent<MeshRenderer>().materials[0].color = Color.red;
            this.enemyState = EnemyState.isHurt;
        }

        if (other.gameObject.CompareTag("Sword"))
        {
            this.GetComponent<MeshRenderer>().materials[0].color = Color.red;
            this.enemyState = EnemyState.isHurt;
            Debug.Log(id);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            this.GetComponent<MeshRenderer>().materials[0].color = Color.white;
        }
    }
}
