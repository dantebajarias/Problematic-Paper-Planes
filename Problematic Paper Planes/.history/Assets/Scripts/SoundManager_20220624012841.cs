using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource audioTheme;

    public AudioClip[] themeSongs;
    
    void Awake()
    {
        /*if(instance == null){

            instance = this;
        }else{

            Destroy(gameObject);
        }*/
        instance = this;
    }

    private void Start(){
        
        if(!audioTheme.playOnAwake){

            audioTheme.clip = themeSongs[Random.Range(0, themeSongs.Length)];
            audioTheme.Play();
        }
        audioTheme = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        if(!audioTheme.isPlaying){
            audioTheme.clip = themeSongs[Random.Range(0, themeSongs.Length)];
            audioTheme.Play();
        }
        if(GameObject.FindGameObjectWithTag("Player") == null){
            audioTheme.Stop();
        }
    }
}
