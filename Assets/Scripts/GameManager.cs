using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour{

    [SerializeField]private TextMeshProUGUI scoreText;
    [SerializeField]private TextMeshProUGUI timerText;
    //[SerializeField]private GameObject endPanel; // uncomment once the restart screen is done and alther to liking 

    private int score = 0;
    public bool isGameOver;
    [SerializeField]private float time = 30;

    // Start is called before the first frame update
    void Start(){
        isGameOver = false;
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update(){
        Timer();
        GameOver();
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

    
    private void GameOver(){
        if(isGameOver){
            //endPanel.gameObject.SetActive(true);// // uncomment once the restart screen is done and alther to liking 
        }
    }






}
