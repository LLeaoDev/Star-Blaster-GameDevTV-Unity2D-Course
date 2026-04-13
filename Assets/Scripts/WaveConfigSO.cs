using System.Runtime.InteropServices.WindowsRuntime;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "WaveConfig", menuName = "New WaveConfig")]
public class WaveConfigSO : ScriptableObject
{   


    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float enemyMoveSpeed = 5f;
    [SerializeField] float timeForEnemies = 5f;
    [SerializeField] float enemySpawnVariation = 1f;
    [SerializeField] float minimunSpawnTime = 0.2f;

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

    public int GetEnemyCount()
    {
        return enemyPrefabs.Length;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeForEnemies - enemySpawnVariation, timeForEnemies + enemySpawnVariation);
        spawnTime = Mathf.Clamp(spawnTime, minimunSpawnTime, float.MaxValue);

        return spawnTime;
    }



}
