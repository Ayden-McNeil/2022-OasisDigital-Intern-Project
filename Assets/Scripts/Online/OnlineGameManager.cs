using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnlineGameManager : MonoBehaviour{

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI endScoreText;
    [SerializeField] public TextMeshProUGUI accrucaryText;
    //[SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject endPanel; 
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private AudioSource audiosource;

    private int score = 0;
    public bool isGameOver = false;
    public bool isGamePaused = false;
    public int numberOfTimesMouseClicked = 0;

    void Start()
    {
        audiosource.volume = sceneVarPassover.volume;
        OfflineTarget.numberOfTargetsDestroyed = 0;
        Time.timeScale = 1f;
        isGameOver = false;
        scoreText.text = score.ToString();
    }

    void Update()
    {
        Timer();
        GameOver();
        PauseFunction();
        CountMouseClicks();
    }

    public void ScoreKeeper(int pointsAdded){
        score += pointsAdded;
        scoreText.text = score.ToString();
    }

    private void Timer()
    {
        
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
        Cursor.lockState = CursorLockMode.Locked;

    }

    private void Pause()
    {
        isGamePaused = true;
        pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;


    }
   
    private void GameOver(){
       
    }

    private void CountMouseClicks()
    {
        if (Input.GetMouseButtonDown(0) && !isGamePaused && !isGameOver)
        {
            numberOfTimesMouseClicked++;
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

    public void DisconnectPlayerFromServer()
    {
        GameObject.Find("NetworkManager(Clone)").GetComponent<NetworkManagerScript>().DisconnectPlayer();
    }
}