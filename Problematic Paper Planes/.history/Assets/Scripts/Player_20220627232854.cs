using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Weapon currentWeapon;
    public GameObject losePanel;

    private Rigidbody2D myBody;

    private Animator anim;
    public float speed;
    public int health;

    private Vector2 moveVelocity;

    private float nextTimeOfFire = 0;

    private bool hit = true;

    public AudioSource hitClip;
    public AudioClip deathClip;
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim  = GetComponent<Animator>();
        transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = currentWeapon.currentWeaponSpr;
        hitClip = GetComponent<AudioSource>();
    }

    void Update(){

        if(health > 0){
            Rotation();
        }

        //Shooting Mechanic
        if(Input.GetMouseButton(0)){
            if(Time.time >= nextTimeOfFire){

                currentWeapon.Shoot();
                nextTimeOfFire = Time.time + 1 / currentWeapon.fireRate;
            }
        }

        //Restrictive Player Bounds 
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -181.95f, 181.95f), Mathf.Clamp(transform.position.y, -113.0f, 113.0f));

    }
    
    void FixedUpdate()
    {
        if(health > 0){
           Movement(); 
        }
    }

    void Rotation(){

        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10 * Time.deltaTime);
    }

    void Movement(){
        
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
        myBody.MovePosition(myBody.position + moveVelocity * Time.fixedDeltaTime);
    }
    
    //Turn off hitbox for 1.5s when Player hurt
    IEnumerator HitBoxOff(){
        hit = false;
        anim.SetTrigger("Hit");
        yield return new WaitForSeconds(1.5f);
        hit = true;
    }
    
    void OnTriggerEnter2D(Collider2D target){
        //If hit by Enemy or EnemyBullet, decrease Player health
        if(target.tag == "Enemy" || target.tag == "EnemyBullet"){
            if(hit){
                hitClip.Play();
                StartCoroutine(HitBoxOff());
                health--;
                Destroy(GameObject.Find("Health-bar").transform.GetChild(0).gameObject);
                //Player dead
                if(health <= 0){
                    SoundManager.instance.PlaySoundFX(deathClip);
                    losePanel.SetActive(true);
                    GameplayManager.instance.DestroyAllEnemies();
                    Destroy(gameObject);
                }
            }
        }
    }
}
