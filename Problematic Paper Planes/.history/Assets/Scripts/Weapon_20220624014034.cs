using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public Sprite currentWeaponSpr;
    public static Weapon instance;
    public GameObject bulletPrefab;
    public float fireRate = 1;
    public int damage = 2;

    public AudioClip[] shootClips;
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

    public void Shoot(){
        
        GameObject bullet = Instantiate(bulletPrefab, GameObject.Find("FirePoint").transform.position, Quaternion.identity);
        PlaySoundFX(shootClips[Random.Range(0, shootClips.Length)]);
    }

    public void PlaySoundFX(AudioClip clip){

        soundFX.clip = clip;
        soundFX.Play();
    }
}
