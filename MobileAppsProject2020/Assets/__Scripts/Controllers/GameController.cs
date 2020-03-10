using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    // text mesh pro library

public class GameController : MonoBehaviour
{
    //== private fields ==
    private int playerScore = 0;
    
    
    [SerializeField] private TextMeshProUGUI scoreText;
    private SceneController scene;
    private MusicPlayer mp;

    
    //public properties

   
    // == private methods ==
    private void Awake()
    {
      
    }
    private void Start()
    {
         Time.timeScale = 1;
        UpdateScore();
        scene = SceneController.FindSceneController();
        mp = MusicPlayer.FindMusicPlayer();
    
    }


    private void OnEnable()
    {
        Enemy.EnemyKilledEvent += OnEnemyKilledEvent;
    }
    private void OnDisable()
    {
        Enemy.EnemyKilledEvent -= OnEnemyKilledEvent;
    }

    private void OnEnemyKilledEvent(Enemy enemy)
    {
        // add the score value for the enemy to the player score
         
        playerScore += enemy.ScoreValue;
        UpdateScore();
        if(playerScore==30)
        {
            Time.timeScale = 0;
            if(mp)
            {
                
                mp.StopMusic();
            }
                
            scene.LevelCompleted();
        }
        
            
        
    }

    private void UpdateScore()
    {
       // Debug.Log("Score: " + playerScore);
        scoreText.text = playerScore.ToString();
    }


}