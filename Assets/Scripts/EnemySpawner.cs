using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject slime;
    [SerializeField] private GameObject skull;
    [SerializeField] private TMP_Text timerUI;

    private float spawnRate = 2;
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
            SpawnEnemy(slime);
            if (timerM >= 1) SpawnEnemy(skull);
        }
        if (timerS >= 60)
        {
            timerM += 1;
            timerS = 0;
            if (timerM > 3 && timerM < 5) spawnRate = 2;
        }

        timerUI.text = timerM.ToString("00") + ':' + ((int)timerS).ToString("00");
    }

    private void SpawnEnemy(GameObject enemy)
    {
        int a = Random.Range(0, 4);
        switch (a)
        {
            case 0:
                Instantiate(enemy, new Vector2(player.position.x - 7.5f, player.position.y + Random.Range(-4.5f, 4.5f)), Quaternion.identity);
                break;
            case 1:
                Instantiate(enemy, new Vector2(player.position.x + 7.5f, player.position.y + Random.Range(-4.5f, 4.5f)), Quaternion.identity);
                break;
            case 2:
                Instantiate(enemy, new Vector2(player.position.x + Random.Range(-7.5f, 7.5f), player.position.y + 4.5f), Quaternion.identity);
                break;
            case 3:
                Instantiate(enemy, new Vector2(player.position.x + Random.Range(-7.5f, 7.5f), player.position.y - 4.5f), Quaternion.identity);
                break;
        }
            
    }
}

