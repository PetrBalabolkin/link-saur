using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public int maxScore = 0;
    public TMP_Text scoreText;
    public TMP_Text maxScoreText;

    private void Start()
    {
        maxScore = PlayerPrefs.GetInt("maxScore", 0);
        score = 0;
        UpdateScoreText();
        UpdateMaxScoreText();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;

        if (score > maxScore)
        {
            maxScore = score;
            PlayerPrefs.SetInt("maxScore", maxScore);
            PlayerPrefs.Save();
            UpdateMaxScoreText();
        }
        
        UpdateScoreText();
    }

    public void DecreaseScore(int amount)
    {
        if (score > 0)
        {
            score -= amount;
            if (score < 0)
            {
                score = 0;
            }
        }
        
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    private void UpdateMaxScoreText()
    {
        maxScoreText.text = "Maximum: " + maxScore.ToString();
    }
}