using NUnit.Framework;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefab; // prefabs dos obstáculos (ex: cacto)
    public float spawnXPosition = 10f; // posição fixa no eixo X pra spawnar
    public float spawnYPosition = -3.2f; // posição fixa no eixo X pra spawnar
    public float minSpawnDelay = 1.5f; // intervalo mínimo entre spawn
    public float maxSpawnDelay = 3f;   // intervalo máximo entre spawn
    public float obstacleSpeedIncreaseVar = 0f;
    public float obstacleSpeed = 5f;
    public int obstacleType;

    private float nextSpawnTime;

    void Start()
    {
        // Define o primeiro spawn para logo
        nextSpawnTime = Time.time + Random.Range(minSpawnDelay, maxSpawnDelay);
    }

    void Update()
    {
        obstacleSpeedIncreaseVar += Time.deltaTime;

        if (Time.time >= nextSpawnTime)
        {
            SpawnObstacle();
            nextSpawnTime = Time.time + Random.Range(minSpawnDelay, maxSpawnDelay);
        }

        if (obstacleSpeedIncreaseVar >= 10f)
        {
            obstacleSpeed++;
            obstacleSpeedIncreaseVar = 0f;
        }
    }

    void SpawnObstacle()
    {
        obstacleType = Random.Range(0, obstaclePrefab.Length);

        if (obstacleType == 0)
        {
            spawnYPosition = -3.2f;
        }
        else
        {
            spawnYPosition = -2.5f;
        }
        Vector3 spawnPos = new Vector3(spawnXPosition, spawnYPosition, 0f); // altura certa do chão
        Instantiate(obstaclePrefab[obstacleType], spawnPos, Quaternion.identity);
    }
}
