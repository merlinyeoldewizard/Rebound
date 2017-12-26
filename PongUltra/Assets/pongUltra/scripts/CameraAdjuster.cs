using System.Collections;
using UnityEngine;

public class CameraAdjuster : MonoBehaviour
{

    public Camera mainCamera;

    public string adjustmentAxis;

    public Transform cameraMarker;
    public Transform botLeft;
    public Transform topRight;

    public Vector2 botLeftScreenPos;
    public Vector2 topRightScreenPos;

    // Use this for initialization
    void Start()
    {
        botLeftScreenPos = mainCamera.WorldToScreenPoint(botLeft.position).normalized;
        topRightScreenPos = mainCamera.WorldToScreenPoint(topRight.position).normalized;
        mainCamera.transform.position = cameraMarker.position;

        StartCoroutine(AdjustScreen());
    }

    IEnumerator AdjustScreen()
    {
        while (botLeftScreenPos.y - mainCamera.pixelRect.yMin != 0.0F && topRightScreenPos.y - mainCamera.pixelRect.yMax != 0.0F)
        {
            botLeftScreenPos = mainCamera.WorldToScreenPoint(botLeft.position).normalized;
            topRightScreenPos = mainCamera.WorldToScreenPoint(topRight.position).normalized;

            if (adjustmentAxis == "x")
                mainCamera.orthographicSize = mainCamera.orthographicSize - (mainCamera.aspect * botLeftScreenPos).normalized.x;
            else if (adjustmentAxis == "y")
                mainCamera.orthographicSize = mainCamera.orthographicSize - (mainCamera.aspect * botLeftScreenPos).normalized.y;

            yield return null;
        }
    }
}
