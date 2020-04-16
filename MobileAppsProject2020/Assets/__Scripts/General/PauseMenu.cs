using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public GameObject scoreUI;
    private SceneController sc;
    
    void Start(){
        Time.timeScale=1f;
        
        scoreUI.SetActive(true);
        pauseMenuUI.SetActive(false); 
        sc = SceneController.FindSceneController();
    }
    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex==0)
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
