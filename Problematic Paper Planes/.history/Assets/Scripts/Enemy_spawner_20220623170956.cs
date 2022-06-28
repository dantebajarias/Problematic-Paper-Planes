using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_spawner : MonoBehaviour
{
    
    public float spawnRadius = 7, time = 1.5f;

    public GameObject[] enemies;
    
    void Start()
    {
        StartCoroutine(SpawnAnEnemy());

    }

    IEnumerator SpawnAnEnemy(){

        Vector2 spawnPos = GameObject.Find("Player").transform.position;
        spawnPos += Random.insideUnitCircle.normalized + 5f* spawnRadius;

        Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(time);
        StartCoroutine(SpawnAnEnemy());
    }
}
