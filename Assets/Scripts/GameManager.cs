using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int score;

    public IntToText scoreobj;
        //timer
    public Spawner spawner;


    // Start is called before the first frame update
    void Awake(){
        score = 0;
       
    }

    // Update is called once per frame
    void Update()
    {
        scoreobj.UpdateText(score);

        if (score < 0){
            SceneManager.LoadScene("GameOver");
        }
    }
}
