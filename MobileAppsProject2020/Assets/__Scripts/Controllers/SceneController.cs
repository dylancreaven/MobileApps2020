using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;  
// load, unload scenes
using UnityEngine.SceneManagement;



public class SceneController : MonoBehaviour
{
    // == onclick Events ==
    public void Start_Level1()
    {
        SceneManager.LoadSceneAsync(SceneNames.GAME_LEVEL1);
    }

    public void GoToMainMenu()
    {
       
       SceneManager.LoadScene(0);
        
    }
    public void GameOver()
    {
        SceneManager.LoadSceneAsync(SceneNames.GAME_OVER,LoadSceneMode.Additive);
    }
    public void LevelCompleted()
    {
        SceneManager.LoadSceneAsync(SceneNames.Completed_Level,LoadSceneMode.Additive);
    }

    public void Start_Level2(){

        SceneManager.LoadSceneAsync(SceneNames.GAME_LEVEL2);
    }

   public void ExitGame() {
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
