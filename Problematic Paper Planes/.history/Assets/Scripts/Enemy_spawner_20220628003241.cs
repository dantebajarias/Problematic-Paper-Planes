using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_spawner : MonoBehaviour
{
    
    public float spawnRadius = 7, time = 1.5f;

    public GameObject[] enemies;
    
    void Start()
    {
        //If Player exists then spawn enemy
        if(GameObject.FindGameObjectWithTag("Player") != null){
            StartCoroutine(SpawnAnEnemy());
        }
    }

    IEnumerator SpawnAnEnemy(){
        //Spawn enemies offscreen around player
        Vector2 spawnPos = GameObject.Find("Player").transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius * 2;
        //Restrict spawning to a max of 25
        if(GameObject.FindGameObjectsWithTag("Enemy").Length < 25)
        //Set spawning for different levelNumbers
        if(GameplayManager.instance.spawn){
            if(Random.value < 0.0001 && GameplayManager.instance.levelNumber == 1){ //Level 1 - Some monsters spawn, mostly demons
                if(GameObject.Find("Monster_Enemy").Length < 3)
                    Instantiate(enemies[1], spawnPos, Quaternion.identity);
            }else if(GameplayManager.instance.levelNumber == 2){ //Level 2 - Only monsters spawn
                Instantiate(enemies[1], spawnPos, Quaternion.identity);
            }else if(Random.value < 0.5 && GameplayManager.instance.levelNumber == 3){ //Level 3 - Both monsters and demons spawn
                Instantiate(enemies[1], spawnPos, Quaternion.identity);
            }else if(GameplayManager.instance.levelNumber == 4){ //Level 4 - Only jets spawn
                Instantiate(enemies[2], spawnPos, Quaternion.identity);
            }else if(Random.value < 0.4 && GameplayManager.instance.levelNumber >= 5){ //Level 5 - Everything spawns 
                Instantiate(enemies[2], spawnPos, Quaternion.identity);
            }else if(GameplayManager.instance.levelNumber == 0){ //Level 0 Only demons spawn
                Instantiate(enemies[0], spawnPos, Quaternion.identity);
            }else{
                Instantiate(enemies[Random.Range(0, enemies.Length-1)], spawnPos, Quaternion.identity); //Default enemy spawn
            }
        }
        yield return new WaitForSeconds(time);
        if(GameObject.FindGameObjectWithTag("Player") != null){
            StartCoroutine(SpawnAnEnemy());
        }
    }
}
