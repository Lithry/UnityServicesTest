using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour {
    static public AdsManager instance = null;

	void Awake () {
        instance = this;
        Advertisement.Initialize("1395408", true);
	}

    public void ShowAd()
    {
        #if UNITY_EDITOR
            StartCoroutine(WaitForAd());
        #endif

        if (Advertisement.IsReady())
            Advertisement.Show();
    }

    public void ShowAd(string zone = "")
    {
        #if UNITY_EDITOR
            StartCoroutine(WaitForAd());
        #endif

        if (string.Equals(zone, ""))
            zone = null;

        ShowOptions options = new ShowOptions();
        options.resultCallback = AdResult;

        if (Advertisement.IsReady(zone))
            Advertisement.Show(zone, options);
    }

    void AdResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Failed:
                Debug.Log("Ocurrio un error");
                break;
            case ShowResult.Skipped:
                Debug.Log("Ad Skipped");
                break;
            case ShowResult.Finished:
                Debug.Log("Ad Vista hasta el fin");
                break;
            default:
                Debug.Log("FATAL ERROR!!!!!");
                break;
        }
    }

#if UNITY_EDITOR
    IEnumerator WaitForAd()
    {
        float currentTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        yield return null;

        while (Advertisement.isShowing)
            yield return null;

        Time.timeScale = currentTimeScale;
    }
#endif
}
