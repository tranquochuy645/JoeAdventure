using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public Button pauseButton;
    public Button resumeButton;

   

    void Start()
    {
        pauseButton.onClick.AddListener(Pause);
        resumeButton.onClick.AddListener(Resume);

        resumeButton.gameObject.SetActive(false); // Hide the resume button by default
    }

    void Pause()
    {
        Time.timeScale = 0; // Pause the game
        
        pauseButton.gameObject.SetActive(false); // Hide the pause button
        resumeButton.gameObject.SetActive(true); // Show the resume button
    }

    void Resume()
    {
        Time.timeScale = 1; // Resume the game
      

        pauseButton.gameObject.SetActive(true); // Show the pause button
        resumeButton.gameObject.SetActive(false); // Hide the resume button
    }
}
