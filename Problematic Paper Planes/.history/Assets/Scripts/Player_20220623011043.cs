using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    
    private Rigidbody2D myBody;

    public float speed;
    public int health;

    private Vector2 moveVelocity;

    private bool hit;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    void Update(){

        Rotation();

        //Shooting
        if(Input.GetMouseButtonDown(0)){
            Instantiate(bullet, transform.position, Quaternion.identity);
        }

        //Bounds
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -178.63f, 178.63f), Mathf.Clamp(transform.position.y, -110.0f, 110.0f));

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
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

    IEnumerator HitBoxOff(){
        hit = false;
        yield return new WaitForSeconds(1.5f);
        hit = true;
    }
    
    void OnTriggerEnter2D(Collider2D target){

        if(target.tag == "Enemy"){
            
            if(hit){
                StartCoroutine(HitBoxOff());
                health--;
            }
        }
    }
}