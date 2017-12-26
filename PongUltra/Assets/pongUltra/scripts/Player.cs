using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int speed;
    public string controllerName;
    public PlayerController playerController;
    public GameObject paddle;
    public string playerName;
    public int team;
    public Transform spawn;
    public Score score;
    public Goal goal;
    public int startingWaypointIndex;
    public List<Transform> waypoint;
    
    public void initialise()
    {
        transform.position = spawn.position;
        playerController.initialise();        
        score.setScoreNumber(0);
    }
}
