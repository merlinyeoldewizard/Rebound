using UnityEngine;

public class Ball : MonoBehaviour {

    public Player lastPlayerHit;
    public BallMovement ballMovement;

    public float ballSpeed;
    public float ballSpeedLimit;
    public float hitFactorLimit;
    public Vector2 pauseVelocity;

    public void initialise()
    {
        ballMovement.ballSpeed = ballSpeed;
        ballMovement.ballSpeedLimit = ballSpeedLimit;
        ballMovement.hitFactorLimit = hitFactorLimit;
        lastPlayerHit = null;
        lastPlayerHitSet(lastPlayerHit);
        ballMovement.initialise();            
    }

    public void setVelocity(Vector2 velocity)
    {
        ballMovement.rigid.velocity = velocity;
    }
    public Vector2 getVelocity()
    {
        return ballMovement.rigid.velocity;
    }

    public void lastPlayerHitSet(Player player)
    {
        lastPlayerHit = player;
    }
}
