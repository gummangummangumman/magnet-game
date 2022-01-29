using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public Text highScoreText;

    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        if (highScoreText)
            highScoreText.text = GameObject.Find("HighscoreTracker").GetComponent<HighscoreTracker>().GetHighscore().ToString("0 000 000 000 000");

        if (scoreText)
            scoreText.text = GameObject.Find("HighscoreTracker").GetComponent<HighscoreTracker>().GetLastScore().ToString("0 000 000 000 000");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        print("You quit the game!");
        Application.Quit();
    }
}
