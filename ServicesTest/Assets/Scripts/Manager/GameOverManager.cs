using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {
    public Text score;
    public Text hiScore;
    private float wait;
	// Use this for initialization
	void Start () {
        score.text = "Score: " + ((int)Score.score).ToString();
        hiScore.text = "Hi-Score: " + Score.hiScore.ToString();
        wait = 0;
	}
	
	// Update is called once per frame
	void Update () {
        wait += Time.deltaTime;

        if (wait > 2)
            SceneManager.LoadScene("Menu");
	}
}
