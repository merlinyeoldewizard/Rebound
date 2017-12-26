using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public string controllerName;
    public float input;

    public Player player;
    private int count;
    private int lastWaypointIndex;
    public Transform lastWaypoint;
    public Transform currentWaypoint;
    public Transform nextWaypoint;

    public void initialise()
    {
        player = gameObject.GetComponent<Player>();
        controllerName = player.controllerName;
        speed = player.speed;
        count = player.waypoint.Count;
        lastWaypointIndex = count - 1;
        lastWaypoint = player.waypoint[lastWaypointIndex];
        currentWaypoint = player.waypoint[player.startingWaypointIndex];
        nextWaypoint = player.waypoint[player.waypoint.IndexOf(currentWaypoint) + 1];
    }
    void Update()
    {
        float inputDirection = Input.GetAxisRaw(controllerName);
        input = inputDirection * speed * Time.deltaTime;
        
        for (int i = player.waypoint.Count - 1; i > -1; i--)
        {
            if (player.waypoint[i] == null)
            {
                player.waypoint.RemoveAt(i);
                count = player.waypoint.Count;
                lastWaypointIndex = count - 1;
                lastWaypoint = player.waypoint[lastWaypointIndex];
            }
            else
            {
                count = player.waypoint.Count;
                lastWaypointIndex = count - 1;
            }
        }
        
        if (transform.position != player.waypoint[lastWaypointIndex].position)
        {
            float angleDifference = (currentWaypoint.eulerAngles.z + nextWaypoint.eulerAngles.z) / 2;
            transform.eulerAngles = new Vector3(0, 0, angleDifference);
        }

        //The nested "if" statements determine if the player is allowed to move along the path or not.
        //If the player puts in a posative input, the player will move towards the next point along the path.
        //Similarly, a negative inout will move the player back towards the "current" waypoint.
        if (GameManager.instance.gameState.isPaused != true)
        {
            if (input > 0)
            {
                if (currentWaypoint != lastWaypoint)
                {
                    transform.position = Vector2.MoveTowards(transform.position, nextWaypoint.position, input);
                }
                if (transform.position == nextWaypoint.position)
                {
                    if (nextWaypoint != lastWaypoint)
                    {
                        currentWaypoint = nextWaypoint;
                        nextWaypoint = player.waypoint[player.waypoint.IndexOf(currentWaypoint) + 1];
                    }
                }
            }

            if (input < 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, currentWaypoint.position, -input);

                if (transform.position == currentWaypoint.position)
                {
                    if (currentWaypoint != player.waypoint[0])
                    {
                        nextWaypoint = currentWaypoint;
                        currentWaypoint = player.waypoint[player.waypoint.IndexOf(currentWaypoint) - 1];
                    }
                }
            }
        }
    }
}
