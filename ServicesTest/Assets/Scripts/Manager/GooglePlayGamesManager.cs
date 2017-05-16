using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GooglePlayGamesManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        Social.localUser.Authenticate((bool success) => {
            if (success)
                SceneManager.LoadScene("Menu");
        });
    }
	
	// Update is called once per frame
	void Update () {
        

        if (Score.score > 100 && Score.score < 101)
        {
            Social.ReportProgress("CgkIlKWR-v8HEAIQAQ", 100.0f, (bool success) =>
            {
                Score.score += 25;
            });
        }
    }
}