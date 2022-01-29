using UnityEngine;

public class HighscoreTracker : MonoBehaviour
{

    //singleton
    private static HighscoreTracker instance;
    public HighscoreTracker Instance { get { return instance; } }

    private int highScore = 0;
    private int lastScore = 0;

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

    /**
     *  Saves the last score, and also updates and saves the high score if score is higher than current high score.
     */
    public void SaveScore(int score)
    {
        lastScore = score;
        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highscore", score);
            PlayerPrefs.Save();
        }
    }

    public int GetHighscore()
    {
        return highScore;
    }

    public int GetLastScore()
    {
        return lastScore;
    }
}
