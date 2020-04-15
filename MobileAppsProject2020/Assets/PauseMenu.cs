using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    private SceneController sc;
    
    void Start(){
        pauseMenuUI.SetActive(false); 
        sc = SceneController.FindSceneController();
    }
    // Update is called once per frame
    void Update()
    {
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
    public void Resume(){

        pauseMenuUI.SetActive(false); 
        Time.timeScale=1f;
        isPaused=false;

    }

    void Pause(){
        
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
