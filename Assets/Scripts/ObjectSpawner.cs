using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectPrefabs; // array of game object prefabs to choose from
  
    private float objectSpeed = 10f;
    private float spawnDistance = 0f;
    private float spawnRange = 4f;

    public float initialSpawnDelay =3f;

    private float nextSpawnTime;
    
    private void Update()
    {   
        float spawnDelay = initialSpawnDelay* (1f/(1f + 5*((Time.time-GlobalVar.startTime) / 60f)));
        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + spawnDelay;
            
            SpawnObject();
        }
    }

    private void SpawnObject()

    {    
       
        if (objectPrefabs.Length <= 0)
        {
            Debug.LogError("No prefabs in the objectPrefabs array!");
            return;
        }

        int randomIndex = Random.Range(0, objectPrefabs.Length);
        GameObject objectPrefab = objectPrefabs[randomIndex];

        float xPos = Random.Range(transform.position.x - spawnRange, transform.position.x + spawnRange);
        Vector3 spawnPos = new Vector3(xPos, transform.position.y, transform.position.z + spawnDistance);
        GameObject newObject = Instantiate(objectPrefab, spawnPos, Quaternion.identity);
        Rigidbody rb = newObject.GetComponent<Rigidbody>();
        rb.velocity = Vector3.back * objectSpeed;
    }

}
