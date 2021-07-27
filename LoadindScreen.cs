using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadindScreen : MonoBehaviour
{
    [SerializeField]
    private Image progressBar;

    [SerializeField]
    private Text loadText;


    void Start()
    {
        StartCoroutine(LoadingScreenAsyncOperation());
    }

    IEnumerator LoadingScreenAsyncOperation()
    {
        yield return null;
        AsyncOperation loadScene = SceneManager.LoadSceneAsync(1);

        loadScene.allowSceneActivation = false;

        while (!loadScene.isDone)
        {
            progressBar.fillAmount = loadScene.progress;
            loadText.text = (loadScene.progress * 100).ToString("F0") + "%";

            if (loadScene.progress >= 0.9f)
            {
                progressBar.fillAmount = 1f;
                loadText.text = "100%";
            }

            yield return null;
        }
    }
}
