using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider sliderBar;
    //public GameObject canvas;

    private void Start()
    {
        //canvas.GetComponent<Animator>().enabled = false;
    }

    public void LoadScene(int levelIndex)
    {
        StartCoroutine(LoadSceneAsynchronously(levelIndex));
        //canvas.GetComponent<Animator>().enabled = true;
        //canvas.GetComponent<Animator>().Play("FadeOutStartingMusicInMainMenu", 0);
    }

    IEnumerator LoadSceneAsynchronously(int levelIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);
        loadingScreen.SetActive(true);
        while(!operation.isDone)
        {
            sliderBar.value = operation.progress;
            yield return null;
        }
    }
}
