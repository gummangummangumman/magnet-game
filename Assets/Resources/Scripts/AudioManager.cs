using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        //Mutes on start only if "mute" is stored as "true" in PlayerPrefs
        audioSource.mute = PlayerPrefs.GetString("mute", "false") == "true";
    }


    public void ToggleMute()
    {
        audioSource.mute = !audioSource.mute;
        print("current mute: " + audioSource.mute);
        PlayerPrefs.SetString("mute", audioSource.mute ? "true" : "false");
    }

}
