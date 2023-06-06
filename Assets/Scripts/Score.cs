using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public float score;
    public bool GameOver = true;
    public Button StartGame;


    void Start()
    {

        StartGame.onClick.AddListener(() =>
        {
            GameOver = false;
            score = 0f;
        });

    }

    void Update()
    {
        if (!GameOver)
        {
            score += Time.deltaTime;
            scoreText.text = "Score: " + Mathf.RoundToInt(score).ToString();
        }

    }
}
