using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int score = 0;
    public static GameController instance;
    public bool isPaused = true;
    public GameObject gameOverText;
    public TextMeshProUGUI scoreText;
    public bool gameOver = false;
    public float scrollSpeed = -10f;
    
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Restart the game
        if (gameOver && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverText.SetActive(true);
    }

    // Increments score, and increases difficulty every 10 points.
    public void PlayerScored()
    {
        score++;
        scoreText.text = score.ToString();
        if(score % 10 == 0)
        {
            scrollSpeed *= 1.1f;
        }
    }
}
