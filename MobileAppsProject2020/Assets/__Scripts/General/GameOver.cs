using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
   [SerializeField] private AudioClip gameOver;

    private SoundController sc;
    // Start is called before the first frame update
    void Start()
    {
        sc = SoundController.FindSoundController();
        
        
        sc.PlayOneShot(gameOver);
    }

  
}
