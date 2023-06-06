using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject roadPrefab; // array of game object prefabs to choose from
    private float initialSpawnDelay;

    private bool odd=false;





    private float nextSpawnTime;
    private void Start()
    {
        initialSpawnDelay = 7f;
    }
    private void Update()
    {
        float spawnDelay = initialSpawnDelay * (1f / (1f + 5 * ((Time.time - GlobalVar.startTime) / 60f)));
        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + spawnDelay;
            if(odd){
                SpawnObject(0.1f);
                odd = false;
            }else{
                SpawnObject(0.11f);
                odd = true;
            }
            
        }
    }

    private void SpawnObject(float yPos)

    {

        Vector3 spawnPos = new Vector3(0f, yPos, 240f);
        GameObject newObject = Instantiate(roadPrefab, spawnPos, Quaternion.identity);
    }

}
