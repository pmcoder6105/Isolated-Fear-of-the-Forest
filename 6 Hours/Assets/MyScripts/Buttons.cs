using UnityEngine.SceneManagement;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    Night1 n1;
    AudioSource aS;
    [SerializeField] AudioClip buttonClickNight2;
    [SerializeField] AudioClip whirringSFXWhenCompletingTask;
    [SerializeField] AudioClip ding;
    
    [SerializeField] GameObject screwInLightBulb;
    [SerializeField] GameObject stove;
    [SerializeField] GameObject hinges;
    [SerializeField] GameObject connectToInternet;
    [SerializeField] GameObject grains;
    [SerializeField] GameObject meat;
    [SerializeField] GameObject dairy;
    [SerializeField] GameObject vegetables;
    [SerializeField] GameObject sprays;
    [SerializeField] GameObject wipes;
    [SerializeField] GameObject soap;
    [SerializeField] GameObject vacuum;
    bool canFinishAnotherTask = true;

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
        if (canFinishAnotherTask == true)
        {
            aS.PlayOneShot(whirringSFXWhenCompletingTask);
            Invoke(nameof(FinishTaskWithDingSFXOnceDoneUsingInvoke), 3f);
            canFinishAnotherTask = false;
        }        
    }

    void FinishTaskWithDingSFXOnceDoneUsingInvoke()
    {
        Debug.Log("finished task");
        aS.PlayOneShot(ding);
        canFinishAnotherTask = true;
    }

    public void DeleteScrewInBulb()
    {
        Invoke(nameof(DestroyScrewInLightBulb), 3f);
    }

    private void DestroyScrewInLightBulb()
    {
        Destroy(screwInLightBulb);
    }

    public void DeleteStove()
    {
        Invoke(nameof(DestroyStove), 3f);
    }

    private void DestroyStove()
    {
        Destroy(stove);
    }

    public void DeleteHinges()
    {
        Invoke(nameof(DestroyHinges), 3f);
    }

    private void DestroyHinges()
    {
        Destroy(hinges);
    }

    public void DeleteConnectToInternet()
    {
        Invoke(nameof(DestroyConnectToInternet), 3f);
    }

    private void DestroyConnectToInternet()
    {
        Destroy(connectToInternet);
    }

    public void DeleteMeat()
    {
        Invoke(nameof(DestroyMeat), 3f);
    }

    private void DestroyMeat()
    {
        Destroy(meat);
    }

    public void DeleteDairy()
    {
        Invoke(nameof(DestroyDairy), 3f);
    }

    private void DestroyDairy()
    {
        Destroy(dairy);
    }

    public void DeleteVegetables()
    {
        Invoke(nameof(DestroyVegetables), 3f);
    }

    private void DestroyVegetables()
    {
        Destroy(vegetables);
    }

    public void DeleteSprays()
    {
        Invoke(nameof(DestroySprays), 3f);
    }

    private void DestroySprays()
    {
        Destroy(sprays);
    }

    public void DeleteWipes()
    {
        Invoke(nameof(DestroyWipes), 3f);
    }

    private void DestroyWipes()
    {
        Destroy(wipes);
    }
    public void DeleteSoap()
    {
        Invoke(nameof(DestroySoap), 3f);
    }

    private void DestroySoap()
    {
        Destroy(soap);
    }

    public void DeleteVacuum()
    {
        Invoke(nameof(DestroyVacuum), 3f);
    }

    private void DestroyVacuum()
    {
        Destroy(vacuum);
    }

    public void DeleteGrains()
    {
        Invoke(nameof(DestroyGrains), 3f);
    }

    private void DestroyGrains()
    {
        Destroy(grains);
    }
}
