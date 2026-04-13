using UnityEngine;

public class PathFinding : MonoBehaviour
{   
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;
    Transform[] waypoints;
    int waypointIndex = 0;

    [System.Obsolete]
    void Start()
    {
        enemySpawner = FindFirstObjectByType<EnemySpawner>();
        waveConfig = enemySpawner.GetCurrentWAve();
        waypoints = waveConfig.GetWayPoints();
        transform.position = waveConfig.GetStartingWaypoint().position;
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if(waypointIndex < waypoints.Length)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float moveSpeed = waveConfig.GetEnemyMovespeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position,targetPosition,moveSpeed);
            if(transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }


}
