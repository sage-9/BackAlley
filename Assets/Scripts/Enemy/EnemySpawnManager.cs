using Managers;
using UnityEngine;
using UnityEngine.Serialization;


public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private Transform leftSpawnPoint;
    [SerializeField] private Transform rightSpawnPoint;
    [SerializeField] private GameObject enemy;
    [SerializeField]private float enemySpawnRate;
    //[SerializeField] private float maxEnemySpawnTime, minEnemySpawnTime;

    private Transform _currentSpawnPoint;
    
    void Awake()
    {
        GameSceneManager.Play += StartSpawning;
        GameSceneManager.Pause += StopSpawning;
        GameSceneManager.GameOver += StopSpawning;
    }

    private void OnDisable()
    {
        GameSceneManager.Play -= StartSpawning;
        GameSceneManager.Pause -= StopSpawning;
        GameSceneManager.GameOver -= StopSpawning;
    }

    void StartSpawning()
    {
        InvokeRepeating(nameof(Spawn), 0, enemySpawnRate);
    }

    void StopSpawning()
    {
        CancelInvoke(nameof(Spawn));
    }

    void Spawn()
    {
        bool result = Random.Range(0, 2) == 1;
        Debug.Log($"the side picked was : {result}");
        _currentSpawnPoint = result ?rightSpawnPoint:leftSpawnPoint;
        Instantiate(enemy, _currentSpawnPoint.position, _currentSpawnPoint.rotation);

    }
    
    
}

