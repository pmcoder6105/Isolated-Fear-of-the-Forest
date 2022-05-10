using UnityEngine.SceneManagement;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    Night1 n1;
    Night2 n2;
    AudioSource aS;
    [SerializeField] AudioClip buttonClickNight2;
    [SerializeField] AudioClip whirringSFXWhenCompletingTask;
    [SerializeField] AudioClip ding;
    [SerializeField] GameObject winScreen;
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
    [SerializeField] GameObject winFadeOut;
    bool canFinishAnotherTask = true;

    // Start is called before the first frame update
    void Start()
    {
        n2 = FindObjectOfType<Night2>();
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
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void DestroyScrewInLightBulb()
    {
        Destroy(screwInLightBulb);
        Cursor.lockState = CursorLockMode.None;
    }

    public void DeleteStove()
    {
        Invoke(nameof(DestroyStove), 3f);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void DestroyStove()
    {
        Destroy(stove);        
        Cursor.lockState = CursorLockMode.None;
    }

    public void DeleteHinges()
    {
        Invoke(nameof(DestroyHinges), 3f);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void DestroyHinges()
    {
        Destroy(hinges);
        Cursor.lockState = CursorLockMode.None;
    }

    public void DeleteConnectToInternet()
    {
        Invoke(nameof(DestroyConnectToInternet), 3f);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void DestroyConnectToInternet()
    {
        Destroy(connectToInternet);
        Cursor.lockState = CursorLockMode.None;
    }

    public void DeleteMeat()
    {
        Invoke(nameof(DestroyMeat), 3f);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void DestroyMeat()
    {
        Destroy(meat);
        Cursor.lockState = CursorLockMode.None;
    }

    public void DeleteDairy()
    {
        Invoke(nameof(DestroyDairy), 3f);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void DestroyDairy()
    {
        Destroy(dairy);
        Cursor.lockState = CursorLockMode.None;
    }

    public void DeleteVegetables()
    {
        Invoke(nameof(DestroyVegetables), 3f);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void DestroyVegetables()
    {
        Destroy(vegetables);
        Cursor.lockState = CursorLockMode.None;
    }

    public void DeleteSprays()
    {
        Invoke(nameof(DestroySprays), 3f);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void DestroySprays()
    {
        Destroy(sprays);
        Cursor.lockState = CursorLockMode.None;
    }

    public void DeleteWipes()
    {
        Invoke(nameof(DestroyWipes), 3f);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void DestroyWipes()
    {
        Destroy(wipes);
        Cursor.lockState = CursorLockMode.None;
    }
    public void DeleteSoap()
    {
        Invoke(nameof(DestroySoap), 3f);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void DestroySoap()
    {
        Destroy(soap);
        Cursor.lockState = CursorLockMode.None;
    }

    public void DeleteVacuum()
    {
        Invoke(nameof(DestroyVacuum), 3f);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void DestroyVacuum()
    {
        Destroy(vacuum);
        Cursor.lockState = CursorLockMode.None;
    }

    public void DeleteGrains()
    {
        Invoke(nameof(DestroyGrains), 3f);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void DestroyGrains()
    {
        Destroy(grains);
        Cursor.lockState = CursorLockMode.None;
    }
    public void LogOut()
    {
        if (screwInLightBulb == null &&
            stove == null &&
            hinges == null && 
            connectToInternet == null && 
            grains == null &&
            meat == null && 
            dairy == null && 
            vegetables == null &&
            sprays == null && 
            wipes == null && 
            soap == null &&
            vacuum == null)
        {
            winFadeOut.SetActive(true);
            Invoke(nameof(TurnOnWinScreen), 2f);
            if (!n2.doomSFXEmpty15.GetComponent<AudioSource>().isPlaying)
            {
                n2.doomSFXEmpty15.GetComponent<AudioSource>().PlayOneShot(n2.doomSFX);
            }                        
        }
        else
        {
            Debug.Log("you have to complete more tasks before winning");
        }
    }
    void TurnOnWinScreen()
    {
        winScreen.SetActive(true);
    }
}
