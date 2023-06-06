using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThomasTheTRAIN : MonoBehaviour
{


    public float speedMultiplier = 15f;
    private float initialSpeed; // initial speed of the cube
    private float distanceMoved = 0f; // distance moved by the cube
    private float maxDistance = 150f; // maximum distance the cube can move

    private void Start()
    {

        // Calculate the initial speed based on the game time
        initialSpeed = Mathf.Lerp(2f, 10f, Mathf.Clamp01((Time.time - GlobalVar.startTime) / 60f)) * speedMultiplier;
        // destroy the cube after the given lifetime

    }

    private void Update()
    {
        // Adjust the speed of the cube dynamically
        distanceMoved += initialSpeed * Time.deltaTime;
        if (distanceMoved >= maxDistance)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.back * initialSpeed * Time.deltaTime);

    }
}
