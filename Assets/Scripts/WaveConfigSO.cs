using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfig", menuName = "New WaveConfig")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] Transform pathPrefab;
    [SerializeField] float enemyMoveSpeed = 5;

    public Transform GetStartingWaypoint()
    {
        return pathPrefab.GetChild(0);
    }

    public float GetEnemyMovespeed()
    {
        return enemyMoveSpeed;
    }

    public Transform[] GetWayPoints()
    {
        Transform[] waypoints = new Transform[pathPrefab.childCount];
        for(int i = 0; i < pathPrefab.childCount; i++)
        {
            waypoints[i] = pathPrefab.GetChild(i);
        }

        return waypoints;
    }
}
