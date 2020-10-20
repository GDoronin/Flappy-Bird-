using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    private Image _image;

    // References.
    public Sprite playSpriteButton;
    public Sprite pausedSpriteButton;

    private void Start()
    {
        _image = GetComponent<Image>();
    }
    public void OnPausedGame()
    {
        if(GameManager.gameIsPaused == false)
        {
            Time.timeScale = 0;
            _image.sprite = playSpriteButton;
            GameManager.gameIsPaused = true;
        }
        else
        {
            Time.timeScale = 1;
            _image.sprite = pausedSpriteButton;
            GameManager.gameIsPaused = false;
        }
    }
}
