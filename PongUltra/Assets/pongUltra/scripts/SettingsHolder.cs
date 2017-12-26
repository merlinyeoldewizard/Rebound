using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsHolder : MonoBehaviour {

    public static SettingsHolder instance;


    public bool acceleratorOnOff;
    public float acceleratorModifier;

    public bool ballSizeOnOff;
    public float ballSizeModifier;

    public int scoreLimit;

    public int playerSpeed;

    public float ballSpeed;
    public float ballSpeedLimit;

    public int ballCount;

    public float hitFactor;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void defaultSettings()
    {
        scoreLimit = 5;
        playerSpeed = 11;
        acceleratorOnOff = false;
        ballSizeOnOff = false;
        ballSpeed = 10.0F;
        hitFactor = 0.3F;
        ballSpeedLimit = 50;
        ballCount = 1;
    }
}
