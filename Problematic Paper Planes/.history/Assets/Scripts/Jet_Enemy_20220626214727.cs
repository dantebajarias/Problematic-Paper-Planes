using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jet_Enemy : MonoBehaviour
{
    private Transform playerPos;
    private Rigidbody2D rb;

    public float speed = 0.3f;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, playerPos.position) > 2.5f){
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
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
}
