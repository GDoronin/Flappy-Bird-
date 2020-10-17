using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColumnSpawner : MonoBehaviour
{
    public GameObject column;
    public GameObject powerUp;
    
    public float maxTime;
    public float maxTimePU;
    public float maxYForColumn;
    public float minYForColumn;
    public int powerUpLeftTimeEdge;
    public int powerUpRightTimeEdge;
    public float powerUpNearTheColumnRange;
    public float powerUpOffset;

    float timer;
    float timerPU = 1;
    float randY;
    float randYPU;
 

    void Update()
    {
        if((GameManager.gameOver == false) && (GameManager.gameHasStarted == true)) 
        {
            timer += Time.deltaTime;
            if(timer >= maxTime)
            {
                SpawnTheColumn();
                timer = 0;
            }

            if(GameManager.isPowerUp == false)
            {
                timerPU += Time.deltaTime;
                if(timerPU >= maxTimePU)
                {
                    SpawnPowerUp();
                    timerPU = 0;
                }
            }
        }        
    }

    public void SpawnTheColumn()
    {
        GameObject newColumn  = Instantiate(column);
        randY = Random.Range(minYForColumn, maxYForColumn);
        newColumn.transform.position = new Vector2(transform.position.x, randY);
    }

    public void SpawnPowerUp()
    {
        GameObject newPowerUp = Instantiate(powerUp);
        randYPU = Random.Range(minYForColumn, maxYForColumn);
        if(Mathf.Abs(randYPU - randY) < powerUpNearTheColumnRange)
            if(randYPU > randY)
                randYPU = randYPU + powerUpOffset;
            else
                randYPU = randYPU - powerUpOffset;
        newPowerUp.transform.position = new Vector2(transform.position.x, randYPU);
        maxTimePU = ((int)Random.Range(powerUpLeftTimeEdge, powerUpRightTimeEdge)) * maxTime;
    }
}
