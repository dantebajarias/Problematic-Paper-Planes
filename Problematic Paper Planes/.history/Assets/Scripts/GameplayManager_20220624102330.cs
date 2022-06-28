using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;

    private int score;

    public int levelNumber;

    public bool spawn = true;

    public GameObject[] enemies;

    public Level[] level;

    public Text scoreCountText, scoreCountMaxText;

    public TextMeshPro roundComplete;

    void Awake(){
        instance = this;
    }
    
    void Start()
    {
        levelNumber = 0;
    }

    
    void Update()
    {
        TextHolder();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(score >= level[levelNumber].scoreMax){

            StartCoroutine(UpgradeThePlayer());
        }
    }

    public void AddScore(int amount){

        score += amount;
    }
    
    IEnumerator UpgradeThePlayer(){
        roundComplete.gameObject.SetActive(true);
        roundComplete.text = "Round " + (levelNumber+1) + " Complete!";
        score = 0;
        levelNumber++;
        GameObject.Find("Player").GetComponent<Player>().currentWeapon = level[levelNumber].weapon;

        DestroyAllEnemies();
        spawn = false;
        yield return new WaitForSeconds(2);
        roundComplete.SetActive(false);
        spawn = true;
    }

    void DestroyAllEnemies(){

        for(int i = 0; i < enemies.Length; i++){

            Destroy(enemies[i].gameObject);
        }
    }

    void TextHolder(){

        scoreCountText.text = score.ToString();
        scoreCountMaxText.text = level[levelNumber].scoreMax.ToString();
    }
}
