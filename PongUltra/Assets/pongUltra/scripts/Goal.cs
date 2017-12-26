using UnityEngine;

public class Goal : MonoBehaviour {
    public Player player;
    public void onGoalHit(Player lastPlayerHit)
    {
        Vector2 ballNewStartDirection = (player.spawn.transform.position - GameManager.instance.ballSpawn.transform.position).normalized;

        //If the ball touches a goal when no player has touched it...
        if (lastPlayerHit == null)
        {
            GameManager.instance.gameState.newRound(ballNewStartDirection.x, ballNewStartDirection.y);
        }
        // Own goal.
        else if (player == lastPlayerHit)
        {
            player.score.changeScore(-1);
            GameManager.instance.gameState.newRound(ballNewStartDirection.x, ballNewStartDirection.y);
        }
        //Scoring a point.
        else
        {
            lastPlayerHit.score.changeScore(1);
            GameManager.instance.gameState.newRound(ballNewStartDirection.x, ballNewStartDirection.y);
        }        
    }
}
