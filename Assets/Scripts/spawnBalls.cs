using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBalls : MonoBehaviour{

    public float spawnAt = 10f;
    public float startTime = 0.4f;
    public float rate = 0.4f;
    public Rigidbody ball;

    void Start(){
        InvokeRepeating("LaunchBall", startTime, rate);
    }

    void LaunchBall(){
        Rigidbody instance = Instantiate(ball);
        instance.velocity = Random.insideUnitSphere * 5;
    }
}
