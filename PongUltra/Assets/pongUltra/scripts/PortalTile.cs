using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTile : MonoBehaviour {

    [Tooltip("The portal the ball will teleport to when it hits this portal.")]
    public PortalTile targetPortal;    //Set this to the portal you want the ball to go to (in the inspector).

    public void teleport(GameObject ball)
    {
        BallMovement b = ball.GetComponent<BallMovement>();
        Vector2 vectorDiff = b.transform.position - transform.position;

        float thisSize = GetComponent<BoxCollider2D>().bounds.size.y;
        Vector2 targetSize = targetPortal.GetComponent<BoxCollider2D>().bounds.size;
        
        float halfTargetSizex = (targetSize.x / 2) + 0.2F;
        float ratio = vectorDiff.y / thisSize;

        if (vectorDiff.x > 0.0F)
        {
            halfTargetSizex = halfTargetSizex * -1;
        }

        b.transform.position = new Vector2(targetPortal.transform.position.x + (halfTargetSizex),
                                              targetPortal.transform.position.y + (targetSize.y * ratio));

        //float radians = targetPortal.transform.rotation.z * Mathf.Deg2Rad;
        //float sin = Mathf.Sin(radians);
        //float cos = Mathf.Cos(radians);

        //float tx = b.direction.x;
        //float ty = b.direction.y;

        //b.direction = new Vector2(cos * tx - sin * ty, sin * tx + cos * ty);
    }
}