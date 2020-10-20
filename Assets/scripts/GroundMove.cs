using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    public float backgroundSpeed;
    private float _objectWidth;
    public float speed;

    private void Start()
    {
        GameManager.gameOver = false;
    }

    public void MoveTheGround(float speed)
    {
        if(GameManager.gameOver == false)
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
    }

    private void Switch(GameObject gameObject)
    {
        _objectWidth = gameObject.GetComponent<BoxCollider2D>().size.x;
        if(transform.position.x <= -_objectWidth)
            transform.position = new Vector2(transform.position.x + 2 * _objectWidth, transform.position.y);
    }

    private void ObjectDestroy(GameObject gameObject)
    {
        if(transform.position.x < GameManager.bottomLeft.x - gameObject.GetComponent<BoxCollider2D>().size.x)
            Destroy(gameObject);
    }

    private void Update()
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
                ObjectDestroy(gameObject);  
                break;
            default: break;
        }
    }
}
