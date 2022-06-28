using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;

    private int score;

    public int levelNumber;

    public bool spawn = true;

    public GameObject[] enemies;

    public Level[] level;

    void Awake(){
        instance = this;
    }
    
    void Start()
    {
        levelNumber = 0;
    }

    
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(score >= level[levelNumber].scoreMax){

            StartCoroutine(UpgradeThePlayer());
        }
    }

    public void AddScore(int amount){

        score += amount;
    }
    IEnumerator UpgradeThePlayer(){

        score = 0;
        levelNumber++;
        GameObject.Find("Player").GetComponent<Player>().currentWeapon = level[levelNumber].weapon;

        DestroyAllEnemies();
        spawn = false;
        yield return new WaitForSeconds(2);
        spawn = true;
    }

    void DestroyAllEnemies(){

        for(int i = 0; i < enemies.Length; i++){

            Destroy(enemies[i].gameObject);
        }
    }
}
