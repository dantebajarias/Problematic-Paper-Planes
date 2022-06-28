using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;

    public AudioSource as_;

    void Start(){
        as_ = GetComponent<AudioSource>();
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
}
