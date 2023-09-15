using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;

// using System.Numerics;
using UnityEditor.Callbacks;
using UnityEditor.UI;

// using System.Numerics;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Throwable : MonoBehaviour{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private float thrust = 500f;
    private Boolean isBomb;
    public float spinSpeed;
    public Sprite peach;
    public Sprite bomb;
    public Sprite apple;
    public Sprite grape;
    public Sprite banana;
    public Sprite strawberry;
    public Sprite kiwi;
    public Sprite tomato;

    public void Awake(){
        rb = this.GetComponent<Rigidbody2D>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();

        int randint = UnityEngine.Random.Range(0,8);
        if (randint > 0){
            isBomb = false;
        }else{
            isBomb = true;
        }

        if (randint == 0){
            spriteRenderer.sprite = bomb;
        }else if(randint == 1){
            spriteRenderer.sprite = apple;
        }else if(randint == 2){
            spriteRenderer.sprite = grape;
        }else if(randint == 3){
            spriteRenderer.sprite = banana;
        }else if(randint == 4){
            spriteRenderer.sprite = strawberry;
        }else if(randint == 5){
            spriteRenderer.sprite = kiwi;
        }else if(randint == 6){
            spriteRenderer.sprite = peach;
        }else if(randint == 7){
            spriteRenderer.sprite = tomato;
        }
    }

    private void Start(){
        int randnum = UnityEngine.Random.Range(0, 361);
        rb.rotation = (float)randnum;

        Toss();
        Spawner.fruits.Add(this);
    }

   private void OnDisable(){
        Spawner.fruits.Remove(this);
    }


    private void OnMouseDown(){
        if (!isBomb){
            GameManager.score++;
        }else{
            GameManager.score = -1000;
        }
        Destroy(gameObject);
    }
    

    private Boolean hitGround(){
        return transform.position.y < -6.5;
    }
    
    private void Spin(){
        float angle = transform.localRotation.eulerAngles.z;
        transform.localRotation = Quaternion.Euler(0f, 0f, angle + spinSpeed* Time.deltaTime);
    }

    private void Update(){
       Spin();
       
        if (hitGround()){
            if (!isBomb){
                GameManager.score--;
            }
            Destroy(gameObject);
        }
    }


    private void Toss(){
        Boolean exludeLeft = false;
        Boolean exludeRight = false;
        int max = 6;
        int min = -5;

        if (this.transform.position.x <= -6){
            exludeLeft = true;
        }
        if (this.transform.position.x >= 6){
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
