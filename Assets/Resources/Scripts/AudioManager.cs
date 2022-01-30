using UnityEngine;

public class AudioManager : MonoBehaviour
{

    //singleton
    private static AudioManager instance;
    public AudioManager Instance { get { return instance; } }

    private bool muted = false;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);

        //Mutes on start only if "mute" is stored as "true" in PlayerPrefs
        muted = PlayerPrefs.GetString("mute", "false") == "true";
    }


    public void ToggleMute()
    {
        muted = !muted;
        PlayerPrefs.SetString("mute", muted ? "true" : "false");
        GameObject.Find("MenuMusic").GetComponent<MutableAudioSource>().UpdateMuteStatus();
        GameObject.Find("Canvas").GetComponent<MutableAudioSource>().UpdateMuteStatus();
    }

    public bool GetMuted()
    {
        return muted;
    }

}
