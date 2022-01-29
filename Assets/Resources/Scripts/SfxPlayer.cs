using System.Collections.Generic;
using UnityEngine;

public class SfxPlayer : MonoBehaviour
{

    private AudioSource audioSource;
    private Dictionary<string, AudioClip> audioClips;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioClips = new Dictionary<string, AudioClip>
        {
            { "split", Resources.Load<AudioClip>("Audio/ElectricCircuitSplitting") },
            { "merge", Resources.Load<AudioClip>("Audio/MagnetCombining") }
        };
    }

    public void PlaySound(string sound)
    {
        audioSource.Stop();
        audioSource.clip = audioClips[sound];
        audioSource.Play();
    }
}
