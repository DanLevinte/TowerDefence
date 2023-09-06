using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Rigidbody rb;

    public Path currentPos;
    public Path nextPath;
    public Path designatedPos;

    public int maxHealthPoints;
    public int currentHealthPoints;

    public float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        var path = PathManager.instance.paths;

        for (int i = 0; i <= path.Count - 1; i++)
        {
            if (currentPos == null) { currentPos = path[i]; }

            if (nextPath == null && currentPos != path[i]) { nextPath = path[i]; }

            if (i == path.Count - 1) { designatedPos = path[i]; break; }
        }
    }

    private void Update()
    {
        if (nextPath != null) 
        {
            Vector3 targetPos = new(nextPath.pathPos.x, gameObject.transform.position.y, nextPath.pathPos.z);

            if (Vector2.Distance(targetPos, transform.position) == 0) { Debug.Log("D"); CleanPath(); }
            else { transform.position = Vector3.MoveTowards(transform.position, targetPos, speed); }
        }
    }

    private void CleanPath()
    {
        var path = PathManager.instance.paths;

        for (int i = 0; i <= path.Count - 1; i++)
        {
            if (currentPos == path[i]) { path.Remove(path[i]); currentPos = nextPath; break; }
        }

        for (int i = 0; i <= path.Count - 1 ; i++)
        {
            if (i == path.Count - 1) { nextPath = designatedPos; }
            else { nextPath = path[i]; break; }
        }
    }
}
