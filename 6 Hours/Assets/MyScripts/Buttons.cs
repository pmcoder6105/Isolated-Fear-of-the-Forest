using UnityEngine.SceneManagement;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    Night1 n1;
    Night2 n2;
    Night3 n3;
    AudioSource aS;
    [SerializeField] AudioClip buttonClickNight2;
    [SerializeField] AudioClip winSFX;
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
    [SerializeField] GameObject monsters;
    [SerializeField] GameObject fadeOutsDooms;
    [SerializeField] public GameObject capsule1;
    [SerializeField] public GameObject capsule2;
    [SerializeField] public GameObject capsule3;
    bool canFinishAnotherTask = true;
    public int monsterSpeed = 0;
    public Material level1MonsterMat;
    public Material level2MonsterMat;
    public Material level3MonsterMat;

    // Start is called before the first frame update
    void Start()
    {
        n2 = FindObjectOfType<Night2>();
        n1 = FindObjectOfType<Night1>();
        n3 = FindObjectOfType<Night3>();
        aS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayLvl1()
    {
        SceneManager.LoadScene("Night 1");
    }
    public void Night1Replay()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
        n1.shouldSkipIntro = true;
    }
    public void Night1NextLevel()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextScene);
    }
    public void Night2Replay()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
        n2.shouldSkipIntro = true;
    }
    public void Night2NextLevel()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextScene);
    }
    public void Night3Replay()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
        n3.shouldSkipIntro = true;
    }
    public void Night3NextLevel()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextScene);
    }

    public void ClickLaptopButtonNight2()
    {
        aS.PlayOneShot(buttonClickNight2);
    }

    public void DestroyCapsule1()
    {
        if (n3.isLookingAtCapsule1 == true)
        {
            CompleteButtonTask();
            Invoke(nameof(DestroyCapsule1AfterDing), 3f);
        }
    }

    public void DestroyCapsule2()
    {
        if (n3.isLookingAtCapsule2 == true)
        {
            CompleteButtonTask();
            Invoke(nameof(DestroyCapsule2AfterDing), 3f);
        }
    }
    public void DestroyCapsule3()
    {
        if (n3.isLookingAtCapsule3 == true)
        {
            CompleteButtonTask();
            Invoke(nameof(DestroyCapsule3AfterDing), 3f);
        }
    }

    void DestroyCapsule1AfterDing()
    {
        Destroy(capsule1);
        Destroy(n3.capsule1Button);
        n3.player.GetComponent<Animator>().Play("ZoomOutOfCapsule1", 0);
        Invoke(nameof(TurnAnimatorOffOnceZoomedOut), 1.1f);
        n3.player.GetComponent<Rigidbody>().isKinematic = false;
        //n3.player.GetComponent<Animator>().enabled = false;
        monsterSpeed = monsterSpeed + 1;
        n3.monsterAI.GetComponent<MeshRenderer>().material = level1MonsterMat;
        n3.prefabedMonster.GetComponent<MeshRenderer>().material = level1MonsterMat;
    }
    void DestroyCapsule2AfterDing()
    {
        Destroy(capsule2);
        Destroy(n3.capsule2Button);
        n3.player.GetComponent<Animator>().Play("ZoomOutOfCapsule2", 0);
        Invoke(nameof(TurnAnimatorOffOnceZoomedOut), 1.1f);
        n3.player.GetComponent<Rigidbody>().isKinematic = false;
        //n3.player.GetComponent<Animator>().enabled = false;
        monsterSpeed = monsterSpeed + 1;
        n3.monsterAI.GetComponent<MeshRenderer>().material = level2MonsterMat;
        n3.prefabedMonster.GetComponent<MeshRenderer>().material = level2MonsterMat;
    }
    void DestroyCapsule3AfterDing()
    {
        Destroy(capsule3);
        Destroy(n3.capsule3Button);
        n3.player.GetComponent<Animator>().Play("ZoomOutOfCapsule3", 0);
        Invoke(nameof(TurnAnimatorOffOnceZoomedOut), 1.1f);
        n3.player.GetComponent<Rigidbody>().isKinematic = false;
        //n3.player.GetComponent<Animator>().enabled = false;
        monsterSpeed = monsterSpeed + 1;
        n3.monsterAI.GetComponent<MeshRenderer>().material = level3MonsterMat;
        n3.prefabedMonster.GetComponent<MeshRenderer>().material = level3MonsterMat;
    }
    void TurnAnimatorOffOnceZoomedOut()
    {
        n3.player.GetComponent<Animator>().enabled = false;
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
        if (!aS.isPlaying)
        {
            aS.PlayOneShot(winSFX);
        }
        winFadeOut.SetActive(false);
        Destroy(n2.MainScreen);
        Destroy(n2.Cleaning);
        Destroy(n2.HomeSupplies);
        Destroy(n2.Appliances);
        Destroy(monsters);
        Destroy(fadeOutsDooms);
        Destroy(n2.timer);
        Destroy(n2.redEyeLeftGameobject);
        Destroy(n2.redEyeRightGameobject);
        Destroy(n2.ventDarknessGameobject);
        Destroy(n2.ventDarknessGameobject2);
        Destroy(n2.ventDarknessGameobject3);
        Destroy(n2.ventDarknessGameobject4);
        Destroy(n2.ventDarknessGameobject5);
        Destroy(n2.ventDarknessGameobject6);
    }
}
