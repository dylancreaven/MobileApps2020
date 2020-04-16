using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    
    public static bool isPaused = false;
    //pause menu canvas
    public GameObject pauseMenuUI;
    public GameObject scoreUI;
    private SceneController sc;
    
    void Start(){
        Time.timeScale=1f;
        
        //set canvas to be shown or not
        scoreUI.SetActive(true);
        pauseMenuUI.SetActive(false); 
        sc = SceneController.FindSceneController();
    }
    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex==0) // if current scene is the main menu do nothing
        {
            //do nothing
        }
        else{
            if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Resume();
            }
            else{
                Pause();
            }
        }
        }
        
    }
    public void Resume(){
        scoreUI.SetActive(true);
        pauseMenuUI.SetActive(false); 
        Time.timeScale=1f;
        isPaused=false;

    }

    public void Pause(){
        scoreUI.SetActive(false);
        pauseMenuUI .SetActive(true); 
        Time.timeScale=0f;
        isPaused=true;

    }
    
    public void QuitGame(){
        if(sc)
        {
             Debug.Log("Quitting to main Menu");
             sc.GoToMainMenu();
        }
       
        
    }
}
