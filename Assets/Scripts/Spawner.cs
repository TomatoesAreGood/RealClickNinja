using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Spawner : MonoBehaviour 
{
    public Boolean iscolliding;
    public static Spawner instance;
    public GameObject FruitPrefab;
    public GameObject BombPrefab;
    public static float spinSpeed = 360;
    private float thrust = 500f;
    public Sprite peach;
    public Sprite apple;
    public Sprite grape;
    public Sprite banana;
    public Sprite strawberry;
    public Sprite kiwi;
    public Sprite tomato;
    public Sprite dragonfruit;

    public static List<ThrowableObj> allObj;
    public static List<ThrowableObj> fruits;
    public static List<ThrowableObj> bombs;

   
    protected virtual void Awake(){
        fruits = new List<ThrowableObj>();
        allObj = new List<ThrowableObj>();
        bombs = new List<ThrowableObj>();
    }

    void Update(){   
        if(!iscolliding){
            for (int i = 0; i < allObj.Count; i++){
                allObj[i].collider.isTrigger = true;
            }
        }

        if(GameManager.score < 0 || GameManager.lives == 0 || SceneManager.GetActiveScene().name == "GameOver"){
            // foreach(ThrowableObj obj in allObj){
            //     obj.gameObject.SetActive(false);
            //     Destroy(obj.gameObject);
            // }
            gameObject.SetActive(false);
            Destroy(gameObject);
        }   

        if (fruits.Count < 1){
            SpawnFruit();
        }
         if (bombs.Count < 1){
            SpawnBomb();
        } 
    }

    public void SpawnBomb(){
        GameObject obj = Instantiate(BombPrefab);
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        Toss(obj, rb);
    }
    
    public void SpawnFruit(){
        GameObject obj = Instantiate(FruitPrefab);

        SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();

        int randint = UnityEngine.Random.Range(0,8);

        if (randint == 0){
            sr.sprite = peach;
        }else if (randint == 1){
            sr.sprite = apple;
        }else if (randint == 2){
            sr.sprite = grape;
        }else if (randint == 3){
            sr.sprite = banana;
        }else if (randint == 4){
            sr.sprite = strawberry;
        }else if (randint == 5){
            sr.sprite = kiwi;
        }else if (randint == 6){
            sr.sprite = tomato;
        }else if (randint == 7){
            sr.sprite = dragonfruit;
        }
        Toss(obj, rb);
    }


    public void Toss(GameObject obj, Rigidbody2D rb){
        float randNumX = UnityEngine.Random.Range(-8f,9f);    
        obj.transform.position = new Vector3(randNumX,-5f,0f);

        Boolean exludeLeft = false;
        Boolean exludeRight = false;
        int max = 6;
        int min = -5;

        if (obj.transform.position.x <= -6){
            exludeLeft = true;
        }
        if (obj.transform.position.x >= 6){
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
