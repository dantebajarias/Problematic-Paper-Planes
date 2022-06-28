using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jet_Enemy : MonoBehaviour
{
    public Transform bulletPos;
    public GameObject bullet;

    private Transform playerPos;
    private Rigidbody2D rb;

    public float speed;

    private bool isInRange = false;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        bulletPos = GameObject.Find("BulletPos").transform;
    }

    void Start(){

        StartCoroutine(EnemyShoot());
    }

    
    void Update()
    {
        if(Vector2.Distance(transform.position, playerPos.position) > 8.5f){
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
            isInRange = false;
        }else{
            isInRange = true;
        }
    }

    void FixedUpdate(){

        Rotation();
    }

    void Rotation(){

        Vector2 direction = (playerPos.gameObject.GetComponent<Rigidbody2D>().position - rb.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
        rb.rotation = angle;
    }

    IEnumerator EnemyShoot(){

        if(isInRange){
        Instantiate(bullet, bulletPos.position, transform.rotation);
        }
        yield return new WaitForSeconds(0.4f);
        StartCoroutine(EnemyShoot());
    }
}
