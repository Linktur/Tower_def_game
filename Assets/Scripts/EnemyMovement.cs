using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform[] path;
    private Transform target;
    private int wavePointIndex;
    private WaveSpawner wave;

    private Enemy enemy;

    public void SetPath(Transform[] _paths)
    {
        path = _paths;
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        target = path[wavePointIndex];
    }
    
    private void Update()
    {
        if (target.position != null)
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(enemy.speed * Time.deltaTime * dir.normalized, Space.World);

            if (Vector3.Distance(transform.position, target.position) <= enemy.minimumDistanceCollision)
            {
                GetNextWaypoint();
                FaceTarget();
            }

            enemy.speed = enemy.startSpeed;
        }
    }

    private void GetNextWaypoint()
    {
        if (wavePointIndex >= path.Length - 1)
        {
            EndPath();
            return;
        }

        wavePointIndex++;
        target = path[wavePointIndex];
    }

    void EndPath()
    {
        --PlayerStats.Lives;
        --WaveSpawner.EnemiesAlive;
        Destroy(gameObject);
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Euler(0f, lookRotation.eulerAngles.y, 0f);
    }
}
