using UnityEngine;

public class HighscoreTracker : MonoBehaviour
{

    //singleton
    private static HighscoreTracker instance;
    public HighscoreTracker Instance { get { return instance; } }

    private int highScore = 0;

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

        if (PlayerPrefs.HasKey("highscore"))
            highScore = PlayerPrefs.GetInt("highscore");
    }

    public void SetHighscore(int score)
    {
        highScore = score;
        PlayerPrefs.SetInt("highscore", score);
        PlayerPrefs.Save();
    }

    public int GetHighscore()
    {
        return highScore;
    }
}
