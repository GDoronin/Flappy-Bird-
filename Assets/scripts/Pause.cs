using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    Image image;

    // References
    public Sprite playSpriteButton;
    public Sprite pausedSpriteButton;

    private void Start()
    {
        image = GetComponent<Image>();
    }
    public void OnPausedGame()
    {
        if(GameManager.gameIsPaused == false)
        {
            Time.timeScale = 0;
            image.sprite = playSpriteButton;
            GameManager.gameIsPaused = true;
        }
        else
        {
            Time.timeScale = 1;
            image.sprite = pausedSpriteButton;
            GameManager.gameIsPaused = false;
        }
    }
}
