using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    //public float speed;
    public float backgroundSpeed;
    float objectWidth;
    public float speed;

    void Start()
    {
        GameManager.gameOver = false;
    }

    public void MoveTheGround(float speed)
    {
        if(GameManager.gameOver == false)
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
    }

    void Switch(GameObject gameObject)
    {
        objectWidth = gameObject.GetComponent<BoxCollider2D>().size.x;
        if(transform.position.x <= -objectWidth)
            transform.position = new Vector2(transform.position.x + 2 * objectWidth, transform.position.y);
    }

    void objectDestroy(GameObject gameObject)
    {
        if(transform.position.x < GameManager.bottomLeft.x - gameObject.GetComponent<BoxCollider2D>().size.x)
            Destroy(gameObject);
    }

    void Update()
    {
        switch(gameObject.tag)
        {
            case "Ground": 
                MoveTheGround(speed);
                Switch(gameObject);
                break;
            case "Background":
                MoveTheGround(backgroundSpeed);
                Switch(gameObject);
                break;         
            case "Column": case "PowerUp":
                MoveTheGround(speed);
                objectDestroy(gameObject);  
                break;
            default: break;
        }
    }
}
