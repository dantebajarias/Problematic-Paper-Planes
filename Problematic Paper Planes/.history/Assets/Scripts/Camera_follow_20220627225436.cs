using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_follow : MonoBehaviour
{
    private Transform playerPos;

    
    void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void Update()
    {
        //Follow Player and restrict the bounds of the camera 
        if(GameObject.FindGameObjectWithTag("Player") != null){
            transform.position = new Vector3(playerPos.position.x, playerPos.position.y, transform.position.z);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -171f, 171f), Mathf.Clamp(transform.position.y, -107.5f, 107.5f), transform.position.z);
        }
    }
}
