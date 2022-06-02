using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour{

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    //public TextMeshProUGUI gameOverText;

    private int score = 0;
    public float time = 30;
    public bool isGameOver;
    public bool isGamePaused = false;

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        PauseFunction();
        //GameOver();
    }

    public void ScoreKeeper(int pointsAdded){
        score += pointsAdded;
        scoreText.text = score.ToString();
    }

    private void Timer(){
        
        if (time > 0)
        {
            time -= Time.deltaTime;
            timerText.text = Mathf.RoundToInt(time).ToString();
            
        }else{
            isGameOver = true;
        }
        
    }

    private void PauseFunction()
    {
        if (Input.GetKeyDown(KeyCode.P))
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

    private void Resume()
    {
        isGamePaused = false;
        Time.timeScale = 1f;
        Debug.Log("Resume");
    }

    private void Pause()
    {
        isGamePaused = true;
        Time.timeScale = 0f;
        Debug.Log("Pause");

    }

    /*
    private void GameOver(){
        if(isGameOver){
            gameOverText.gameObject.SetActive(true);
        }
    */






}
