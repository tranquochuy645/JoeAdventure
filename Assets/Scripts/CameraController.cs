using UnityEngine;

public class CameraController : MonoBehaviour
{
    public string targetTag = "Player";
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private Transform target;

    private GameObject targetObject;
    public AudioSource ThomasComing;
    public AudioSource Jump;
    public AudioSource Bonk;
    private bool bonking = false;
    

    private float maxDistance = 80f;
    public float maxVolume = 0.5f;

    private float distance;


    void Update()
    {
        if (GlobalVar.isHit)
        {
            if (!bonking)
            {
                Bonk.Play();
                bonking = true;
            }

        }
        else
        {
            bonking = false;
        }
        if (Input.GetButtonDown("Jump"))
        {
            Jump.Play();
        }
        GameObject[] thomasObjects = GameObject.FindGameObjectsWithTag("Thomas");
        if (thomasObjects.Length > 0)
        {
            Transform closestThomas = thomasObjects[0].transform;

            float closestDistance = Vector3.Distance(transform.position, closestThomas.position);
            foreach (GameObject thomasObject in thomasObjects)
            {
                distance = Vector3.Distance(transform.position, thomasObject.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                }
            }


            // Calculate the volume based on the distance
            float volume = Mathf.Clamp01(1f - closestDistance / maxDistance) * maxVolume;

            // Set the volume of the audio source
            ThomasComing.volume = volume;
        }
    }

    private void LateUpdate()
    {
        // Find the game object with the target tag
        if (!targetObject)
        {
            targetObject = GameObject.FindGameObjectWithTag(targetTag);
        }
        else
        {
            // Assign the transform of the target game object to the target variable
            target = targetObject.transform;
            if (target != null && target.position.z > transform.position.z)
            {
                Vector3 desiredPosition = new Vector3(target.position.x, transform.position.y, transform.position.z);
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
                transform.position = smoothedPosition;
            }
        }

    }
}
