using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMill : MonoBehaviour
{
    private Transform transform;
    public float rotateSpeed = 50;

    void Start (){
        transform = GetComponent<Transform>();
    }

    void Update(){
        transform.Rotate(rotateSpeed * Time.deltaTime, 0, 0);
    }
}
