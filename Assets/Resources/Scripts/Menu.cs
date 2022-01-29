using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = GameObject.Find("HighscoreTracker").GetComponent<HighscoreTracker>().GetHighscore().ToString("0 000 000 000 000");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        print("You quit the game!");
        Application.Quit();
    }
}
