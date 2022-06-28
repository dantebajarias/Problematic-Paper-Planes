using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_health : MonoBehaviour
{
    public int health;

    public int scoreReward;
    public AudioSource deathClip;
    
    public GameObject healthBar;

    void Awake()
    {
        deathClip = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(health <= 0){
            deathClip.Play();
            GameplayManager.instance.AddScore(scoreReward);
            SlowDeath();
            Destroy(gameObject);
            //SoundManager.instance.PlaySoundFX(deathClip);
        }
    }

    void OnTriggerEnter2D(Collider2D target){
        if(target.tag == "PlayerBullet"){

            health -= GameObject.Find("Player").GetComponent<Player>().currentWeapon.damage;
            Destroy(target.gameObject);

            healthBar.transform.localScale = new Vector3(health / 100, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        }
    }

    IEnumerator SlowDeath(){
        yield return new WaitForSeconds(1.5f);
    }
}
