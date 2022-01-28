using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public Score scoreCounter;
    public Text finalScoreText;

    public void ActivateGameOverUI()
    {
        int score = scoreCounter.GetScore();
        scoreCounter.StopTheCount();
        transform.GetChild(0).gameObject.SetActive(true);
        finalScoreText.text = "Score: " + score.ToString();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
