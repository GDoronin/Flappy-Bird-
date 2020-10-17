using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    // References
    public Score score;
    public GameManager gameManager;
    public ColumnSpawner columnSpawner;
    public Text powerUpTimer;
    public GameObject currentScore;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidBody;
    public float speed;

    // Variables
    float timer;
    public float powerUpTime;
    int angle;
    float time;
    string powerUpText;
    bool touchedGround;

    // Настройки физики птицы 
    public float topperYVelocity;
    public float lowerYVelocity;
    public int maxAngle;
    public int minAngle;
    public int plusAngleOnRising;
    public int minusAngleOnFalling;
    public float gravityScaleOnRising;
    public float gravityScaleOnFalling;

    // Звуки
    public AudioSource jumpSound;
    public AudioSource hitSound;
    public AudioSource swooshSound;
    public AudioSource scoreSound;

    void Jump()
    {
        rigidBody.velocity = Vector2.zero;
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, speed);
        jumpSound.Play();
    }

    void Rotate()
    {
        if(rigidBody.velocity.y > topperYVelocity)
        {
            rigidBody.gravityScale = gravityScaleOnRising;
            if(angle < maxAngle)
                angle = angle + plusAngleOnRising;
        }
        else if(rigidBody.velocity.y < -lowerYVelocity)
        {
            rigidBody.gravityScale = gravityScaleOnFalling;
            if(angle > -minAngle)
                angle = angle - minusAngleOnFalling;
        }

        if(touchedGround == false)
            transform.rotation = Quaternion.Euler(0, 0, angle);  
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(GameManager.gameOver == false)
        {
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
    }

    void GameOver()
    {
        touchedGround = true;
    }  

    void Start()
    {   
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentScore.GetComponent<Text>();

        rigidBody.gravityScale = 0;
    }

    void Update()
    {
        if((Input.GetMouseButtonDown(0)) && (GameManager.gameOver == false) && (GameManager.gameIsPaused == false))
        {
            if(GameManager.gameHasStarted == false)
            {
                rigidBody.gravityScale = 0.8f;
                Jump();
                columnSpawner.SpawnTheColumn();
                gameManager.GameHasStarted();
            }
            else
                Jump();
        }

        if(GameManager.isPowerUp == true)
        {
            timer += Time.deltaTime;
            time = ((int)((powerUpTime - timer) * 100)) / 100f;
            powerUpText = time.ToString();
            powerUpTimer.text = powerUpText;
            if(timer >= powerUpTime)
            {
                swooshSound.Play();
                GameManager.isPowerUp = false;
                timer = 0;
                time = 0;
            }
        } 
        else
        {
            powerUpTimer.text = "";
        }
        Rotate();    
    }
}
