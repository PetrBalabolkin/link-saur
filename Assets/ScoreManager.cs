using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;

    private void Start()
    {
        UpdateScoreText();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
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
        
    }
}
