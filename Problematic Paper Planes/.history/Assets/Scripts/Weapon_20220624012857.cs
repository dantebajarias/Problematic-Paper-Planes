using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public Sprite currentWeaponSpr;

    public GameObject bulletPrefab;
    public float fireRate = 1;
    public int damage = 2;

    public AudioClip[] shootClips;

    public void Shoot(){
        
        GameObject bullet = Instantiate(bulletPrefab, GameObject.Find("FirePoint").transform.position, Quaternion.identity);
        Player_bullet.instance.PlaySoundFX(shootClips[Random.Range(0, shootClips.Length)]);
    }
}
