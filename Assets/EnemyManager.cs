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
            if (i == path.Count - 1) { designatedPos = path[i]; break; }
        }
    }

    private void Update()
    {
        if (designatedPos.pathPos != Vector3.zero) 
        {
            Vector3 targetPos = new Vector3(designatedPos.pathPos.x, gameObject.transform.position.y, designatedPos.pathPos.z);

            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed);
        }
    }
}
