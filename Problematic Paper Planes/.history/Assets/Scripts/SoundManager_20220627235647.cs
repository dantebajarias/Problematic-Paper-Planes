using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource soundFX, audioTheme;

    public AudioClip[] themeSongs;
    
    [SerializeField] private Slider volumeSlider = null;
    
    void Awake()
    {
        if(instance == null){

            instance = this;
        }else{

            Destroy(gameObject);
        }
    }

    private void Start(){
        //Start music when game starts
        audioTheme.clip = themeSongs[Random.Range(0, themeSongs.Length)];
        audioTheme.Play();

        if(!PlayerPrefs.HasKey("musicValue")){

            PlayerPrefs.SetFloat("musicValue", 1);
            LoadValues();
        }else{

            LoadValues();
        }
    }
    
    void Update()
    {
        //Stop music when Player dies
        if(GameObject.FindGameObjectWithTag("Player") == null){
            audioTheme.Stop();
        }
    }

    public void PlaySoundFX(AudioClip clip){

        soundFX.clip = clip;
        soundFX.Play();
    }

    public void SaveVolumeButton(){

        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("musicValue", volumeValue);
        LoadValues();
    }

    void LoadValues(){

        float volumeValue = PlayerPrefs.GetFloat("musicValue");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }
}
