using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_health : MonoBehaviour
{
    public int health;

    public AudioClip deathClip;
    
    void Update()
    {
        if(health < 1){

            Destroy(gameObject);
            //SoundManager.instance.PlaySoundFX(deathClip);
        }
    }

    void OnTriggerEnter2D(Collider2D target){
        if(target.tag == "BlueBullet"){

            //health -= GameObject.Find("Player").GetComponent<Player>().currentWeapon.damage;
            Destroy(target.gameObject);
        }
    }
}
