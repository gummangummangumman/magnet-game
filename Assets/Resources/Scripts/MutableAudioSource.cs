using UnityEngine;

public class MutableAudioSource : MonoBehaviour
{

    AudioManager audioManager;
    AudioSource audioSource;

    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        audioSource = GetComponent<AudioSource>();
        
        audioSource.mute = audioManager.GetMuted();
    }

    /**
     * Needs to be called when the muting actually occurs.
     */
    public void UpdateMuteStatus()
    {
        audioSource.mute = audioManager.GetMuted();
    }
}
