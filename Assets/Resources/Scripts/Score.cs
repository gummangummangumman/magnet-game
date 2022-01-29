using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text text;
    private float time;
    private int score;

    private bool counting = true;

    void Update()
    {
        if (counting)
        {
            time += Time.deltaTime * 6;
            score = (int) Mathf.Floor(time) * 10;
            text.text = score.ToString("0 000 000 000 000");
        }
    }

    public void StopTheCount()
    {
        counting = false;
        GameObject.Find("HighscoreTracker").GetComponent<HighscoreTracker>().SaveScore(score);
        gameObject.SetActive(false);
    }

    public int GetScore()
    {
        return score;
    }
}
