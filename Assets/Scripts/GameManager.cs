using System.Collections;
using System.Collections.Generic;
using System.Threading;
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

    public Spawner spawner;


    void Awake(){
        lives = 3;
        score = 0;
       
    }

    void Update()
    {
        time += Time.deltaTime;

        scoreobj.UpdateText(score);
        livesobj.UpdateText(lives);
        timesobj.UpdateText((int)time);

        if (score < 0 || lives == 0){
            SceneManager.LoadScene("GameOver");
        }
    }
}
