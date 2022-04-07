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
    public bool canMoveFromScreen = true;

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
        canMoveFromScreen = false;
        Invoke(nameof(DestroyScrewInLightBulb), 3f);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void DestroyScrewInLightBulb()
    {
        canMoveFromScreen = true;
        Destroy(screwInLightBulb);
        Cursor.lockState = CursorLockMode.None;
    }

    public void DeleteStove()
    {
        canMoveFromScreen = false;
        Invoke(nameof(DestroyStove), 3f);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void DestroyStove()
    {
        Destroy(stove);
        canMoveFromScreen = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void DeleteHinges()
    {
        canMoveFromScreen = false;
        Invoke(nameof(DestroyHinges), 3f);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void DestroyHinges()
    {
        Destroy(hinges);
        canMoveFromScreen = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void DeleteConnectToInternet()
    {
        canMoveFromScreen = false;
        Invoke(nameof(DestroyConnectToInternet), 3f);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void DestroyConnectToInternet()
    {
        Destroy(connectToInternet);
        canMoveFromScreen = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void DeleteMeat()
    {
        canMoveFromScreen = false;
        Invoke(nameof(DestroyMeat), 3f);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void DestroyMeat()
    {
        Destroy(meat);
        canMoveFromScreen = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void DeleteDairy()
    {
        canMoveFromScreen = false;
        Invoke(nameof(DestroyDairy), 3f);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void DestroyDairy()
    {
        Destroy(dairy);
        canMoveFromScreen = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void DeleteVegetables()
    {
        canMoveFromScreen = false;
        Invoke(nameof(DestroyVegetables), 3f);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void DestroyVegetables()
    {
        Destroy(vegetables);
        canMoveFromScreen = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void DeleteSprays()
    {
        canMoveFromScreen = false;
        Invoke(nameof(DestroySprays), 3f);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void DestroySprays()
    {
        Destroy(sprays);
        canMoveFromScreen = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void DeleteWipes()
    {
        canMoveFromScreen = false;
        Invoke(nameof(DestroyWipes), 3f);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void DestroyWipes()
    {
        Destroy(wipes);
        canMoveFromScreen = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void DeleteSoap()
    {
        canMoveFromScreen = false;
        Invoke(nameof(DestroySoap), 3f);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void DestroySoap()
    {
        Destroy(soap);
        canMoveFromScreen = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void DeleteVacuum()
    {
        canMoveFromScreen = false;
        Invoke(nameof(DestroyVacuum), 3f);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void DestroyVacuum()
    {
        Destroy(vacuum);
        canMoveFromScreen = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void DeleteGrains()
    {
        canMoveFromScreen = false;
        Invoke(nameof(DestroyGrains), 3f);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void DestroyGrains()
    {
        canMoveFromScreen = true;
        Destroy(grains);
        Cursor.lockState = CursorLockMode.None;
    }
}
