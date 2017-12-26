using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaypointList : MonoBehaviour {

    public List<Transform> waypoints;

    public List<Transform> unpack()
    {
        return waypoints;
    }
}
