using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class GameState : MonoBehaviour {

    public GameManager gameManager;
    public GameObject pauseMenu;
    public bool isPaused;
    public Vector2 currentBallVelocity;
    public Text pauseVictoryText;

    public int scoreLimit;

    public float startingCountdownTime;


    public void initialise()
    {
        scoreLimit = SettingsHolder.instance.scoreLimit;
        isPaused = false;
        pauseMenu.SetActive(false);
    }
    
    private void Update()
    {
        //-----> Put victory conditions here... PROPERLY <-----
        foreach (Player p in gameManager.playerManager.players)
        {
            if(p.score.scoreNumber == scoreLimit)
            {
                VictoryState(p.controllerName);
            }
        }

        if (Input.GetButtonDown("Cancel"))
        {
            if (isPaused == false)
            {
                pauseGame();
            }
            else if (isPaused == true)
            {
                unPauseGame();
            }
        }
    }

    //Pause Menu
    public void pauseGame()
    {
        foreach (Ball ball in GameManager.instance.balls)
        {
            ball.pauseVelocity = ball.getVelocity();
            ball.setVelocity(new Vector2(0, 0));
        }
        
        pauseMenu.SetActive(true);
        pauseVictoryText.text = "Game Paused";
        isPaused = true;
    }
    public void unPauseGame()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
        foreach (Ball ball in GameManager.instance.balls)
        {
            ball.setVelocity(ball.pauseVelocity);
        }
    }


    //New round
    public void newRound(float x, float y)
    {
        foreach (Ball ball in GameManager.instance.balls)
        {
            ball.transform.position = gameManager.ballSpawn.position;
            gameManager.playerManager.resetPlayers();
            ball.ballMovement.ballSpeed = gameManager.ballSpeed;
            ball.lastPlayerHitSet(null);
            ball.ballMovement.moveBall(0, 0);
        }
        
        StartCoroutine(countDown(x, y));
    }

    IEnumerator countDown(float x, float y)
    {
        float remainingTime = startingCountdownTime;
        while (remainingTime > 0)
        {
            yield return new WaitForSeconds(1);
            if (!isPaused)
            {
                remainingTime--;
            }
        }
        foreach (Ball ball in GameManager.instance.balls)
        {
            if (GameManager.instance.balls.Count > 1)
            {
                //if ()
                //{

                //}
                x = Random.Range(-1.0F, 1.0F);
                y = Random.Range(-1.0F, 1.0F);
            }
            ball.ballMovement.moveBall(x, y);
        }
    }


    //Game Victory
    public void VictoryState(string playerName)
    {
        pauseGame();
        pauseVictoryText.text = "Player " + playerName + "\n wins!";
    }
}
