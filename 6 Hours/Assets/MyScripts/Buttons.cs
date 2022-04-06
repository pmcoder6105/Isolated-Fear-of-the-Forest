using UnityEngine.SceneManagement;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    Night1 n1;
    AudioSource aS;
    [SerializeField] AudioClip buttonClickNight2;
    [SerializeField] AudioClip whirringSFXWhenCompletingTask;
    [SerializeField] AudioClip ding;

    // Start is called before the first frame update
    void Start()
    {
        n1 = FindObjectOfType<Night1>();
        aS = GetComponent<AudioSource>();
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

    public void ClickLaptopButtonNight2()
    {
        aS.PlayOneShot(buttonClickNight2);
    }

    public void CompleteButtonTask()
    {
        aS.PlayOneShot(whirringSFXWhenCompletingTask);
        Invoke(nameof(FinishTaskWithDingSFXOnceDoneUsingInvoke), 5f);
    }

    void FinishTaskWithDingSFXOnceDoneUsingInvoke()
    {
        Debug.Log("finished task");
        aS.PlayOneShot(ding);
    }
}
