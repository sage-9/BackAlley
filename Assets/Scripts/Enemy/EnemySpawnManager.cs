using Managers;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints = new Transform[2];
    [SerializeField] private GameObject enemy;


    void Start()
    {
        GameManager.OnGameStateChanged += StartSpawning;
        GameManager.OnGameStateChanged += StopSpawning;
    }

    void StartSpawning(GameState state)
    {
        if (state == GameState.Play) InvokeRepeating(nameof(Spawn), 0, 1);
    }

    void StopSpawning(GameState state)
    {
        if (state == GameState.GameOver) CancelInvoke(nameof(Spawn));
    }
    
    public void Spawn()
    {
        int num = Random.Range(0,spawnPoints.Length);
        Instantiate(enemy, spawnPoints[num].position, spawnPoints[num].rotation);
    }
}
