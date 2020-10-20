using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score;
    public static bool isNewHighscore;

    private void Start()
    {
        score = 0;
        isNewHighscore = false;
    }

    public void PlusScore()
    {
        score += 1;
        if (score <= PlayerPrefs.GetInt("highscore")) return;
        PlayerPrefs.SetInt("highscore", score);
        isNewHighscore = true;
    }
    public int GetScore()
    {
        return score;
    }
}
