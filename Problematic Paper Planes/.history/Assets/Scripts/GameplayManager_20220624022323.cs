using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;

    private int score;

    private int levelNumber;

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
        if(score >= level[levelNumber].scoreMax){

        }
    }

    IEnumerator UpgradeThePlayer(){

        score = 0;
        levelNumber++;
        GameObject.Find("Player").GetComponent<Player>().currentWeapon = level[levelNumber].weapon;

        //Destroy All Enemies
        spawn = false;
        yield return new WaitForSeconds(2);
        spawn = true;
    }
}
