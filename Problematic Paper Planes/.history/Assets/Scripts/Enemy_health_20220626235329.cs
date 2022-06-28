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
        if(health <= 0){
            GameplayManager.instance.AddScore(scoreReward);
            Destroy(gameObject);
            SoundManager.instance.PlaySoundFX(deathClip);
        }
    }

    void OnTriggerEnter2D(Collider2D target){
        if(target.tag == "PlayerBullet"){

            hitClip.Play();
            health -= GameObject.Find("Player").GetComponent<Player>().currentWeapon.damage;
            Destroy(target.gameObject);

            healthBar.transform.localScale = new Vector3(health / 100, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        }
    }
}
