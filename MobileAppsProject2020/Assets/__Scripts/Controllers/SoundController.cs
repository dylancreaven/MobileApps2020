using UnityEngine.Audio;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundController : MonoBehaviour
{
    private AudioSource audioSource;
   
    void Start()
    {
        audioSource = GetComponent <AudioSource>();
    }

   
    // == public methods ==
    public void PlayOneShot(AudioClip clip)
    {
        if(clip)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    public void Stop()
    {
        
            audioSource.Stop();
        
    }
    public void ToggleSounds()
    {
       
        //Debug.Log("Inside ToggleSounds right now");
        AudioListener.pause=!AudioListener.pause;
        
    }

    public static SoundController FindSoundController()
    {
        SoundController sc = FindObjectOfType<SoundController>();
        if(!sc)
        {
            Debug.LogWarning("Missing Sound Controller");
        }
        return sc;
    }


}
