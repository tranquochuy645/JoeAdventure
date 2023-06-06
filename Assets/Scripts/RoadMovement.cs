using UnityEngine;

public class RoadMovement : MonoBehaviour
{
    
    private float distanceMoved = 0f; // distance moved by the cube
    private float maxDistance = 320f; // maximum distance the cube can move
    private float speedMultiplier=5f;
    private float Speed; // initial speed of the cube
     
    


    private void Update()
    {
        
        float Speed = Mathf.Lerp(2f, 10f, Mathf.Clamp01((Time.time-GlobalVar.startTime) / 60f))*speedMultiplier;
        transform.Translate(Vector3.back * Speed * Time.deltaTime);
        distanceMoved += Speed * Time.deltaTime;
        if (distanceMoved >= maxDistance)
        {
            Destroy(gameObject);
        }
    }
}
