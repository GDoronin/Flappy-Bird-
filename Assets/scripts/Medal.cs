using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Medal : MonoBehaviour
{
    public Sprite medal1;
    public Sprite medal2;
    public Sprite medal3;
    public Sprite medal4;
    public Sprite medal5;
    public Sprite medal6;

    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
        var gameScore = GameManager.gameScore;

        switch(gameScore)
        {
            case 0: 
                _image.sprite = medal1;
                break;
            case 1: case 2:
                _image.sprite = medal2;
                break;
            case 3: case 4: case 5:
                _image.sprite = medal3;
                break;
            case 6: case 7: case 8: case 9:
                _image.sprite = medal4;
                break;
            case 10: case 11: case 12: case 13: case 14: case 15: case 16:
                _image.sprite = medal4;
                break;
            case 17: case 18: case 19: case 20: case 21: case 22: case 23: case 24: case 25: case 26:
                _image.sprite = medal5;
                break;    
            default:
                _image.sprite = medal6;
                break;
        }
    }
}
