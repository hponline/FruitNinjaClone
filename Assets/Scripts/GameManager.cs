using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI livesText;
    public GameObject titleScreen;
    public GameObject pauseScreen;
    public Button restart;
    public bool isGameActive;

    private bool paused;
    private int score;
    private float spawnRate = 1.0f;
    private int lives;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangePaused();
        }

    }

    // Hedef Spawn
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {

            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            yield return new WaitForSeconds(spawnRate);

        }
    }

    // Score tablosu güncelleme
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    // Game over
    public void GameOver()
    {
        restart.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    // Restart
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    // Start Game
    // Verdigimiz parametreye göre zorluk seviyesine (1,2,3) böler
    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;

        isGameActive = true;
        score = 0;
        
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        UpdateLives(5);

        titleScreen.gameObject.SetActive(false);
    }

    // Can haklarýmýz
    public void UpdateLives(int livesToChange)
    {
        lives += livesToChange;
        livesText.text = "Lives: " + lives;
        if (lives <=0)
        {
            GameOver();
        }
    }

    // Duraklatma ekraný (ESC)
    void ChangePaused()
    {
        if (!paused)
        {
            paused = true;
            pauseScreen.gameObject.SetActive(true);
            Time.timeScale = 0;
            isGameActive = false;
        }
        else
        {
            paused = false;
            pauseScreen.gameObject.SetActive(false);
            Time.timeScale = 1;
            isGameActive = true;
        }
    }
}
