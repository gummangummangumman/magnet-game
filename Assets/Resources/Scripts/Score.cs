using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text text;
    private float time;
    private int score;

    private bool counting = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (counting)
        {
            time += Time.deltaTime * 6;
            score = (int) Mathf.Floor(time) * 10;
            text.text = score.ToString("000000000000");
        }
    }

    public void StopTheCount()
    {
        GameObject.Find("HighscoreTracker").GetComponent<HighscoreTracker>().SetHighscore(score);
        gameObject.SetActive(false);
    }

    public int GetScore()
    {
        return score;
    }
}
