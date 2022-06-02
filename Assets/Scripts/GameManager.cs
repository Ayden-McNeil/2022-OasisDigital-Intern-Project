using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{

    [SerializeField]private TextMeshProUGUI scoreText;
    [SerializeField]private TextMeshProUGUI timerText;
    //[SerializeField]private GameObject endPanel; // uncomment once the restart screen is done and alther to liking 
    [SerializeField] private GameObject pauseMenu;

    private int score = 0;
    public bool isGameOver;
    [SerializeField]private float time = 30;
    public bool isGamePaused = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        isGameOver = false;
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update(){
        Timer();

        GameOver();
        PauseFunction();

    }

    public void ScoreKeeper(int pointsAdded){
        score += pointsAdded;
        scoreText.text = score.ToString();
    }

    private void Timer(){
        if (time > 0){
            time -= Time.deltaTime;
            timerText.text = Mathf.RoundToInt(time).ToString();  //rounds to the nearest integer
            
        }else{
            isGameOver = true;
        }
        
    }


    private void PauseFunction()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
   
    private void GameOver(){
        if(isGameOver){
            //endPanel.gameObject.SetActive(true);// // uncomment once the restart screen is done and alther to liking 
        }
    }






}
