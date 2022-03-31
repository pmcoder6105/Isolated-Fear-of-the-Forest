using UnityEngine.SceneManagement;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    Night1 n1;

    // Start is called before the first frame update
    void Start()
    {
        n1 = FindObjectOfType<Night1>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Night1Replay()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
        n1.shouldSkipIntro = true;
    }
}
