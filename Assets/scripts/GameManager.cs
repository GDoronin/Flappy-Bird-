using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // References
    public GameObject gameOverCanvas;
    public GameObject score;
    public GameObject getReadyImage;
    public GameObject pauseButton;
    public GameObject powerUpText;
    public static Vector2 bottomLeft;
    public GameObject newPanel;
    public GameObject scorePanel;
    public GameObject highScorePanel;

    // Game States
    public static bool gameOver;
    public static bool gameHasStarted;
    public static bool gameIsPaused;
    public static bool isPowerUp;


    public static int gameScore;
    public AudioSource swooshSound;

    void Start()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));

        gameOver = false;
        gameHasStarted = false;
        gameIsPaused = false;
    }

    public void GameHasStarted()
    {
        gameHasStarted = true;

        score.SetActive(true);
        getReadyImage.SetActive(false);
        pauseButton.SetActive(true);
        powerUpText.SetActive(true);
    }

    public void GameOver()
    {
        gameOver = true;
        gameScore = score.GetComponent<Score>().GetScore();

        score.SetActive(false);
        gameOverCanvas.SetActive(true);
        pauseButton.SetActive(false);
        powerUpText.SetActive(false);

        if(Score.isNewHighscore == true)
            newPanel.SetActive(true);
        scorePanel.GetComponent<Text>().text = gameScore.ToString();
        highScorePanel.GetComponent<Text>().text = PlayerPrefs.GetInt("highscore").ToString();
    }

    public void OnOKButtonPressed()
    {
        swooshSound.Play();
        SceneManager.LoadScene("Game");
    }

    public void OnMenuButtonPressed()
    {
        swooshSound.Play();
        SceneManager.LoadScene("Menu");
    }
}
