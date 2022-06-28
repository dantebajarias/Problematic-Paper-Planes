using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource soundFX, audioTheme;

    public AudioClip[] themeSongs;

    public int player;
    
    void Awake()
    {
        if(instance == null){

            instance = this;
        }else{

            Destroy(gameObject);
        }
    }
    
    private void Start(){
        
        /*if(!audioTheme.playOnAwake){

            audioTheme.clip = themeSongs[Random.Range(0, themeSongs.Length)];
            audioTheme.Play();
        }*/
        audioTheme.clip = themeSongs[Random.Range(0, themeSongs.Length)];
        audioTheme.Play();
    }
    
    void Update()
    {
        /*if(!audioTheme.isPlaying){
            audioTheme.clip = themeSongs[Random.Range(0, themeSongs.Length)];
            audioTheme.Play();
        }*/
        /*if(GameObject.FindGameObjectWithTag("Player").health == 0){
            audioTheme.Stop();
        }*/
        if(player.GetComponent<Player>().health == 0){
            audioTheme.Stop();
        }
    }

    public void PlaySoundFX(AudioClip clip){

        soundFX.clip = clip;
        soundFX.Play();
    }
}
