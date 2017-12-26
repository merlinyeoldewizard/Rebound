using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrail : MonoBehaviour {

    [SerializeField]
    private TrailRenderer trail;

    public float startAplha;

    // Use this for initialization
    void Start()
    {
        trail.sortingLayerName = "ParticleFX";
        trail.sortingOrder = 30;
    }

    public void initialise(float width)
    {
        trail.startWidth = width;
    }

    private float RandomNumber()
    {
        return Random.Range(0f, 1f);
    }

    public void RandomiseColour()
    {
        trail.startColor = new Color(RandomNumber(), RandomNumber(), RandomNumber(), startAplha);
        trail.endColor = new Color(RandomNumber(), RandomNumber(), RandomNumber(), 1f);
    }
}
