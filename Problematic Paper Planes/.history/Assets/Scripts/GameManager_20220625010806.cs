using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene("Game");
    }

    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame(){
        Application.Quit();
        Debug.Log("Game Closed");
    }
    public void Reset(){
        PlayerPrefs.DeleteKey("highscore");
    }
}
