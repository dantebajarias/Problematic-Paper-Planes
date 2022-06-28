using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_health : MonoBehaviour
{
    public int health;

    public int scoreReward;
    public AudioClip deathClip;
    
    void Update()
    {
        if(health <= 0){
            GameplayManager.instance.AddScore(scoreReward);
            Destroy(gameObject);
            SoundManager.instance.PlaySoundFX(deathClip);
        }
    }

    void OnTriggerEnter2D(Collider2D target){
        if(target.tag == "PlayerBullet"){

            health -= GameObject.Find("Player").GetComponent<Player>().currentWeapon.damage;
            Destroy(target.gameObject);
        }
    }
}
