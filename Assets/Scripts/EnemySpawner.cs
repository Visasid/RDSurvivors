using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject min5Enemy;

    private float spawnRate = 3;

    private float timerS = 0;
    private float timerM = 0;
    private float spawnT = 3;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        timerS += Time.deltaTime;
        spawnT -= Time.deltaTime;

        if (spawnT <= 0)
        {
            spawnT = spawnRate;
            SpawnEnemy(min5Enemy);
        }
        if (timerS >= 60)
        {
            timerM += 1;
            timerS = 0;
            if (timerM > 3 && timerM < 5) spawnRate = 2;
        }
    }

    private void SpawnEnemy(GameObject enemy)
    {
        int a = Random.Range(0, 4);
        switch (a)
        {
            case 0:
                Instantiate(min5Enemy, new Vector2(player.position.x + Random.Range(-7.5f, 7.5f), player.position.y + Random.Range(-4.5f, 4.5f)), Quaternion.identity);
                break;
            case 1:
                Instantiate(min5Enemy, new Vector2(player.position.x + Random.Range(-7.5f, 7.5f), player.position.y + Random.Range(-4.5f, 4.5f)), Quaternion.identity);
                break;
            case 2:
                Instantiate(min5Enemy, new Vector2(player.position.x + Random.Range(-7.5f, 7.5f), player.position.y + Random.Range(-4.5f, 4.5f)), Quaternion.identity);
                break;
            case 3:
                Instantiate(min5Enemy, new Vector2(player.position.x + Random.Range(-7.5f, 7.5f), player.position.y + Random.Range(-4.5f, 4.5f)), Quaternion.identity);
                break;
        }
            
    }
}

