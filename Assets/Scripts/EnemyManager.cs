using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Rigidbody rb;

    public Path nextPath;
    public Path designatedPos;

    public int maxHealthPoints;
    public int currentHealthPoints;

    public float speed;

    public bool switchColor;

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
    }

    private void Update()
    {
        if (nextPath != null) 
        {
            Vector3 targetPos = new(nextPath.pathPos.x, gameObject.transform.position.y, nextPath.pathPos.z);

            if (Vector3.Distance(targetPos, transform.position) == 0) { CleanPath(); }
            else { transform.position = Vector3.MoveTowards(transform.position, targetPos, speed); }
        }

        if (switchColor) { StartCoroutine(SetHurtColor()); }
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

    private IEnumerator SetHurtColor()
    {
        switchColor = false;

        yield return new WaitForSeconds(.25f);

        GetComponent<MeshRenderer>().materials[0].color = Color.white;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            GetComponent<MeshRenderer>().materials[0].color = Color.red;
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
