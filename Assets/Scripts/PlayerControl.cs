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

    private Boolean onAir;

    void Start (){
        rigidBody = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
        onAir = false;
    }

    void Update(){
        float xInput = Input.GetAxis ("Horizontal");
        float zInput = Input.GetAxis ("Vertical");
        float mouseX = Input.GetAxis("Mouse X") * rotateSpeed;
                
        Vector3 inputVector = new Vector3 (xInput, 0.0f, zInput);

        transform.Rotate(0, mouseX, 0);

        if(rigidBody.velocity.magnitude <= maxSpeed){
            rigidBody.AddRelativeForce (inputVector * moveSpeed);
        }

        if (Input.GetKeyDown ("space") && onAir == false){
            rigidBody.AddForce(0, jumpSpeed, 0);
            onAir = true;
        } 

        if (rigidBody.position.y < -5){ // fell out of world
            worldManager.reloadLevel();
        } 

    }

    void OnCollisionStay(Collision collisionInfo){
        onAir = false;
    }
}
