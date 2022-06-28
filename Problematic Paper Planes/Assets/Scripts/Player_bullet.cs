using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_bullet : MonoBehaviour
{
    public float speed = 5;

    private Vector2 dir;
    
    
    void Start()
    {
        //Shoot bullet in direction and destroy after 1 second
        dir = GameObject.Find("Dir").transform.position;
        transform.position = GameObject.Find("FirePoint").transform.position;
        Destroy(gameObject, 1);
    }

    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, dir, speed * Time.deltaTime);
    }
}
