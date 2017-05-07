using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFactory : MonoBehaviour {
    static public PlayerFactory instance = null;
    public GameObject playerPrefab;

    void Awake() {
        instance = this;
    }


    public GameObject Create(string type) {
        switch (type)
        {
            case "Player":
                GameObject player = Instantiate(playerPrefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 1));
                return player;
            default:
                return null;
        }
    }

    public void Recycle(GameObject obj) {
        Destroy(obj);
        StartCoroutine(LoadGameOver());
    }

    IEnumerator LoadGameOver()
    {
        yield return new WaitForSeconds(1f);
        AdsManager.instance.ShowAd();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("GameOver");
    }
}