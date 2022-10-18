using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    private int scorepoint;
    private int highscore;
    Text scoretext;
    Text highscoretext;
    GameObject ScoreBoardObj;
    GameObject HighScoreObj;

    // Start is called before the first frame update
    void Start()
    {
        ScoreBoardObj = transform.Find("Score").gameObject;
        HighScoreObj = transform.Find("HighScore").gameObject;
        highscore = 0;
        scoretext = ScoreBoardObj.GetComponent<Text>();
        highscoretext = HighScoreObj.GetComponent<Text>();
        scorepoint = 0;
        ShowHighScore();
    }

    public int GetSetScore
    {
        get { return scorepoint; }
        set { scorepoint = value; }
    }

    public void ShowScore()
    {
        scoretext.text = scorepoint.ToString();
    }

    public void ShowHighScore()
    {
        highscoretext.text = highscore.ToString();
    }

    public void ScoreCalc(int addpoint)
    {
        scorepoint += addpoint;
    }

    public void Miss()
    {
        if (highscore < scorepoint)
        {
            highscore = scorepoint;
            //Debug.Log("hiscore : " + highscore);
        }
        scorepoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
