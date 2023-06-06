using UnityEngine;

public class Bouncer : MonoBehaviour
{
    private float distanceMoved = 0f; // distance moved by the cube
    private float maxDistance = 150f; // maximum distance the cube can move

    public float speedMultiplier = 10f;
    private float Speed; // initial speed of the cube


    private bool isHit = false;

    private float SpawnTime;
    private void Start()
    {
        SpawnTime = Time.time;


    }

    private void Update()
    {
        // Adjust the speed of the cube dynamically

        Speed = Mathf.Lerp(2f, 10f, Mathf.Clamp01((Time.time - GlobalVar.startTime) / 60f)) * speedMultiplier;
        distanceMoved += Speed * Time.deltaTime;
        if (distanceMoved >= maxDistance)
        {
            Destroy(gameObject);
        }
        if (!isHit)
        {
            transform.Translate(Vector3.back * Speed * Time.deltaTime);


            float newSpeedY = 10f * Mathf.Sin(10f * (Time.time - SpawnTime));
            transform.Translate(Vector3.up * newSpeedY * Time.deltaTime);



        }
        else
        {
            transform.Translate(Vector3.back * Speed * 6 * Time.deltaTime);
            transform.Translate(Vector3.up * Speed * Time.deltaTime);
        }

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Thomas"))
        {


            isHit = true;

        }


    }
}
