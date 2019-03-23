using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoDestroyBall : MonoBehaviour{

    private Rigidbody rigidbody;
    public float despawnY = -10.0f;

    void Start (){
        rigidbody = GetComponent<Rigidbody>();
    }
    
    void Update(){
        if(rigidbody.position.y < despawnY){
            Destroy(this.gameObject);
        } 
    }
}
