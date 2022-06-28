using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_follow : MonoBehaviour
{
    private List<Rigidbody2D> EnemyRBs;
    public float speed;

    private Transform playerPos;
    private Rigidbody2D rb;

    private float repelRange = 0.5f;
    
    void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();

        if(EnemyRBs == null){
            
            EnemyRBs = new List<Rigidbody2D>();
        }

        EnemyRBs.Add(rb);
    }

    //Removes Enemy from list
    void OnDestroy(){

        EnemyRBs.Remove(rb);
    }
    
    void Update()
    {
        //Check if Player and Enemy exist, and move to Player if true
        if(transform.position != null && playerPos.position != null){
           transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime); 
        }
    }

    void FixedUpdate(){

        Vector2 repelForce = Vector2.zero;
        
        //Make sure the Enemys do not stack on top of each other
        foreach(Rigidbody2D enemy in EnemyRBs){

            if(enemy == rb){
                continue;
            }

            if(Vector2.Distance(enemy.position, rb.position) <= repelRange){

                Vector2 repelDir = (rb.position - enemy.position).normalized;
                repelForce += repelDir;
            }
        }
    }
}
