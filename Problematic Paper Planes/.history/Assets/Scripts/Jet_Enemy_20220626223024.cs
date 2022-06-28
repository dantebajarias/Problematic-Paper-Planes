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
        bulletPos.position = GameObject.Find("BulletPos").transform.position;
    }

    void Start(){

        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, playerPos.position) > 5.5f){
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

    IEnumerator Shoot(){

        if(isInRange){
            Instantiate(bullet, bulletPos.position, Quaternion.identity);
        }
        yield return new WaitForSeconds(1);
        StartCoroutine(Shoot());
    }
}
