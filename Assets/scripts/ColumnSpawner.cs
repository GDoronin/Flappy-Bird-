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

    private float _timer;
    private float _timerPu = 1;
    private float _randY;
    private float _randYpu;


    private void Update()
    {
        if ((GameManager.gameOver != false) || (GameManager.gameHasStarted != true)) return;

        _timer += Time.deltaTime;

        if(_timer >= maxTime)
        {
            SpawnTheColumn();
            _timer = 0;
        }

        if (GameManager.isPowerUp != false) return;
        _timerPu += Time.deltaTime;

        if (!(_timerPu >= maxTimePU)) return;
        SpawnPowerUp();
        _timerPu = 0;
    }

    public void SpawnTheColumn()
    {
        GameObject newColumn  = Instantiate(column);
        _randY = Random.Range(minYForColumn, maxYForColumn);
        newColumn.transform.position = new Vector2(transform.position.x, _randY);
    }

    public void SpawnPowerUp()
    {
        GameObject newPowerUp = Instantiate(powerUp);
        _randYpu = Random.Range(minYForColumn, maxYForColumn);
        if(Mathf.Abs(_randYpu - _randY) < powerUpNearTheColumnRange)
            if(_randYpu > _randY)
                _randYpu += powerUpOffset;
            else
                _randYpu -= powerUpOffset;
        newPowerUp.transform.position = new Vector2(transform.position.x, _randYpu);
        maxTimePU = ((int)Random.Range(powerUpLeftTimeEdge, powerUpRightTimeEdge)) * maxTime;
    }
}
