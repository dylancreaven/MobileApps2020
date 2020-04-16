using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;  
// load, unload scenes
using UnityEngine.SceneManagement;



public class SceneController : MonoBehaviour
{
    
    //first level
    public void Start_Level1()
    {
        SceneManager.LoadSceneAsync(SceneNames.GAME_LEVEL1);
    }

    public void GoToMainMenu()
    {
       
       SceneManager.LoadScene(0);
        
    }
    public void Credits(){
        Debug.Log("CREDITS");
        SceneManager.LoadSceneAsync(SceneNames.CREDITS);


    }
    
    public void InfoPanel()
    {
       
        SceneManager.LoadSceneAsync(SceneNames.INFO,LoadSceneMode.Additive);
    }
    
    public void GameOver()
    {
        SceneManager.LoadSceneAsync(SceneNames.GAME_OVER,LoadSceneMode.Additive);
    }
    public void LevelCompleted()
    {
        SceneManager.LoadSceneAsync(SceneNames.Completed_Level,LoadSceneMode.Additive);
    }

    public void Next_Level(){
         int y = SceneManager.GetActiveScene().buildIndex;
       if(y==3)
       {
           Credits();

       }
       else{
           SceneManager.LoadScene(y+1);
       }
         
    }

     public void restart_level(){

         Application.LoadLevel(Application.loadedLevel);
    }
     
   public void QuitGame() {
       Debug.Log("Quitting Game...");
     Application.Quit();
    }
    public static SceneController FindSceneController()
    {
        SceneController sc = FindObjectOfType<SceneController>();
        if(!sc)
        {
            Debug.LogWarning("Missing SceneController");
        }
        return sc;
    }


}
