using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    // References.
    public Score score;
    public GameManager gameManager;
    public ColumnSpawner columnSpawner;
    public Text powerUpTimer;
    public GameObject currentScore;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidBody;
    public float speed;

    // Variables.
    private float _timer;
    public float powerUpTime;
    private int _angle;
    private float _time;
    private string _powerUpText;
    private bool _touchedGround;

    // Настройки физики птицы.
    public float topperYVelocity;
    public float lowerYVelocity;
    public int maxAngle;
    public int minAngle;
    public int plusAngleOnRising;
    public int minusAngleOnFalling;
    public float gravityScaleOnRising;
    public float gravityScaleOnFalling;

    // Звуки.
    public AudioSource jumpSound;
    public AudioSource hitSound;
    public AudioSource swooshSound;
    public AudioSource scoreSound;

    private void Jump()
    {
        _rigidBody.velocity = Vector2.zero;
        _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, speed);
        jumpSound.Play();
    }

    private void Rotate()
    {
        if(_rigidBody.velocity.y > topperYVelocity)
        {
            _rigidBody.gravityScale = gravityScaleOnRising;
            if(_angle < maxAngle)
                _angle += plusAngleOnRising;
        }
        else if(_rigidBody.velocity.y < -lowerYVelocity)
        {
            _rigidBody.gravityScale = gravityScaleOnFalling;
            if(_angle > -minAngle)
                _angle -= minusAngleOnFalling;
        }

        if(_touchedGround == false)
            transform.rotation = Quaternion.Euler(0, 0, _angle);  
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.gameOver != false) return;
        switch(collision.tag)
        {
            case "Column":
                score.PlusScore();
                currentScore.GetComponent<Text>().text = Score.score.ToString();
                scoreSound.Play();
                break;
            case "PowerUp":
                GameManager.isPowerUp = true;
                Destroy(collision.gameObject);
                break;
            case "Ground":
                hitSound.Play();
                gameManager.GameOver();
                GameOver();
                break;
            case "Pipe":
                if(GameManager.isPowerUp == true)
                {
                    Destroy(collision.gameObject);
                    hitSound.Play();
                }
                else
                {
                    gameManager.GameOver();
                    hitSound.Play();
                }
                break;
            default: break;
        }
    }

    private void GameOver()
    {
        _touchedGround = true;
    }

    private void Start()
    {   
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        currentScore.GetComponent<Text>();

        _rigidBody.gravityScale = 0;
    }

    private void Update()
    {
        if((Input.GetMouseButtonDown(0)) && (GameManager.gameOver == false) && (GameManager.gameIsPaused == false))
        {
            if(GameManager.gameHasStarted == false)
            {
                _rigidBody.gravityScale = 0.8f;
                Jump();
                columnSpawner.SpawnTheColumn();
                gameManager.GameHasStarted();
            }
            else
                Jump();
        }

        if(GameManager.isPowerUp == true)
        {
            _timer += Time.deltaTime;
            _time = ((int)((powerUpTime - _timer) * 100)) / 100f;
            _powerUpText = _time.ToString();
            powerUpTimer.text = _powerUpText;
            if(_timer >= powerUpTime)
            {
                swooshSound.Play();
                GameManager.isPowerUp = false;
                _timer = 0;
                _time = 0;
            }
        } 
        else
        {
            powerUpTimer.text = "";
        }
        Rotate();    
    }
}
