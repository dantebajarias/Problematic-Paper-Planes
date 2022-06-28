using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_bullet : MonoBehaviour
{
    public static Player_bullet instance;
    
    public float speed = 5;

    private Vector2 dir;
    
    public AudioSource soundFX;
    
    void Awake()
    {
        /*if(instance == null){

            instance = this;
        }else{

            Destroy(gameObject);
        }*/
        instance = this;
    }
    
    void Start()
    {
        dir = GameObject.Find("Dir").transform.position;
        transform.position = GameObject.Find("FirePoint").transform.position;
        Destroy(gameObject, 1);
    }

    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, dir, speed * Time.deltaTime);
    }

    public void PlaySoundFX(AudioClip clip){

        soundFX.clip = clip;
        soundFX.Play();
    }
}
