using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuController : MonoBehaviour {
    public Text hiScore;

    private void Update()
    {
        hiScore.text = "High Score: " + Score.hiScore.ToString();
    }
    public void NewGame()
    {
        //GameController.hiScore = PlayerPrefs.GetInt("hiScore");
        Score.score = 0;
        SceneManager.LoadScene("Level");
    }

    public void Quit() {
        Application.Quit();
    }
}
