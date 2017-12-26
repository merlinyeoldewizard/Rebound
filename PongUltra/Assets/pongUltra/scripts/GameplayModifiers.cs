using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class GameplayModifiers : MonoBehaviour {
    
    public void acceleratorMode(Ball ball)
    {
        ball.ballMovement.ballSpeed = ball.ballMovement.ballSpeed * (1 + SettingsHolder.instance.acceleratorModifier);
    }

    public void ballSize()
    {
        foreach (Ball ball in GameManager.instance.balls)
        {
            Vector3 ballSize = ball.transform.localScale;
            ball.transform.localScale = new Vector3(ballSize.x * SettingsHolder.instance.ballSizeModifier, ballSize.y * SettingsHolder.instance.ballSizeModifier);
        }
       
    }


}
