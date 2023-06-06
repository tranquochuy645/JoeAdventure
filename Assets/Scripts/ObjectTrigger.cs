using UnityEngine;
using UnityEngine.UI;
public class ObjectTrigger : MonoBehaviour
{
    public Text gameOverText;
    public Button startButton;

    public Button pauseButton;

    public AudioSource audioSource;
    public Score Score;
    private void Start()
    {
        gameOverText.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            audioSource.Play();
            // End the game and declare a loss
         
            // Display the score in the gameOverText
            gameOverText.text = "Game Over" ;

            // Debug.Log("Game Over - Fell off");
            gameOverText.gameObject.SetActive(true);
            // Time.timeScale = 0f;

            pauseButton.gameObject.SetActive(false);
            startButton.gameObject.SetActive(true);
            Score.GameOver=true;
        }
    }
}
