using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour{
  
    public List<Player> players = new List<Player>();
    
    public List<WaypointList> waypoints = new List<WaypointList>();

    public void createPlayers(int numberOfPlayers, int playerSpeed)
    {
        for (int i = 0; i < numberOfPlayers; i++)
        {
            players[i].speed = playerSpeed;
            players[i].initialise();
        }
    }

    public void resetPlayers()
    {
        foreach (Player player in players)
        {
            player.transform.position = player.spawn.position;
        }
    }

}
