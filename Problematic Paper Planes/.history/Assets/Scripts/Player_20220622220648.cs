using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    
    private Rigidbody2D myBody;

    public float speed;

    private Vector2 moveVelocity;

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
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -179.93f, 179.93f), Mathf.Clamp(transform.position.x, -111.3f, 111.3f));

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
        /*float directionY = Input.GetAxisRaw("Vertical");
        float directionX = Input.GetAxisRaw("Horizontal");
        moveVelocity = new Vector2(directionX, directionY).normalized;
        myBody.velocity = new Vector2(moveVelocity.x * speed, moveVelocity.y * speed);*/
    }
}
