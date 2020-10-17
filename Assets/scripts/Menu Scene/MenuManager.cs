using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public AudioSource swooshSound;
    public void OnPlayButtonPressed()
    {
        swooshSound.Play();
        SceneManager.LoadScene("Game");
    }

    public void OnRateButtonPressed()
    {
        swooshSound.Play();
#if UNITY_ANDROID
        Application.OpenURL("market://details?id=com.SecondYearGames.FlappyBird");
#endif
    }
}
