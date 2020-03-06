using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TimeController : MonoBehaviour
{
    
    public void SetStartTime(){

            Time.timeScale=1;
    }
    public void PauseTime(){
        //Debug.Log("PauseTime");
        Time.timeScale=0;
    }
    public static TimeController FindTimeController()
        {
            TimeController time = FindObjectOfType<TimeController>();
            if(!time)
            {
                Debug.LogWarning("Missing TimeController");
            }
            return time;
        }
    }