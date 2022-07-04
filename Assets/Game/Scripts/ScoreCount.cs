using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    private int score = 0;
    private Text scoreText;

    private void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
    }

    public void ScoreHit()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
