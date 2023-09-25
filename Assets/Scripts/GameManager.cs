using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Boolean cutting;

    public Boolean clicking;

    public static int lives;
    
    public static int score;

    public static float time;

    public IntToText scoreobj;

    public IntToText livesobj;

    public IntToText timesobj;

    private void Awake(){
        lives = 100;
        score = 0;
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

        foreach(ThrowableObj obj in Spawner.bombs){
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
