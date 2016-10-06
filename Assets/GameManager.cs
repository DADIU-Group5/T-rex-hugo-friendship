using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour {

    public static GameManager instance;
    public static bool GameRunning = true;

    public float playTime = 60;
    public float timer;
    public Slider timeSlider;
    public Image sliderImg;

    public GameObject endScreen;
    public Text gameOver;
    public Text scoreText;
    public Text inGameScore;

    public int score = 0;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Destroys the 2. GameManager");
        }
    }

    void Start()
    {
        timeSlider.maxValue = playTime;
        timeSlider.value = playTime;
        timer = playTime;
    }

    void Update()
    {
        return;
        if (!GameRunning)
        {
            return;
        }
        timer -= Time.deltaTime;
        timeSlider.value = timer;
        sliderImg.color = Color.Lerp(Color.red, Color.green, (timer / playTime));
        if(timer < 0)
        {
            TimerEnd();
        }
    }

    void TimerEnd()
    {
        StopGame();
        gameOver.text = "Game Ended!";
        scoreText.text = "Score: " + score;
    }

    public void TRexDied()
    {
        StopGame();
        gameOver.text = "You Died";
        scoreText.text = "Score: " + score;
    }

    void StopGame()
    {
        endScreen.SetActive(true);
        GameRunning = false;
        PlayerPrefs.SetInt("HIGHSCORE", score);
    }

    public void AddScore(int _score)
    {
        score += _score;
        inGameScore.text = "Score: " + score;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
