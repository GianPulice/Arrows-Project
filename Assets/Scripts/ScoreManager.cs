using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;

    public void UpdateScore(int points)
    {
        score += points;
    }

    public int GetScore()
    {
        return score;
    }
}
