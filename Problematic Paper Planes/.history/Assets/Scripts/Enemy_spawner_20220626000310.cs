using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_spawner : MonoBehaviour
{
    
    public float spawnRadius = 7, time = 1.5f;

    public GameObject[] enemies;
    
    void Start()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null){
            StartCoroutine(SpawnAnEnemy());
        }
        
    }

    IEnumerator SpawnAnEnemy(){

        Vector2 spawnPos = GameObject.Find("Player").transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius * 2;
        if(GameObject.FindGameObjectsWithTag("Enemy").Length < 25)
        if(GameplayManager.instance.spawn){
            
            if(Random.value < 0.2 && GameplayManager.instance.levelNumber >= 2){
                //Instantiate(enemies[1], spawnPos*2, Quaternion.identity);
            }else{
                Instantiate(enemies[Random.Range(0, enemies.Length-1)], spawnPos, Quaternion.identity);
            }
        }
        yield return new WaitForSeconds(time);
        if(GameObject.FindGameObjectWithTag("Player") != null){
            StartCoroutine(SpawnAnEnemy());
        }
    }
}
