using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    
    public GameObject ballObj;
    [HideInInspector]
    public List<Ball> balls = new List<Ball>();
    public Transform ballSpawn;
    public float ballSpeed;
    public float hitFactorLimit;
    public float ballSpeedLimit;

    public Transform spawnPos;

    public PlayerManager playerManager;
    public int numberOfPlayers;

    public GameState gameState;
    public GameplayModifiers gamePlayModifiers;

    public List<string> controllerNames = new List<string>();
    public List<Transform> spawns = new List<Transform>();
    public List<Score> score = new List<Score>();
    public List<Goal> goals = new List<Goal>();

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }        
    }
    
    public void Start()
    {
        gameSetUp();
        gameModifiersSetUp();
        gameStart();
    }

    private void gameModifiersSetUp() // Subscribes eneabled game settings from the SettingsHolder.
    {
        if (SettingsHolder.instance.acceleratorOnOff)
        {
            BallMovement.onBallPlayerHit += gamePlayModifiers.acceleratorMode;
        }

        if (SettingsHolder.instance.ballSizeOnOff)
        {
            gamePlayModifiers.ballSize();
        }
    }

    //Unsubsribe events on scene reload or scene change.
    private void OnDestroy()
    {
        BallMovement.onBallPlayerHit -= gamePlayModifiers.acceleratorMode;
    }

    private void gameSetUp()
    {
        playerManager.createPlayers(numberOfPlayers, SettingsHolder.instance.playerSpeed);

        //Initialising ball settings
        for (int i = 0; i < SettingsHolder.instance.ballCount; i++)
        {
            GameObject newBall = Instantiate(ballObj) as GameObject;

            Ball ball = newBall.GetComponent<Ball>();

            ballSpeed = SettingsHolder.instance.ballSpeed;
            ball.ballSpeed = ballSpeed;

            ball.ballSpeedLimit = ballSpeedLimit;

            hitFactorLimit = SettingsHolder.instance.hitFactor;

            ball.hitFactorLimit = hitFactorLimit;

            ball.initialise();

            balls.Add(ball);
        }

        gameState.initialise();        
    }

    private void gameStart()
    {
        Vector2 ballStartDirection = (spawnPos.position - ballSpawn.transform.position).normalized;
        gameState.newRound(ballStartDirection.x, ballStartDirection.y);
    }
}