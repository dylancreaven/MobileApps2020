using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continue : MonoBehaviour
{
    [SerializeField] private AudioClip con;//continue sound clip

    private SoundController sc;
    // Start is called before the first frame update
    void Start()
    {
        sc = SoundController.FindSoundController();
        
        
        sc.PlayOneShot(con);
    }

  
}
