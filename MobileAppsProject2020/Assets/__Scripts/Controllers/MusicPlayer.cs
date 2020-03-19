using UnityEngine.Audio;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip gameMusic;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume=0.23f;
        PlayOneShot(gameMusic);
    }

   
    // == public methods ==
    public void PlayOneShot(AudioClip clip)
    {
        if(clip)
        {
            audioSource.PlayOneShot(clip);
        }
    }
    public void StopMusic(){

        //Debug.Log("Inside StopMusic()");
        audioSource.volume=0.0f;
    }
    public void ToggleSounds()
    {
       
        //Debug.Log("Inside ToggleSounds right now");
        AudioListener.pause=!AudioListener.pause;
        
    }

    public static MusicPlayer FindMusicPlayer()
    {
        MusicPlayer mp = FindObjectOfType<MusicPlayer>();
        if(!mp)
        {
            Debug.LogWarning("Missing MusicPlayer");
        }
        return mp;
    }


}
