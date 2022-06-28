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
        
    }
}
