using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public Text score;
    public Text hiScore;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Score.score > Score.hiScore)
            Score.hiScore = (int)Score.score;

        score.text = "Score: " + ((int)Score.score).ToString();
        hiScore.text = "Hi-Score: " + Score.hiScore.ToString();
	}
}
