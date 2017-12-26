using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public delegate void OnPlayerHit(Ball ball);
    public static event OnPlayerHit onBallPlayerHit;


    public float ballSpeed;
    public float ballSpeedLimit;
    public BallTrail ballTrail;
    public Vector2 direction;
    public Rigidbody2D rigid;
    public float hitFactorLimit;
    public Player player;
    public Goal goal;
    public Ball ball;
    public BoxCollider2D boxColl2D;
    public PortalTile portalTile;

    public void initialise()
    {
        rigid = GetComponent<Rigidbody2D>();
        ball = GetComponent<Ball>();

        boxColl2D = GetComponent<BoxCollider2D>();
        
        ballTrail.initialise(boxColl2D.size.y);
    }

    public void moveBall(float x, float y)
    {
        gameObject.SetActive(true);
        direction = new Vector2(x, y).normalized;
        GetComponent<Rigidbody2D>().velocity = direction * ballSpeed;
    }
    
    void FixedUpdate()
    {
        int layerMask = 1 << 8;
        layerMask = ~layerMask;

        // -- Raycast for ball collision. --
        RaycastHit2D raycastForward = Physics2D.BoxCast(rigid.position, gameObject.GetComponent<Collider2D>().bounds.size,0, direction,16, layerMask);

        if (raycastForward)
        {
            BallMovementOnCollision(raycastForward);
        }

        if (ballSpeed >= ballSpeedLimit)
        {
            ballSpeed = ballSpeedLimit;
        }        
    }

    public void BallMovementOnCollision(RaycastHit2D hit)
    {
        if (!(hit.distance < 0.1F))
        {
            return;
        }

        if (hit.collider.gameObject.tag != "Portal")
        {
            ballTrail.RandomiseColour();

            direction = Vector2.Reflect(direction, hit.normal);
        }
        else if (hit.collider.gameObject.tag == "Portal")
        {
            portalTile = hit.collider.GetComponent<PortalTile>();
            portalTile.teleport(gameObject);
        }

        if (hit.collider.gameObject.tag == "Goal")
        {
            goal = hit.collider.GetComponent<Goal>();
            goal.onGoalHit(ball.lastPlayerHit);
        }
        
        if (hit.collider.gameObject.tag == "Player")
        {
            player = hit.collider.GetComponent<Player>();
            ball.lastPlayerHitSet(player);

            // Makes the ball reflect off the paddle in a specific direction based on its position relative to the paddle.
            //      _
            // | |  /|
            // | | /
            // | |/
            // | |--- -- --- --
            // | |\
            // | | \
            // | | _\|

            GameObject paddle = hit.collider.gameObject;
            float relatvieHitY = transform.position.y - paddle.transform.position.y;
            float relatvieHitX = transform.position.x - paddle.transform.position.x;
            float halfPaddleHeight = paddle.GetComponent<BoxCollider2D>().bounds.size.y / 2;
            direction.y = (relatvieHitY / halfPaddleHeight) * hitFactorLimit;
            direction.x = (relatvieHitX / halfPaddleHeight) * hitFactorLimit;

            if (onBallPlayerHit != null)
            {
                onBallPlayerHit(gameObject.GetComponent<Ball>());
            }
        }

        direction.Normalize();
        rigid.velocity = direction * ballSpeed;
    }
}