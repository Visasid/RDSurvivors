using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private GameObject[] walls;
    [SerializeField] private int obstacleCount;
    private int level = 0;

    private void Start()
    {
        walls[level].SetActive(true);
        for (int i = 0; i < obstacleCount; i++)
        {
            Instantiate(obstacles[level], new Vector2(Random.Range(-38, 38), Random.Range(-28, 28)), Quaternion.identity);
        }
    }
}
