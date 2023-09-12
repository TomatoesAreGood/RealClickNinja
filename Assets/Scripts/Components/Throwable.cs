using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

// using System.Numerics;
using UnityEditor.Callbacks;
using UnityEditor.UI;

// using System.Numerics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Throwable : MonoBehaviour{
    public Rigidbody2D rb;
    public GameObject prefab;
    public float thrust;

    public void Awake(){
        rb = this.GetComponent<Rigidbody2D>();
        thrust = 500.0f;
    }

    private void OnEnable(){
        Toss();
        Spawner.fruits.Add(this);
    }

   private void OnDisable(){
        Spawner.fruits.Remove(this);
    }


    private void OnMouseDown(){
        Destroy(gameObject);
    }
    


    private void OnMouseDrag(){
    }
    
    private void Update(){
        if (transform.position.y < -6.5){
            Destroy(gameObject);
        }
    }

   

    private void Toss(){
        Boolean exludeLeft = false;
        Boolean exludeRight = false;
        int max = 6;
        int min = -5;

        if (transform.position.y <= -7){
            exludeLeft = true;
        }
        if (transform.position.y >= 7){
            exludeRight = true;
        }

        if (exludeLeft){
            min = 0;
        }else if(exludeRight){
            max = 0;
        }

       int num = UnityEngine.Random.Range(min,max);

        while (Math.Abs(num) == 1 || Math.Abs(num) == 2){
            num = UnityEngine.Random.Range(min,max);
        }

        if (num < 0){
            num = Math.Abs(num);
            rb.AddForce(Vector2.up*thrust*UnityEngine.Random.Range(0.75f, 1.25f));
            rb.AddForce(Vector2.left*thrust/num);
        }else if (num > 0){
            rb.AddForce(Vector2.up*thrust*UnityEngine.Random.Range(0.75f, 1.25f));
            rb.AddForce(Vector2.right*thrust/num);
        }else{
            rb.AddForce(Vector2.up*thrust*UnityEngine.Random.Range(0.75f, 1.25f));
        }
    }

}
