using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
public class TestSuite
{
    [UnityTest]
    public IEnumerator ColumnsMoveLeft()
    {
        GameObject column = MonoBehaviour.Instantiate(Resources.Load<GameObject>("prefabs/Column"));
        float startingX = column.transform.position.x;
        yield return new WaitForSeconds(0.1f);
        Assert.Less(column.transform.position.x, startingX);
        Object.Destroy(column); 
    }

    [UnityTest]
    public IEnumerator PlayerGroundCollision()
    {
        GameObject ground = MonoBehaviour.Instantiate(Resources.Load<GameObject>("prefabs/Ground"));
        GameObject bird = MonoBehaviour.Instantiate(Resources.Load<GameObject>("prefabs/bird"));
        ground.transform.position = bird.transform.position;
        yield return new WaitForSeconds(0.1f);
        Assert.True(GameManager.gameOver);
        Object.Destroy(ground); 
        Object.Destroy(bird); 
    }


    [UnityTest]
    public IEnumerator PlayerNoPowerUpPipeCollision()
    {
        GameObject column = MonoBehaviour.Instantiate(Resources.Load<GameObject>("prefabs/PipeUp"));
        GameObject bird = MonoBehaviour.Instantiate(Resources.Load<GameObject>("prefabs/bird"));
        column.transform.position = bird.transform.position;
        yield return new WaitForSeconds(0.1f);
        Assert.True(GameManager.gameOver);
        Object.Destroy(column); 
        Object.Destroy(bird); 
    }

    [UnityTest]
    public IEnumerator PlayerPowerUpCollision()
    {
        GameObject powerUp = MonoBehaviour.Instantiate(Resources.Load<GameObject>("prefabs/PowerUp"));
        GameObject bird = MonoBehaviour.Instantiate(Resources.Load<GameObject>("prefabs/bird"));
        powerUp.transform.position = bird.transform.position;
        yield return new WaitForSeconds(0.1f);
        Assert.True(GameManager.isPowerUp);
        Object.Destroy(powerUp); 
        Object.Destroy(bird); 
    }

    [UnityTest]
    public IEnumerator PlayerWithPowerUpPipeCollision()
    {
        GameObject column = MonoBehaviour.Instantiate(Resources.Load<GameObject>("prefabs/PipeUp"));
        GameObject bird = MonoBehaviour.Instantiate(Resources.Load<GameObject>("prefabs/bird"));
        column.transform.position = bird.transform.position;
        yield return new WaitForSeconds(0.1f);
        Assert.False(GameManager.gameOver);
        Object.Destroy(column); 
        Object.Destroy(bird); 
    }
}