using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns enemies at different positionas at cave
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _availablePositionsToSpawn = new();

    private int _amountOfEnemiesOnLevel;

    [SerializeField] private int _minLevelOfEnemyToSpawn = 0;
    [SerializeField] private int _maxLevelOfEnemyToSpawn = 2;

    private void OnEnable()
    {
        _amountOfEnemiesOnLevel = _availablePositionsToSpawn.Count;

        SpawnAllEnemies();
    }

    private void SpawnAllEnemies()
    {
        for (int i = 0; i < _amountOfEnemiesOnLevel; i++)
        {
            SpawnEnemy();
        }
    }

    /// <summary>
    /// Spawn random enemy on available spots
    /// </summary>
    private void SpawnEnemy()
    {
        if(ObjectPooler.SharedInstance == null)
        {
            StartCoroutine(TryAgain());
            return;
        }

        int index = Random.Range(0, Mathf.Clamp(
            ObjectPooler.SharedInstance.pooledObjectsList.Count, 
            _minLevelOfEnemyToSpawn, 
            _maxLevelOfEnemyToSpawn));

        int randomPositionIndex = Random.Range(0, _availablePositionsToSpawn.Count);

        Vector2 randomPosition = _availablePositionsToSpawn[randomPositionIndex].transform.position;

        _availablePositionsToSpawn.Remove(_availablePositionsToSpawn[randomPositionIndex]);

        GameObject enemy = ObjectPooler.SharedInstance.GetPooledObject(index);
        enemy.SetActive(true);
        enemy.transform.position = randomPosition;
    }

    private IEnumerator TryAgain()
    {
        yield return new WaitForSeconds(1f);
        SpawnAllEnemies();
    }
}