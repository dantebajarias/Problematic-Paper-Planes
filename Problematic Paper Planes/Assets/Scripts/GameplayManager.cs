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

    public TextMeshProUGUI roundComplete;

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
        //Last level completed
        if(levelNumber == (level.Length-1) && score == 0){
            StartCoroutine(MaxLevel());
        }
    }

    public void AddScore(int amount){

        score += amount;
    }
    
    //Incease level, reset score, and give weapon based on level after each clear
    IEnumerator UpgradeThePlayer(){
        roundComplete.gameObject.SetActive(true);
        roundComplete.text = "Round " + (levelNumber+1) + " Complete!";
        score = 0;
        levelNumber++;
        GameObject.Find("Player").GetComponent<Player>().currentWeapon = level[levelNumber].weapon;
        //If health lost, restore one health point 
        if(GameObject.Find("Player").GetComponent<Player>().health < 8){
            GameObject.Find("Player").GetComponent<Player>().health++;
            Instantiate(GameObject.Find("Health-bar").transform.GetChild(0).gameObject, GameObject.Find("Health-bar").transform);
        }

        DestroyAllEnemies();
        spawn = false;
        yield return new WaitForSeconds(2);
        roundComplete.gameObject.SetActive(false);
        spawn = true;
    }

    //Endless mode after last level completed
    IEnumerator MaxLevel(){
        roundComplete.gameObject.SetActive(true);
        roundComplete.text = "You win. Now survive.";
        GameObject.Find("Player").GetComponent<Player>().currentWeapon = level[levelNumber].weapon;
        
        yield return new WaitForSeconds(2);
        roundComplete.gameObject.SetActive(false);
    }
    
    //Despawn Enemies
    public void DestroyAllEnemies(){

        for(int i = 0; i < enemies.Length; i++){

            Destroy(enemies[i].gameObject);
        }
    }

    void TextHolder(){

        scoreCountText.text = score.ToString();
        scoreCountMaxText.text = level[levelNumber].scoreMax.ToString();
    }
}
