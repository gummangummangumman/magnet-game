using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    //Public stuff for main menu - only define these there
    public Text highScoreText;
    public RectTransform happyMagnets;
    public RawImage menuImage;

    private Texture unmutedMenuPic, mutedMenuPic;

    //Public stuff for game over menu - only define these there
    public Text scoreText;

    
    void Start()
    {
        if (highScoreText)
        {
            // in main menu
            highScoreText.text = GameObject.Find("HighscoreTracker").GetComponent<HighscoreTracker>().GetHighscore().ToString("0 000 000 000 000");
            unmutedMenuPic = Resources.Load<Texture>("2D_graphics/MenuNoMagnets");
            mutedMenuPic = Resources.Load<Texture>("2D_graphics/menu_muted");
        }
        else if (scoreText)
        {
            // in "game over" screen
            scoreText.text = GameObject.Find("HighscoreTracker").GetComponent<HighscoreTracker>().GetLastScore().ToString("0 000 000 000 000");
        }
    }

    void Update()
    {
        if (happyMagnets)
        {
            happyMagnets.Rotate(new Vector3(0, 0, 8 * Time.deltaTime), Space.Self);
        }
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

    public void ShowMutedMenu()
    {
        if (GameObject.Find("AudioManager").GetComponent<AudioSource>().mute)
            menuImage.texture = mutedMenuPic;
        else
            menuImage.texture = unmutedMenuPic;
    }
}
