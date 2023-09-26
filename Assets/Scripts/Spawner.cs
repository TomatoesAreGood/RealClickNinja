using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Spawner : MonoBehaviour 
{
    public Boolean isColliding;
    public GameObject fruitPrefab;
    public GameObject bombPrefab;
    private float thrust = 500f;
    public Sprite peach;
    public Sprite apple;
    public Sprite grape;
    public Sprite banana;
    public Sprite strawberry;
    public Sprite kiwi;
    public Sprite tomato;
    public Sprite dragonFruit;

    private void Update(){   
        if(!isColliding){
            for (int i = 0; i < GameManager.allObj.Count; i++){
                GameManager.allObj[i].collider.isTrigger = true;
            }
        }

        if(GameManager.lives == 0 || SceneManager.GetActiveScene().name == "GameOver"){
            // foreach(ThrowableObj obj in allObj){
            //     obj.gameObject.SetActive(false);
            //     Destroy(obj.gameObject);
            // }
            gameObject.SetActive(false);
            Destroy(gameObject);
        }   

        if (GameManager.fruits.Count < 2){
            SpawnFruit();
        }
         if (GameManager.bombs.Count < 0){
            SpawnBomb();
        } 
    }

    private void SpawnFruitWave(){
        
        int randNum = UnityEngine.Random.Range(3,6);
        int randThrust = UnityEngine.Random.Range(400, 600);

        for(int i = 0; i < randNum; i++){
            GameObject obj = Instantiate(fruitPrefab);

            SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();

            float randNumX = UnityEngine.Random.Range(-8f,9f);    
            obj.transform.position = new Vector3(randNumX,-5f,0f);

            rb.AddForce(Vector2.up*randThrust);
            int randnum = UnityEngine.Random.Range(100,360);
            rb.angularVelocity = randnum;
        }
        

    }


    private void SpawnBomb(){
        GameObject obj = Instantiate(bombPrefab);
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        Toss(obj, rb);
    }
    
    private void SpawnFruit(){
        GameObject obj = Instantiate(fruitPrefab);

        SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();

        // int randint = UnityEngine.Random.Range(0,8);

        // if (randint == 0){
        //     sr.sprite = peach;
        // }else if (randint == 1){
        //     sr.sprite = apple;
        // }else if (randint == 2){
        //     sr.sprite = grape;
        // }else if (randint == 3){
        //     sr.sprite = banana;
        // }else if (randint == 4){
        //     sr.sprite = strawberry;
        // }else if (randint == 5){
        //     sr.sprite = kiwi;
        // }else if (randint == 6){
        //     sr.sprite = tomato;
        // }else if (randint == 7){
        //     sr.sprite = dragonFruit;
        // }
        Toss(obj, rb);
    }

    private void Toss(GameObject obj, Rigidbody2D rb){
        float randNumX = UnityEngine.Random.Range(-8f,9f);    
        obj.transform.position = new Vector3(randNumX,-5f,0f);

        Boolean exludeLeft = false;
        Boolean exludeRight = false;
        int max = 6;
        int min = -5;

        if (obj.transform.position.x <= -4){
            exludeLeft = true;
        }
        if (obj.transform.position.x >= 4){
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
        int randnum = UnityEngine.Random.Range(100,360);
        rb.angularVelocity = randnum;
    }

  
    

   
}
