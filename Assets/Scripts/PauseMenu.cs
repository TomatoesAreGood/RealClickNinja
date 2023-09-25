using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pauseMenuUI;

    private List<ThrowableObj> pausedObjects;

    // Update is called once per frame

    private void Start(){
        pausedObjects = new List<ThrowableObj>(0);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                Resume();
            }else{
                Pause();
            }
        }
    }

    private void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    private void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    
    public void LoadMenu(){
        SceneManager.LoadScene("StartScreen");
        if(Time.timeScale == 0){
            Resume();
        }
    }
    public void Quit(){
        Debug.Log("quitted game");
        Application.Quit();
    }
    public void ResumeGame(){
        Resume();
    }
}
