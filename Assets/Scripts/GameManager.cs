using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int lives;
    public static int score;
    public static float time;
    public IntToText scoreobj;
    public IntToText livesobj;
    public IntToText timesobj;
    public static List<ThrowableObj> allObj;
    public static List<ThrowableObj> fruits;
    public static List<ThrowableObj> bombs;

    private void Awake(){
        lives = 100;
        score = 0;
        fruits = new List<ThrowableObj>();
        allObj = new List<ThrowableObj>();
        bombs = new List<ThrowableObj>();
    }

    private void Update()
    {
        time += Time.deltaTime;

        scoreobj.UpdateText(score);
        livesobj.UpdateText(lives);
        timesobj.UpdateText((int)time);

        if (score < 0 || lives == 0){
            SceneManager.LoadScene("GameOver");
        }
        
        List<ThrowableObj> destroyedList = new List<ThrowableObj>();

        foreach(ThrowableObj obj in bombs){
           if (Blade.circleCollider.IsTouching(obj.collider)){
                destroyedList.Add(obj);
           } 
        }
        foreach(ThrowableObj obj in destroyedList){
            if (obj.GetType() == typeof(Bomb)){
                score = -100000;
            }
            // if(obj.GetType() == typeof(Fruit)){
            //     score++;
            // }
            Destroy(obj.gameObject);
        }

    }

}
