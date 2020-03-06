using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// use this to manage collisions

public class Enemy : MonoBehaviour
{
    // == public fields ==
    public int ScoreValue { get { return scoreValue; } }

    // delegate type to use for event
    public delegate void EnemyKilled(Enemy enemy);

    // create static method to be implemented in the listener
    public static EnemyKilled EnemyKilledEvent;

    // == private fields ==
   
    [SerializeField] private int scoreValue = 10;
    [SerializeField] private AudioClip hitPlayer;
    // sounds for getting hit by bullet, spawning
    [SerializeField] private AudioClip dieSound;
    [SerializeField] private AudioClip gameOver;

    private SoundController sc;
    private MusicPlayer mp;
    private SceneController scene;
  
    // == private methods ==
    private void Start()
    {
        
        sc = SoundController.FindSoundController();
        mp = MusicPlayer.FindMusicPlayer();
        scene = SceneController.FindSceneController();
       
    }

    private void PlaySound(AudioClip clip)
    {
        if (sc)
        {
            sc.PlayOneShot(clip);
        }
    }

    private void OnTriggerEnter2D(Collider2D hitEnemy)
    {
        var player = hitEnemy.GetComponent<Player>();
        var bullet = hitEnemy.GetComponent<Bullet>();
        
        if(player)  
        {
           
           //Debug.Log("DEBUG: HIT PLAYER - DO STUFF HERE");
           if(mp)
           {
               //Debug.Log("StopMusic");
               mp.StopMusic();

           }
           //Game Over Scene Pops Up!
            if(scene)
            {
                //Debug.Log("Scene.GameOver()");
                scene.GameOver();
            }

            if(sc)
            {
               // Debug.Log("Inside playSound(hitPlayer)");
                PlaySound(hitPlayer);

            }
            
            Destroy(player.gameObject);//kill player
            if(sc)
            {
                 PlaySound(gameOver);

            }
            

            
            
        }

        if(bullet)
        {
           
            PlaySound(dieSound);
            Destroy(bullet.gameObject);
            // publish the event to the system to give the player points
            PublishEnemyKilledEvent();
            // destroy this game object
            Destroy(gameObject);
        }
    }

    private void PublishEnemyKilledEvent()
    {
        // make sure somebody is listening
        if(EnemyKilledEvent != null)   
        {
            EnemyKilledEvent(this);
        }
    }
}
