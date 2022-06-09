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
    [SerializeField] GameObject screwInBulbLoading;
    [SerializeField] GameObject stoveLoading;
    [SerializeField] GameObject hingesLoading;
    [SerializeField] GameObject connectToInternetLoading;
    [SerializeField] GameObject grainsLoading;
    [SerializeField] GameObject meatLoading;
    [SerializeField] GameObject dairyLoading;
    [SerializeField] GameObject vegetablesLoading;
    [SerializeField] GameObject spraysLoading;
    [SerializeField] GameObject wipesLoading;
    [SerializeField] GameObject soapLoading;
    [SerializeField] GameObject vacuumLoading;
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
        if (capsule1 == null && capsule2 == null && capsule3 == null)
        {
            Debug.Log("done with 3 capsules");
            n3.carPortal.SetActive(true);
            Debug.Log("time to open car portal??");
            n3.carPortalTimeline.SetActive(true);
            Invoke(nameof(TurnCameraPositionBack), 16f);
        }
    }

    void TurnCameraPositionBack()
    {
        n3.cam.SetActive(true);
        Destroy(n3.carPortalTimeline);
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
            CapsuleButtonTask();
            Invoke(nameof(DestroyCapsule1AfterDing), 3f);
        }
    }

    public void DestroyCapsule2()
    {
        if (n3.isLookingAtCapsule2 == true)
        {
            CapsuleButtonTask();
            Invoke(nameof(DestroyCapsule2AfterDing), 3f);
        }
    }
    public void DestroyCapsule3()
    {
        if (n3.isLookingAtCapsule3 == true)
        {
            CapsuleButtonTask();
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
        n3.monsterObjectMeshRenderer.GetComponent<MeshRenderer>().material = level1MonsterMat;
        n3.monsterAIMesRenderer.GetComponent<MeshRenderer>().material = level1MonsterMat;
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
        n3.monsterObjectMeshRenderer.GetComponent<MeshRenderer>().material = level2MonsterMat;
        n3.monsterAIMesRenderer.GetComponent<MeshRenderer>().material = level2MonsterMat;
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
        n3.monsterObjectMeshRenderer.GetComponent<MeshRenderer>().material = level3MonsterMat;
        n3.monsterAIMesRenderer.GetComponent<MeshRenderer>().material = level3MonsterMat;
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
            Invoke(nameof(FinishTaskWithDingSFXOnceDoneUsingInvoke), 10f);
            canFinishAnotherTask = false;
        }
    }
    public void CapsuleButtonTask()
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
        Invoke(nameof(DestroyScrewInLightBulb), 10f);
        Cursor.lockState = CursorLockMode.Locked;
        screwInBulbLoading.SetActive(true);
        GetComponent<Animator>().Play("LoadingCogsNight2", 0);
    }

    private void DestroyScrewInLightBulb()
    {
        Destroy(screwInLightBulb);
        Cursor.lockState = CursorLockMode.None;
        Destroy(screwInBulbLoading);
    }

    public void DeleteStove()
    {
        Invoke(nameof(DestroyStove), 10f);
        Cursor.lockState = CursorLockMode.Locked;
        stoveLoading.SetActive(true);
        GetComponent<Animator>().Play("LoadingCogsNight2", 0);
    }

    private void DestroyStove()
    {
        Destroy(stove);        
        Cursor.lockState = CursorLockMode.None;
        Destroy(stoveLoading);
    }

    public void DeleteHinges()
    {
        Invoke(nameof(DestroyHinges), 10f);
        Cursor.lockState = CursorLockMode.Locked;
        hingesLoading.SetActive(true);
        GetComponent<Animator>().Play("LoadingCogsNight2", 0);
    }

    private void DestroyHinges()
    {
        Destroy(hinges);
        Cursor.lockState = CursorLockMode.None;
        Destroy(hingesLoading);
    }

    public void DeleteConnectToInternet()
    {
        Invoke(nameof(DestroyConnectToInternet), 10f);
        Cursor.lockState = CursorLockMode.Locked;
        connectToInternetLoading.SetActive(true);
        GetComponent<Animator>().Play("LoadingCogsNight2", 0);
    }

    private void DestroyConnectToInternet()
    {
        Destroy(connectToInternet);
        Cursor.lockState = CursorLockMode.None;
        Destroy(connectToInternetLoading);
    }

    public void DeleteMeat()
    {
        Invoke(nameof(DestroyMeat), 10);
        Cursor.lockState = CursorLockMode.Locked;
        meatLoading.SetActive(true);
        GetComponent<Animator>().Play("LoadingCogsNight2", 0);
    }

    private void DestroyMeat()
    {
        Destroy(meat);
        Cursor.lockState = CursorLockMode.None;
        Destroy(meatLoading);
    }

    public void DeleteDairy()
    {
        Invoke(nameof(DestroyDairy), 10);
        Cursor.lockState = CursorLockMode.Locked;
        dairyLoading.SetActive(true);
        GetComponent<Animator>().Play("LoadingCogsNight2", 0);
    }

    private void DestroyDairy()
    {
        Destroy(dairy);
        Cursor.lockState = CursorLockMode.None;
        Destroy(dairyLoading);
    }

    public void DeleteVegetables()
    {
        Invoke(nameof(DestroyVegetables), 10);
        Cursor.lockState = CursorLockMode.Locked;
        GetComponent<Animator>().Play("LoadingCogsNight2", 0);
        vegetablesLoading.SetActive(true);
    }

    private void DestroyVegetables()
    {
        Destroy(vegetables);
        Cursor.lockState = CursorLockMode.None;
        Destroy(vegetablesLoading);
    }

    public void DeleteSprays()
    {
        Invoke(nameof(DestroySprays), 10);
        Cursor.lockState = CursorLockMode.Locked;
        spraysLoading.SetActive(true);
        GetComponent<Animator>().Play("LoadingCogsNight2", 0);
    }

    private void DestroySprays()
    {
        Destroy(sprays);
        Cursor.lockState = CursorLockMode.None;
        Destroy(spraysLoading);
    }

    public void DeleteWipes()
    {
        Invoke(nameof(DestroyWipes), 10);
        Cursor.lockState = CursorLockMode.Locked;
        wipesLoading.SetActive(true);
        GetComponent<Animator>().Play("LoadingCogsNight2", 0);
    }

    private void DestroyWipes()
    {
        Destroy(wipes);
        Cursor.lockState = CursorLockMode.None;
        Destroy(wipesLoading);
    }
    public void DeleteSoap()
    {
        Invoke(nameof(DestroySoap), 10);
        Cursor.lockState = CursorLockMode.Locked;
        soapLoading.SetActive(true);
        GetComponent<Animator>().Play("LoadingCogsNight2", 0);
    }

    private void DestroySoap()
    {
        Destroy(soap);
        Cursor.lockState = CursorLockMode.None;
        Destroy(soapLoading);
    }

    public void DeleteVacuum()
    {
        Invoke(nameof(DestroyVacuum), 10);
        Cursor.lockState = CursorLockMode.Locked;
        vacuumLoading.SetActive(true);
        GetComponent<Animator>().Play("LoadingCogsNight2", 0);
    }

    private void DestroyVacuum()
    {
        Destroy(vacuum);
        Cursor.lockState = CursorLockMode.None;
        Destroy(vacuumLoading);
    }

    public void DeleteGrains()
    {
        Invoke(nameof(DestroyGrains), 10);
        Cursor.lockState = CursorLockMode.Locked;
        grainsLoading.SetActive(true);
        GetComponent<Animator>().Play("LoadingCogsNight2", 0);
    }

    private void DestroyGrains()
    {
        Destroy(grains);
        Cursor.lockState = CursorLockMode.None;
        Destroy(grainsLoading);
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
