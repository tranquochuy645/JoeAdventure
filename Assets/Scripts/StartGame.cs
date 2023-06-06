using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public Button startButton;
    public Button pauseButton;

    public Text gameOverText;
    public GameObject playerPrefab;

     

    
    
    void SpawnPlayer()
    {
        Vector3 spawnPos = new Vector3(0, 3, -15);
        GameObject newObject = Instantiate(playerPrefab, spawnPos, Quaternion.identity);
    }
    void OnStart()
    {   
       
        GlobalVar.startTime =Time.time;
        Time.timeScale = 1;
        gameOverText.gameObject.SetActive(false);
        SpawnPlayer();
        startButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);

    }

    void Start()
    {
        Time.timeScale = 0;
        
        startButton.onClick.AddListener(OnStart);
        pauseButton.gameObject.SetActive(false);
    }

    void Update(){
        if(Input.GetButtonDown("Jump")&&startButton.gameObject.activeSelf)
        {
            startButton.onClick.Invoke();
        }
    }
}
