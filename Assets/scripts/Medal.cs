using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Medal : MonoBehaviour
{
    public Sprite medal_1;
    public Sprite medal_2;
    public Sprite medal_3;
    public Sprite medal_4;
    public Sprite medal_5;
    public Sprite medal_6;

    Image image;
    void Start()
    {
        image = GetComponent<Image>();
        int gameScore = GameManager.gameScore;

        switch(gameScore)
        {
            case 0: 
                image.sprite = medal_1;
                break;
            case 1: case 2:
                image.sprite = medal_2;
                break;
            case 3: case 4: case 5:
                image.sprite = medal_3;
                break;
            case 6: case 7: case 8: case 9:
                image.sprite = medal_4;
                break;
            case 10: case 11: case 12: case 13: case 14: case 15: case 16:
                image.sprite = medal_4;
                break;
            case 17: case 18: case 19: case 20: case 21: case 22: case 23: case 24: case 25: case 26:
                image.sprite = medal_5;
                break;    
            default:
                image.sprite = medal_6;
                break;
        }
    }
}
