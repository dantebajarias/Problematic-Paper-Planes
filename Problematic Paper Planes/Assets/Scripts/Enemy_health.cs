using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_health : MonoBehaviour
{
    public int health;

    public int scoreReward;
    public AudioSource hitClip;
    public AudioClip deathClip;
    
    public GameObject healthBar;

    void Awake(){
        hitClip = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        //Check if Enemy dies and award points if true
        if(health <= 0){
            GameplayManager.instance.AddScore(scoreReward);
            Destroy(gameObject);
            SoundManager.instance.PlaySoundFX(deathClip);
        }
    }

     
    void OnTriggerEnter2D(Collider2D target){
        //If bullet hits Enemy decrease health 
        if(target.tag == "PlayerBullet"){

            hitClip.Play();
            health -= GameObject.Find("Player").GetComponent<Player>().currentWeapon.damage;
            Destroy(target.gameObject);
            
            //Adjust health bar
            healthBar.transform.localScale = new Vector3(health / 100, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        }
    }
}
