using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text text;
    private float time;
    private int score;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * 6;
        score = (int) Mathf.Floor(time) * 10;
        text.text = score.ToString("000000000000");
    }
}
