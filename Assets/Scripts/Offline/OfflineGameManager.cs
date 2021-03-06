using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OfflineGameManager : MonoBehaviour{
    [Header("Text Elements")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI endScoreText;
    [SerializeField] public TextMeshProUGUI accrucaryText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI countDownText;

    [Header("Game Pannels")]
    [SerializeField] private GameObject endPanel; 
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject highScoreMenu;

    [Header("Misc.")]
    [SerializeField] private LeaderboardController leaderboardController;
    [SerializeField] private AudioSource audiosource;
    [SerializeField] private GameObject player;

    [Header("Varaibles")]
    [SerializeField] private int countDownNumber = 3;
    [SerializeField] private float time = 30;
    public bool isGameOver = false;
    public bool isGameStarted = false;
    public bool isGamePaused = false;
    public int numberOfTimesMouseClicked = 0;
    private int score = 0;

    void Start()
    {
        audiosource.volume = sceneVarPassover.volume;
        OfflineTarget.numberOfTargetsDestroyed = 0;
        Time.timeScale = 1f;
        isGameOver = false;
        scoreText.text = score.ToString();
        countDownText.text = countDownNumber.ToString();
        StartCountDownTimer();
    }

    private void FixedUpdate()
    {
        player.SetActive(true);
    }

    void StartCountDownTimer()
    {
        if (countDownNumber < 1)
        {
            isGameStarted = true;
            countDownText.gameObject.SetActive(false);
        }
        else
        {
            StartCoroutine(CountDownTimer());
        }
    }

    IEnumerator CountDownTimer()
    {
        yield return new WaitForSeconds(1);
        countDownNumber--;
        countDownText.text = countDownNumber.ToString();
        StartCountDownTimer();
    }

    void Update()
    {
        if (isGameStarted)
        {
            Timer();
            GameOver();
            PauseFunction();
            CountMouseClicks();
        }
    }

    public void ScoreKeeper(int pointsAdded) {
        score += pointsAdded;
        scoreText.text = score.ToString();
    }

    private void Timer() {
        if (time > 0){
            time -= Time.deltaTime;
            timerText.text = Mathf.RoundToInt(time).ToString();  //rounds to the nearest integer
            
        } else {
            if (!isGameOver) leaderboardController.SubmitScore(score);
            isGameOver = true;
            endScoreText.text = score.ToString();
        } 
    }


    private void PauseFunction()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isGameOver)
        {
            if (isGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        isGamePaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Pause()
    {
        isGamePaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
    }
   
    private void GameOver() {
        if (isGameOver) {
            endPanel.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
    }

    private void CountMouseClicks()
    {
        if (Input.GetMouseButtonDown(0) && !isGamePaused && !isGameOver)
        {
            numberOfTimesMouseClicked++;
            Debug.Log(OfflineTarget.numberOfTargetsDestroyed + " " + numberOfTimesMouseClicked);
            if (numberOfTimesMouseClicked > 0)
            {
                accrucaryText.text = ((int)(OfflineTarget.numberOfTargetsDestroyed / (float)numberOfTimesMouseClicked * 100)).ToString() + "%";
            }
            else
            {
                accrucaryText.text = "100%";
            }
        }
    }

}
