/*  Character control script 
    Created by: Pablo Escriva
    March 2019
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerControl : MonoBehaviour{

    private Rigidbody rigidBody;
    private Transform transform;
    public WorldManager worldManager;
    public float maxSpeed = 10.0f;
    public float moveSpeed = 10.0f;
    public float jumpSpeed = 250.0f;
    public float rotateSpeed = 5;
    private float xInput,zInput,mouseX;
    private Boolean onAir;

    void Start (){
        rigidBody = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
        onAir = false;
    }

    void Update(){
        if (Input.GetKeyDown ("space") && onAir == false){
            rigidBody.AddForce(0, jumpSpeed, 0);
            onAir = true;
        } 
        xInput = Input.GetAxis ("Horizontal");
        zInput = Input.GetAxis ("Vertical");
        mouseX = Input.GetAxis("Mouse X") * rotateSpeed;

        if (rigidBody.position.y < -5){ // fell out of world
            worldManager.reloadLevel();
        }
        
    }

    void FixedUpdate(){
          
        Vector3 inputVector = new Vector3 (xInput, 0.0f, zInput);

        transform.Rotate(0, mouseX * Time.fixedDeltaTime , 0);

        if(rigidBody.velocity.magnitude <= maxSpeed){
            rigidBody.AddRelativeForce (inputVector * moveSpeed);
        }

    }

    void OnCollisionStay(Collision collisionInfo){
        if(collisionInfo.gameObject.tag == "topSide")
            onAir = false;
        }
}
