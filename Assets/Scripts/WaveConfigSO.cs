using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] Transform pathPrefabs;
    [SerializeField] float TimeBetweenEnemySpawns = 1f;
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minimumSpawnTime = 0.2f;


    public Transform GetStartingWaypoint()
    {
        return pathPrefabs.GetChild(0);
    }
    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }
    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }
    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();

        foreach (Transform child in pathPrefabs)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(TimeBetweenEnemySpawns - spawnTimeVariance, TimeBetweenEnemySpawns + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }
}

