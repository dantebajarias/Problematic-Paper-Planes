using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;

    public AudioSource as_;

    [SerializeField] private Slider volumeSlider = null;


    void Start(){
        as_ = GetComponent<AudioSource>();

        if(!PlayerPrefs.HasKey("musicValue")){

            PlayerPrefs.SetFloat("musicValue", 1);
            LoadValues();
        }else{

            LoadValues();
        }
        
    }

    private void Awake(){

        if(instance == null){
            
            instance = this;
        }else{
            Destroy(gameObject);
        }
    }
    
    public void Mute(){
        as_.mute = !as_.mute;
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
