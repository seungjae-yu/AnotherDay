using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;
public class LoadEnding : MonoBehaviour {
    public static LoadEnding instance { get; private set; }
    public bool changeScene = false;

    void Start()
    {
        if (instance == null)
            instance = this;
    }
    public void LoadEnd()
    {
        StartCoroutine(LoadingProgress());
    }

    IEnumerator LoadingProgress()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync("Ending");
        while (async.progress < 0.9f)
        {
            Debug.Log("Loading : " + async.progress + "%");
            yield return null;
        }

        async.allowSceneActivation = false;

        while (!changeScene)
        {
            yield return new WaitForEndOfFrame();
        }

        async.allowSceneActivation = true; // Change scene Debug.Log("Loading complete");
                                           //시작하자마자 메인 게임 로드
    }
}
