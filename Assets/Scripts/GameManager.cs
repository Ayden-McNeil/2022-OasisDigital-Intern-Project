using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour{

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;

    private int score = 0;
    public float time = 30;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
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
        }
        
    }






}
