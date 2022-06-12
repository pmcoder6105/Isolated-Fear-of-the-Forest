using UnityEngine;
using TMPro;

public class Night2 : MonoBehaviour
{
    [SerializeField] GameObject laptop;
    [SerializeField] GameObject laptopScreen;
    [SerializeField] GameObject instructions;
    [SerializeField] GameObject loseScreen;
    [SerializeField] public GameObject timer;
    [SerializeField] public GameObject MainScreen;
    [SerializeField] public GameObject Appliances;
    [SerializeField] public GameObject HomeSupplies;
    [SerializeField] public GameObject Cleaning;   
    [SerializeField] GameObject fadeOut;
    [SerializeField] GameObject fadeOut2;
    [SerializeField] GameObject fadeOut3;
    [SerializeField] GameObject fadeOut4;
    [SerializeField] GameObject fadeOut5;
    [SerializeField] GameObject fadeOut6;
    [SerializeField] GameObject fadeOut7;
    [SerializeField] GameObject fadeOut8;
    [SerializeField] GameObject fadeOut9;
    [SerializeField] GameObject fadeOut10;
    [SerializeField] GameObject fadeOut11;
    [SerializeField] GameObject fadeOut12;
    [SerializeField] GameObject fadeOut13;
    [SerializeField] GameObject fadeOut14;
    [SerializeField] GameObject fadeOut15;
    [SerializeField] GameObject monster;
    [SerializeField] GameObject monster2;
    [SerializeField] GameObject monster3;
    [SerializeField] GameObject monster4;
    [SerializeField] GameObject monster5;
    [SerializeField] GameObject monster6;
    [SerializeField] GameObject monster7;
    [SerializeField] GameObject monster8;
    [SerializeField] GameObject monster9;
    [SerializeField] GameObject monster10;
    [SerializeField] GameObject monster11;
    [SerializeField] GameObject monster12;
    [SerializeField] GameObject monster13;
    [SerializeField] GameObject monster14;
    [SerializeField] GameObject monster15;
    [SerializeField] GameObject doomSFXEmpty;
    [SerializeField] GameObject doomSFXEmpty2;
    [SerializeField] GameObject doomSFXEmpty3;
    [SerializeField] GameObject doomSFXEmpty4;
    [SerializeField] GameObject doomSFXEmpty5;
    [SerializeField] GameObject doomSFXEmpty6;
    [SerializeField] GameObject doomSFXEmpty7;
    [SerializeField] GameObject doomSFXEmpty8;
    [SerializeField] GameObject doomSFXEmpty9;
    [SerializeField] GameObject doomSFXEmpty10;
    [SerializeField] GameObject doomSFXEmpty11;
    [SerializeField] GameObject doomSFXEmpty12;
    [SerializeField] GameObject doomSFXEmpty13;
    [SerializeField] GameObject doomSFXEmpty14;
    [SerializeField] GameObject timeline;
    [SerializeField] GameObject spaceGuidance;
    [SerializeField] public GameObject doomSFXEmpty15;
    [SerializeField] GameObject doomSFXOpeningInstructions;
    bool isLookingAtScreen = false;
    [SerializeField] bool isTransitioningToScreen = false;
    [SerializeField] GameObject cam;
    Buttons bT;
    int redEye1Left;
    int redEye2Right;
    int redEye3Right;
    int vent4;
    int redEye5Left;
    int vent6;
    int vent7;
    int redEye8Right;
    int redEye9Right;
    int vent10;
    int redEye11Left;
    int vent12;
    int vent13;
    int redEye14Right;
    int redEye15Left;
    [SerializeField] public GameObject redEyeLeftGameobject;
    [SerializeField] public GameObject redEyeRightGameobject;
    bool hasAvoidedJumpscare = true;
    bool makeSureHasAvoidedJumpscareDoesntTurnFalse = false;
    AudioSource aS;
    [SerializeField] AudioClip redEyesDoomSfx;
    [SerializeField] AudioClip alarmBeep;
    [SerializeField] public AudioClip doomSFX;
    [SerializeField] AudioClip hallwayDoorClose;
    [SerializeField] GameObject leftEyeHallwayAvertedObject;
    [SerializeField] GameObject rightEyeHallwayAvertedObject;
    [SerializeField] GameObject audioTracking;
    [SerializeField] public GameObject ventDarknessGameobject;
    [SerializeField] public GameObject ventDarknessGameobject2;
    [SerializeField] public GameObject ventDarknessGameobject3;
    [SerializeField] public GameObject ventDarknessGameobject4;
    [SerializeField] public GameObject ventDarknessGameobject5;
    [SerializeField] public GameObject ventDarknessGameobject6;
    [SerializeField] GameObject ventAvertedObject;
    [SerializeField] GameObject ventAvertedObject2;
    [SerializeField] GameObject ventAvertedObject3;
    [SerializeField] GameObject ventAvertedObject4;
    [SerializeField] GameObject ventAvertedObject5;
    [SerializeField] GameObject ventAvertedObject6;
    [SerializeField] GameObject leftHallwayGuidance, rightHallwayGuidance, ventGuidance;
    [SerializeField] AudioClip crawlingInVent;
    [SerializeField] AudioClip loseSFX;
    [SerializeField] GameObject guidanceAudioEmpty;
    [SerializeField] AudioClip guidanceAudioClip;
    bool canCloseDoor = true;
    public bool freezeTime = false;
    bool shouldInvokeJumpscare = false;
    bool shouldNotScarePlayerAfterClosingDoorBug = false;
    public bool shouldSkipIntro;
    public bool shouldStartTimer = false;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Animator>().Play("PlayerEnteringRoomNight2", 0);
        bT = FindObjectOfType<Buttons>();
        redEye1Left = Random.Range(20 + 10, 26 + 10);
        redEye2Right = Random.Range(34 + 10, 10 + 40);
        redEye3Right = Random.Range(47 + 10, 10 + 53);
        vent4 = Random.Range(60 + 10, 10 + 66);
        redEye5Left = Random.Range(73 + 10, 10 + 78);
        vent6 = Random.Range(85 + 10, 10 + 95);
        vent7 = Random.Range(101 + 10, 10 + 111);
        redEye8Right = Random.Range(120 + 10, 10 + 126);
        redEye9Right = Random.Range(134 + 10, 10 + 140);
        vent10 = Random.Range(148 + 10, 10 + 154);
        redEye11Left = Random.Range(160 + 10, 10 + 166);
        vent12 = Random.Range(175 + 10, 10 + 200);
        vent13 = Random.Range(207 + 10, 10 + 215);
        redEye14Right = Random.Range(222 + 10, 10 + 228);
        redEye15Left = Random.Range(231 + 10, 10 + 240);
        aS = GetComponent<AudioSource>();
        leftEyeHallwayAvertedObject.GetComponent<Animator>().enabled = false;        
        ventAvertedObject.GetComponent<Animator>().enabled = false;        
        Debug.Log(redEye1Left);
        Debug.Log(redEye2Right);
        Debug.Log(redEye3Right);
    }

    // Update is called once per frame
    void Update()
    {
        ToggleBetweenLaptopAndExteriorView();
        if (instructions == null && guidanceAudioEmpty != null)
        {
            laptopScreen.SetActive(true);
            if (!guidanceAudioEmpty.GetComponent<AudioSource>().isPlaying)
            {
                guidanceAudioEmpty.GetComponent<AudioSource>().PlayOneShot(guidanceAudioClip);
            }
            //else if (guidanceAudioEmpty == null)
            //{
            //    return;                   
            //}
            if (Time.timeSinceLevelLoad >= 38+10)
            {
                Destroy(guidanceAudioEmpty);
                Debug.Log("Time to destroy guidance empty");
            }
        }
        RunTime();
        Debug.Log(isLookingAtScreen);
        if (loseScreen.activeInHierarchy)
        {
            if (!aS.isPlaying)
            {
                aS.PlayOneShot(loseSFX);
            }
            Destroy(monster);
            Destroy(monster2);
            Destroy(monster3);
            Destroy(monster4);
            Destroy(monster5);
            Destroy(monster6);
            Destroy(monster7);
            Destroy(monster8);
            Destroy(monster9);
            Destroy(monster10);
            Destroy(monster11);
            Destroy(monster12);
            Destroy(monster13);
            Destroy(monster14);
            Destroy(monster15);
        }
        if (Time.timeSinceLevelLoad >= redEye1Left && Time.timeSinceLevelLoad <= redEye1Left + 5)
        {
            if (!aS.isPlaying)
            {
                aS.PlayOneShot(redEyesDoomSfx);
                Invoke(nameof(StopAudioAfterPlayed), 2.9f);
            }
            AvoidJumpscareLeft();
            Invoke(nameof(StopLeftEyeFromLooping), 4);
            redEyeLeftGameobject.SetActive(true);
            redEyeLeftGameobject.GetComponent<Animator>().enabled = true;
            redEyeLeftGameobject.GetComponent<Animator>().Play("RedEyesLightLeft", 0);
            hasAvoidedJumpscare = false;
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 6);
            leftHallwayGuidance.SetActive(true);
            if (isLookingAtScreen)
            {
                spaceGuidance.SetActive(true);
            }
        }
        if (Time.timeSinceLevelLoad >= redEye2Right && Time.timeSinceLevelLoad <= redEye2Right + 5.11f)
        {
            shouldInvokeJumpscare = true;
            if (!aS.isPlaying)
            {
                aS.PlayOneShot(redEyesDoomSfx);
                Invoke(nameof(StopAudioAfterPlayed), 2.9f);
            }
            AvoidJumpscareRight();
            Invoke(nameof(StartJumpscareForAllJumpscaresWithBug2), 5.1f);
            redEyeRightGameobject.SetActive(true);
            if (redEyeRightGameobject.activeInHierarchy == false)
            {
                redEyeRightGameobject.GetComponent<Animator>().enabled = true;
            }
            redEyeRightGameobject.GetComponent<Animator>().Play("RedEyesLightRight", 0);
            Invoke(nameof(StopRightEyeFromLooping), 4);
            hasAvoidedJumpscare = false;
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 6);
            if (Input.GetKeyDown(KeyCode.RightArrow) && isLookingAtScreen == false)
            {
                Debug.Log("Me gusta?");
                Destroy(monster2);
                Destroy(fadeOut2);
                Destroy(doomSFXEmpty2);
                Destroy(rightHallwayGuidance);
            }            
            if (isLookingAtScreen)
            {
                spaceGuidance.SetActive(true);
            }
            else
            {
                spaceGuidance.SetActive(false);
            }
        }

        if (Time.timeSinceLevelLoad >= redEye3Right && Time.timeSinceLevelLoad <= redEye3Right + 5.11f)
        {
            Debug.Log("juumpscare 3?");
            if (Input.GetKeyDown(KeyCode.RightArrow) && isLookingAtScreen == false)
            {
                Debug.Log("Me gusta?");
                Destroy(monster3);
                Destroy(fadeOut3);
                Destroy(doomSFXEmpty3);
            }
            shouldInvokeJumpscare = true;
            if (!aS.isPlaying)
            {
                aS.PlayOneShot(redEyesDoomSfx);
                Invoke(nameof(StopAudioAfterPlayed), 2.9f);
            }
            AvoidJumpscareRight();
            Invoke(nameof(StartJumpscareForAllJumpscaresWithBug3), 5.1f);
            redEyeRightGameobject.SetActive(true);
            if (redEyeRightGameobject.activeInHierarchy == false)
            {
                redEyeRightGameobject.GetComponent<Animator>().enabled = true;
            }
            redEyeRightGameobject.GetComponent<Animator>().Play("RedEyesLightRight", 0);
            Invoke(nameof(StopRightEyeFromLooping), 4);
            hasAvoidedJumpscare = false;
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 6);
        }

        if (Time.timeSinceLevelLoad >= vent4 && Time.timeSinceLevelLoad <= vent4 + 5.11f)
        {
            shouldInvokeJumpscare = true;
            AvoidJumpscareVent();
            Invoke(nameof(StartJumpscareForAllJumpscaresWithBug4), 5.1f);
            if (!ventDarknessGameobject.GetComponent<AudioSource>().isPlaying && monster4 != null)
            {
                ventDarknessGameobject.GetComponent<AudioSource>().enabled = true;
                ventDarknessGameobject.GetComponent<AudioSource>().volume = 1;
                ventDarknessGameobject.GetComponent<AudioSource>().PlayOneShot(crawlingInVent);
            }
            if (monster4 == null)
            {
                Destroy(ventDarknessGameobject);
            }
            hasAvoidedJumpscare = false;
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 6);
            if (Input.GetKeyDown(KeyCode.UpArrow) && isLookingAtScreen == false)
            {
                Debug.Log("Me gusta?");
                Destroy(monster4);
                Destroy(fadeOut4);
                Destroy(doomSFXEmpty4);
                Destroy(ventGuidance);
                ventAvertedObject.GetComponent<Animator>().enabled = true;
                ventAvertedObject.GetComponent<Animator>().Play("VentAverted", 0, 0f);
                if (!ventAvertedObject.GetComponent<AudioSource>().isPlaying)
                {
                    ventDarknessGameobject.GetComponent<AudioSource>().Stop();
                    ventAvertedObject.GetComponent<AudioSource>().volume = 0.2f;
                    ventAvertedObject.GetComponent<AudioSource>().PlayOneShot(hallwayDoorClose);
                }
            }
            ventGuidance.SetActive(true);
            if (isLookingAtScreen)
            {
                spaceGuidance.SetActive(true);
            }
        }
        if (Time.timeSinceLevelLoad >= redEye5Left && Time.timeSinceLevelLoad <= redEye5Left + 5.11f)
        {
            shouldInvokeJumpscare = true;
            if (!aS.isPlaying)
            {
                aS.PlayOneShot(redEyesDoomSfx);
                Invoke(nameof(StopAudioAfterPlayed), 2.9f);
            }
            AvoidJumpscareLeft();
            Invoke(nameof(StartJumpscareForAllJumpscaresWithBug5), 5.1f);
            redEyeLeftGameobject.SetActive(true);
            if (redEyeLeftGameobject.activeInHierarchy == false)
            {
                redEyeLeftGameobject.GetComponent<Animator>().enabled = true;
            }
            redEyeLeftGameobject.GetComponent<Animator>().Play("RedEyesLightRight", 0);
            Invoke(nameof(StopLeftEyeFromLooping), 4);
            hasAvoidedJumpscare = false;
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 6);
            if (Input.GetKeyDown(KeyCode.LeftArrow) && isLookingAtScreen == false)
            {
                Debug.Log("Me gusta?");
                Destroy(monster5);
                Destroy(fadeOut5);
                Destroy(doomSFXEmpty5);
            }
        }

        if (Time.timeSinceLevelLoad >= vent6 && Time.timeSinceLevelLoad <= vent6 + 5.11f)
        {
            shouldInvokeJumpscare = true;
            AvoidJumpscareVent();
            Invoke(nameof(StartJumpscareForAllJumpscaresWithBug6), 5.1f);
            if (!ventDarknessGameobject2.GetComponent<AudioSource>().isPlaying && monster6 != null)
            {
                ventDarknessGameobject2.GetComponent<AudioSource>().enabled = true;
                ventDarknessGameobject2.GetComponent<AudioSource>().volume = 1;
                ventDarknessGameobject2.GetComponent<AudioSource>().PlayOneShot(crawlingInVent);
            }
            if (monster6 == null)
            {
                Destroy(ventDarknessGameobject2);
            }
            hasAvoidedJumpscare = false;
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 6);
            if (Input.GetKeyDown(KeyCode.UpArrow) && isLookingAtScreen == false)
            {
                Debug.Log("Me gusta?");
                Destroy(monster6);
                Destroy(fadeOut6);
                Destroy(doomSFXEmpty6);
                ventAvertedObject2.GetComponent<Animator>().enabled = true;
                ventAvertedObject2.GetComponent<Animator>().Play("VentAverted", 0, 0f);
                if (!ventAvertedObject2.GetComponent<AudioSource>().isPlaying)
                {
                    ventDarknessGameobject2.GetComponent<AudioSource>().Stop();
                    ventAvertedObject2.GetComponent<AudioSource>().volume = 0.2f;
                    ventAvertedObject2.GetComponent<AudioSource>().PlayOneShot(hallwayDoorClose);
                }
            }
        }
        if (Time.timeSinceLevelLoad >= vent7 && Time.timeSinceLevelLoad <= vent7 + 5.11f)
        {
            shouldInvokeJumpscare = true;
            AvoidJumpscareVent();
            Invoke(nameof(StartJumpscareForAllJumpscaresWithBug7), 5.1f);
            if (!ventDarknessGameobject3.GetComponent<AudioSource>().isPlaying && monster7 != null)
            {
                ventDarknessGameobject3.GetComponent<AudioSource>().enabled = true;
                ventDarknessGameobject3.GetComponent<AudioSource>().volume = 1;
                ventDarknessGameobject3.GetComponent<AudioSource>().PlayOneShot(crawlingInVent);
            }
            if (monster7 == null)
            {
                Destroy(ventDarknessGameobject3);
            }
            hasAvoidedJumpscare = false;
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 6);
            if (Input.GetKeyDown(KeyCode.UpArrow) && isLookingAtScreen == false)
            {
                Debug.Log("Me gusta?");
                Destroy(monster7);
                Destroy(fadeOut7);
                Destroy(doomSFXEmpty7);
                ventAvertedObject3.GetComponent<Animator>().enabled = true;
                ventAvertedObject3.GetComponent<Animator>().Play("VentAverted", 0, 0f);
                if (!ventAvertedObject.GetComponent<AudioSource>().isPlaying)
                {
                    ventDarknessGameobject3.GetComponent<AudioSource>().Stop();
                    ventAvertedObject3.GetComponent<AudioSource>().volume = 0.2f;
                    ventAvertedObject3.GetComponent<AudioSource>().PlayOneShot(hallwayDoorClose);
                }
            }
        }
        if (Time.timeSinceLevelLoad >= redEye8Right && Time.timeSinceLevelLoad <= redEye8Right + 5.11f)
        {
            shouldInvokeJumpscare = true;
            if (!aS.isPlaying)
            {
                aS.PlayOneShot(redEyesDoomSfx);
                Invoke(nameof(StopAudioAfterPlayed), 2.9f);
            }
            AvoidJumpscareRight();
            Invoke(nameof(StartJumpscareForAllJumpscaresWithBug8), 5.1f);
            redEyeRightGameobject.SetActive(true);
            if (redEyeRightGameobject.activeInHierarchy == false)
            {
                redEyeRightGameobject.GetComponent<Animator>().enabled = true;
            }
            redEyeRightGameobject.GetComponent<Animator>().Play("RedEyesLightRight", 0);
            Invoke(nameof(StopRightEyeFromLooping), 4);
            hasAvoidedJumpscare = false;
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 6);
            if (Input.GetKeyDown(KeyCode.RightArrow) && isLookingAtScreen == false)
            {
                Debug.Log("Me gusta?");
                Destroy(monster8);
                Destroy(fadeOut8);
                Destroy(doomSFXEmpty8);
            }
        }
        if (Time.timeSinceLevelLoad >= redEye9Right && Time.timeSinceLevelLoad <= redEye9Right + 5.11f)
        {
            shouldInvokeJumpscare = true;
            if (!aS.isPlaying)
            {
                aS.PlayOneShot(redEyesDoomSfx);
                Invoke(nameof(StopAudioAfterPlayed), 2.9f);
            }
            AvoidJumpscareRight();
            Invoke(nameof(StartJumpscareForAllJumpscaresWithBug9), 5.1f);
            redEyeRightGameobject.SetActive(true);
            if (redEyeRightGameobject.activeInHierarchy == false)
            {
                redEyeRightGameobject.GetComponent<Animator>().enabled = true;
            }
            redEyeRightGameobject.GetComponent<Animator>().Play("RedEyesLightRight", 0);
            Invoke(nameof(StopRightEyeFromLooping), 4);
            hasAvoidedJumpscare = false;
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 6);
            if (Input.GetKeyDown(KeyCode.RightArrow) && isLookingAtScreen == false)
            {
                Debug.Log("Me gusta?");
                Destroy(monster9);
                Destroy(fadeOut9);
                Destroy(doomSFXEmpty9);
            }
        }
        if (Time.timeSinceLevelLoad >= vent10 && Time.timeSinceLevelLoad <= vent10 + 5.11f)
        {
            shouldInvokeJumpscare = true;
            AvoidJumpscareVent();
            Invoke(nameof(StartJumpscareForAllJumpscaresWithBug10), 5.1f);
            if (!ventDarknessGameobject4.GetComponent<AudioSource>().isPlaying && monster10 != null)
            {
                ventDarknessGameobject4.GetComponent<AudioSource>().enabled = true;
                ventDarknessGameobject4.GetComponent<AudioSource>().volume = 1;
                ventDarknessGameobject4.GetComponent<AudioSource>().PlayOneShot(crawlingInVent);
            }
            if (monster10 == null)
            {
                Destroy(ventDarknessGameobject4);
            }
            hasAvoidedJumpscare = false;
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 6);
            if (Input.GetKeyDown(KeyCode.UpArrow) && isLookingAtScreen == false)
            {
                Debug.Log("Me gusta?");
                Destroy(monster10);
                Destroy(fadeOut10);
                Destroy(doomSFXEmpty10);
                ventAvertedObject4.GetComponent<Animator>().enabled = true;
                ventAvertedObject4.GetComponent<Animator>().Play("VentAverted", 0, 0f);
                if (!ventAvertedObject4.GetComponent<AudioSource>().isPlaying)
                {
                    ventDarknessGameobject4.GetComponent<AudioSource>().Stop();
                    ventAvertedObject4.GetComponent<AudioSource>().volume = 0.2f;
                    ventAvertedObject4.GetComponent<AudioSource>().PlayOneShot(hallwayDoorClose);
                }
            }
        }
        if (Time.timeSinceLevelLoad >= redEye11Left && Time.timeSinceLevelLoad <= redEye11Left + 5.11f)
        {
            shouldInvokeJumpscare = true;
            if (!aS.isPlaying)
            {
                aS.PlayOneShot(redEyesDoomSfx);
                Invoke(nameof(StopAudioAfterPlayed), 2.9f);
            }
            AvoidJumpscareLeft();
            Invoke(nameof(StartJumpscareForAllJumpscaresWithBug11), 5.1f);
            redEyeLeftGameobject.SetActive(true);
            if (redEyeLeftGameobject.activeInHierarchy == false)
            {
                redEyeLeftGameobject.GetComponent<Animator>().enabled = true;
            }
            redEyeLeftGameobject.GetComponent<Animator>().Play("RedEyesLightRight", 0);
            Invoke(nameof(StopLeftEyeFromLooping), 4);
            hasAvoidedJumpscare = false;
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 6);
            if (Input.GetKeyDown(KeyCode.LeftArrow) && isLookingAtScreen == false)
            {
                Debug.Log("Me gusta?");
                Destroy(monster11);
                Destroy(fadeOut11);
                Destroy(doomSFXEmpty11);
            }
        }
        if (Time.timeSinceLevelLoad >= vent12 && Time.timeSinceLevelLoad <= vent12 + 5.11f)
        {
            shouldInvokeJumpscare = true;
            AvoidJumpscareVent();
            Invoke(nameof(StartJumpscareForAllJumpscaresWithBug12), 5.1f);
            if (!ventDarknessGameobject5.GetComponent<AudioSource>().isPlaying && monster12 != null)
            {
                ventDarknessGameobject5.GetComponent<AudioSource>().enabled = true;
                ventDarknessGameobject5.GetComponent<AudioSource>().volume = 1;
                ventDarknessGameobject5.GetComponent<AudioSource>().PlayOneShot(crawlingInVent);
            }
            if (monster12 == null)
            {
                Destroy(ventDarknessGameobject5);
            }
            hasAvoidedJumpscare = false;
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 6);
            if (Input.GetKeyDown(KeyCode.UpArrow) && isLookingAtScreen == false)
            {
                Debug.Log("Me gusta?");
                Destroy(monster12);
                Destroy(fadeOut12);
                Destroy(doomSFXEmpty12);
                ventAvertedObject5.GetComponent<Animator>().enabled = true;
                ventAvertedObject5.GetComponent<Animator>().Play("VentAverted", 0, 0f);
                if (!ventAvertedObject5.GetComponent<AudioSource>().isPlaying)
                {
                    ventDarknessGameobject5.GetComponent<AudioSource>().Stop();
                    ventAvertedObject5.GetComponent<AudioSource>().volume = 0.2f;
                    ventAvertedObject5.GetComponent<AudioSource>().PlayOneShot(hallwayDoorClose);
                }
            }
        }
        if (Time.timeSinceLevelLoad >= vent13 && Time.timeSinceLevelLoad <= vent13 + 5.11f)
        {
            shouldInvokeJumpscare = true;
            AvoidJumpscareVent();
            Invoke(nameof(StartJumpscareForAllJumpscaresWithBug13), 5.1f);
            if (!ventDarknessGameobject6.GetComponent<AudioSource>().isPlaying && monster13 != null)
            {
                ventDarknessGameobject6.GetComponent<AudioSource>().enabled = true;
                ventDarknessGameobject6.GetComponent<AudioSource>().volume = 1;
                ventDarknessGameobject6.GetComponent<AudioSource>().PlayOneShot(crawlingInVent);
            }
            if (monster13 == null)
            {
                Destroy(ventDarknessGameobject6);
            }
            hasAvoidedJumpscare = false;
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 6);
            if (Input.GetKeyDown(KeyCode.UpArrow) && isLookingAtScreen == false)
            {
                Debug.Log("Me gusta?");
                Destroy(monster13);
                Destroy(fadeOut13);
                Destroy(doomSFXEmpty13);
                ventAvertedObject6.GetComponent<Animator>().enabled = true;
                ventAvertedObject6.GetComponent<Animator>().Play("VentAverted", 0, 0f);
                if (!ventAvertedObject6.GetComponent<AudioSource>().isPlaying)
                {
                    ventDarknessGameobject6.GetComponent<AudioSource>().Stop();
                    ventAvertedObject6.GetComponent<AudioSource>().volume = 0.2f;
                    ventAvertedObject6.GetComponent<AudioSource>().PlayOneShot(hallwayDoorClose);
                }
            }
        }
        if (Time.timeSinceLevelLoad >= redEye14Right && Time.timeSinceLevelLoad <= redEye14Right + 5.11f)
        {
            shouldInvokeJumpscare = true;
            if (!aS.isPlaying)
            {
                aS.PlayOneShot(redEyesDoomSfx);
                Invoke(nameof(StopAudioAfterPlayed), 2.9f);
            }
            AvoidJumpscareRight();
            Invoke(nameof(StartJumpscareForAllJumpscaresWithBug14), 5.1f);
            redEyeRightGameobject.SetActive(true);
            if (redEyeRightGameobject.activeInHierarchy == false)
            {
                redEyeRightGameobject.GetComponent<Animator>().enabled = true;
            }
            redEyeRightGameobject.GetComponent<Animator>().Play("RedEyesLightRight", 0);
            Invoke(nameof(StopRightEyeFromLooping), 4);
            hasAvoidedJumpscare = false;
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 6);
            if (Input.GetKeyDown(KeyCode.RightArrow) && isLookingAtScreen == false)
            {
                Debug.Log("Me gusta?");
                Destroy(monster14);
                Destroy(fadeOut14);
                Destroy(doomSFXEmpty14);
            }
        }
        if (Time.timeSinceLevelLoad >= redEye15Left && Time.timeSinceLevelLoad <= redEye15Left + 5.11f)
        {
            shouldInvokeJumpscare = true;
            if (!aS.isPlaying)
            {
                aS.PlayOneShot(redEyesDoomSfx);
                Invoke(nameof(StopAudioAfterPlayed), 2.9f);
            }
            AvoidJumpscareLeft();
            Invoke(nameof(StartJumpscareForAllJumpscaresWithBug15), 5.1f);
            redEyeLeftGameobject.SetActive(true);
            if (redEyeLeftGameobject.activeInHierarchy == false)
            {
                redEyeLeftGameobject.GetComponent<Animator>().enabled = true;
            }
            redEyeLeftGameobject.GetComponent<Animator>().Play("RedEyesLightRight", 0);
            Invoke(nameof(StopLeftEyeFromLooping), 4);
            hasAvoidedJumpscare = false;
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 6);
            if (Input.GetKeyDown(KeyCode.LeftArrow) && isLookingAtScreen == false)
            {
                Debug.Log("Me gusta?");
                Destroy(monster15);
                Destroy(fadeOut15);
                Destroy(doomSFXEmpty15);
            }
        }
        if (monster.activeInHierarchy || monster2.activeInHierarchy || monster3.activeInHierarchy || monster4.activeInHierarchy || monster5.activeInHierarchy || monster6.activeInHierarchy ||
            monster7.activeInHierarchy || monster8.activeInHierarchy || monster9.activeInHierarchy || monster10.activeInHierarchy || monster11.activeInHierarchy || monster12.activeInHierarchy || monster13.activeInHierarchy || monster14.activeInHierarchy || monster15.activeInHierarchy)
        {
            Destroy(MainScreen);
            Destroy(Appliances);
            Destroy(Cleaning);
            Destroy(HomeSupplies);
            Destroy(laptop);
            Destroy(timer);
            Destroy(ventGuidance);
            Destroy(leftHallwayGuidance);
            Destroy(rightHallwayGuidance);
            if (isLookingAtScreen == true)
            {
                GetComponent<Animator>().Play("ZoomOutOfComputerNight2");
            }
        }
        //else
        //{
        //    return;
        //}

        if (instructions.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Destroy(instructions);
                doomSFXOpeningInstructions.SetActive(false);
                freezeTime = false;
                Time.timeScale = 1;
            }
        }
        //else
        //{
        //    Time.timeScale = 1;
        //}
        if (freezeTime == true)
        {
            Time.timeScale = 0;
        }
        if (freezeTime == false)
        {
            Time.timeScale = 1;
        }
        //else
        //{
        //    Time.timeScale = 1;
        //}
    }

    void RunTime()
    {        
        if (Time.timeSinceLevelLoad >= 10)
        {
            timer.GetComponent<Timer>().enabled = true;
            Destroy(timeline);
            timer.SetActive(true);            
        }
        //timer.GetComponent<TMP_Text>().text = Time.timeSinceLevelLoad.ToString();
        if (Time.timeSinceLevelLoad >= 250 && Time.timeSinceLevelLoad <= 255)
        {
            Debug.Log("add jumpscare material here");
            if (!aS.isPlaying)
            {
                aS.PlayOneShot(alarmBeep);
            }
            monster.SetActive(true);
            if (!doomSFXEmpty.GetComponent<AudioSource>().isPlaying)
            {
                doomSFXEmpty.GetComponent<AudioSource>().PlayOneShot(doomSFX);
            }
            fadeOut.SetActive(true);
            Invoke(nameof(TurnOnLoseScreenAfterDying), 1f);
        }                  
        if (!doomSFXOpeningInstructions.GetComponent<AudioSource>().isPlaying && doomSFXOpeningInstructions != null)
        {
            doomSFXOpeningInstructions.GetComponent<AudioSource>().PlayOneShot(doomSFX);
        }          
    }

    void StartJumpscareForAllJumpscaresWithBug2()
    {        
        if (monster2 != null && fadeOut2 != null && doomSFXEmpty2 != null)
        {
            fadeOut2.SetActive(true);
            doomSFXEmpty2.GetComponent<AudioSource>().PlayOneShot(doomSFX);
            monster2.SetActive(true);
            Invoke(nameof(TurnOnLoseScreenAfterDying), 1f);
            
        }        
        Destroy(rightHallwayGuidance);
        spaceGuidance.SetActive(false);
    }
    void StartJumpscareForAllJumpscaresWithBug3()
    {
        if (monster3 != null && fadeOut3 != null && doomSFXEmpty3 != null)
        {
            monster3.SetActive(true);
            fadeOut3.SetActive(true);
            doomSFXEmpty3.GetComponent<AudioSource>().PlayOneShot(doomSFX);
            Invoke(nameof(TurnOnLoseScreenAfterDying), 1f);
        }                
       
    }
    void StartJumpscareForAllJumpscaresWithBug4()
    {
        if (monster4 != null && fadeOut4 != null && doomSFXEmpty4 != null)
        {
            monster4.SetActive(true);
            fadeOut4.SetActive(true);
            Invoke(nameof(TurnOnLoseScreenAfterDying), 1f);
        }
        Destroy(ventGuidance);
        
        //doomSFXEmpty4.GetComponent<AudioSource>().PlayOneShot(doomSFX);
        
        Destroy(spaceGuidance);
    }
    void StartJumpscareForAllJumpscaresWithBug5()
    {
        if (monster5 != null && fadeOut5 != null && doomSFXEmpty5 != null)
        {
            monster5.SetActive(true);
            fadeOut5.SetActive(true);
            doomSFXEmpty5.GetComponent<AudioSource>().PlayOneShot(doomSFX);
            Invoke(nameof(TurnOnLoseScreenAfterDying), 1f);
        }        
       
    }
    
    void StartJumpscareForAllJumpscaresWithBug6()
    {
        if (monster6 != null && fadeOut6 != null && doomSFXEmpty6 != null)
        {
            monster6.SetActive(true);            
            fadeOut6.SetActive(true);
        }        
        //doomSFXEmpty4.GetComponent<AudioSource>().PlayOneShot(doomSFX);
        Invoke(nameof(TurnOnLoseScreenAfterDying), 1f);
    }
    void StartJumpscareForAllJumpscaresWithBug7()
    {
        if (monster7 != null && fadeOut7 != null && doomSFXEmpty7 != null)
        {
            monster7.SetActive(true);
            fadeOut7.SetActive(true);
            Invoke(nameof(TurnOnLoseScreenAfterDying), 1f);
        }
        
        //doomSFXEmpty4.GetComponent<AudioSource>().PlayOneShot(doomSFX);
        
    }
    void StartJumpscareForAllJumpscaresWithBug8()
    {
        if (monster8 != null && fadeOut8 != null && doomSFXEmpty8 != null)
        {
            monster8.SetActive(true);
            fadeOut8.SetActive(true);
            doomSFXEmpty8.GetComponent<AudioSource>().PlayOneShot(doomSFX);
            Invoke(nameof(TurnOnLoseScreenAfterDying), 1f);
        }

    }
    void StartJumpscareForAllJumpscaresWithBug9()
    {
        if (monster9 != null && fadeOut9 != null && doomSFXEmpty9 != null)
        {
            monster9.SetActive(true);
            fadeOut9.SetActive(true);
            doomSFXEmpty9.GetComponent<AudioSource>().PlayOneShot(doomSFX);
            Invoke(nameof(TurnOnLoseScreenAfterDying), 1f);
        }
        
        
    }
    void StartJumpscareForAllJumpscaresWithBug10()
    {
        if (monster10 != null && fadeOut10 != null && doomSFXEmpty10 != null)
        {
            monster10.SetActive(true);
            fadeOut10.SetActive(true);
            Invoke(nameof(TurnOnLoseScreenAfterDying), 1f);
        }
        
        //doomSFXEmpty4.GetComponent<AudioSource>().PlayOneShot(doomSFX);
       
    }
    void StartJumpscareForAllJumpscaresWithBug11()
    {
        if (monster11 != null && fadeOut11 != null && doomSFXEmpty11 != null)
        {
            monster11.SetActive(true);
            fadeOut11.SetActive(true);
            doomSFXEmpty11.GetComponent<AudioSource>().PlayOneShot(doomSFX);
            Invoke(nameof(TurnOnLoseScreenAfterDying), 1f);
        }
        
        
    }
    void StartJumpscareForAllJumpscaresWithBug12()
    {
        if (monster12 != null && fadeOut12 != null && doomSFXEmpty12 != null)
        {
            monster12.SetActive(true);         
            fadeOut12.SetActive(true);
            Invoke(nameof(TurnOnLoseScreenAfterDying), 1f);
        }
        
        //doomSFXEmpty11.GetComponent<AudioSource>().PlayOneShot(doomSFX);
        

    }
    void StartJumpscareForAllJumpscaresWithBug13()
    {
        if (monster13 != null && fadeOut13 != null && doomSFXEmpty13 != null)
        {
            monster13.SetActive(true);
            fadeOut12.SetActive(true);
            Invoke(nameof(TurnOnLoseScreenAfterDying), 1f);
        }
        //doomSFXEmpty11.GetComponent<AudioSource>().PlayOneShot(doomSFX);
        
    }
    void StartJumpscareForAllJumpscaresWithBug14()
    {
        if (monster14 != null && fadeOut14 != null && doomSFXEmpty14 != null)
        {
            monster14.SetActive(true);            
            fadeOut14.SetActive(true);
            doomSFXEmpty14.GetComponent<AudioSource>().PlayOneShot(doomSFX);
            Invoke(nameof(TurnOnLoseScreenAfterDying), 1f);
        }
        
        
    }
    void StartJumpscareForAllJumpscaresWithBug15()
    {
        if (monster15 != null && fadeOut15 != null && doomSFXEmpty15 != null)
        {
            monster15.SetActive(true);            
            fadeOut15.SetActive(true);
            doomSFXEmpty15.GetComponent<AudioSource>().PlayOneShot(doomSFX);
            Invoke(nameof(TurnOnLoseScreenAfterDying), 1f);
        }
        
        
    }
    void StopRightEyeFromLooping()
    {
        if (redEyeRightGameobject.active == true)
        {
            redEyeRightGameobject.SetActive(false);
        }
    }

    void StopLeftEyeFromLooping()
    {
        if (redEyeLeftGameobject.active == true)
        {
            redEyeLeftGameobject.SetActive(false);
        }
    }

    void TurnOnLoseScreenAfterDying()
    {
        loseScreen.SetActive(true);
        Destroy(fadeOut15);
        Destroy(fadeOut14);
        Destroy(fadeOut13);
        Destroy(fadeOut12);
        Destroy(fadeOut11);
        Destroy(fadeOut10);
        Destroy(fadeOut9);
        Destroy(fadeOut8);
        Destroy(fadeOut7);
        Destroy(fadeOut6);
        Destroy(fadeOut5);
        Destroy(fadeOut4);
        Destroy(fadeOut3);
        Destroy(fadeOut2);
        Destroy(fadeOut);
    }

    void AvoidJumpscareLeft()
    {
        if (hasAvoidedJumpscare == false)
        {
            //Debug.Log("need to avoid jumpscare now");
            if (Input.GetKeyDown(KeyCode.LeftArrow) && canCloseDoor == true && isLookingAtScreen == false)
            {
                canCloseDoor = false;
                //Debug.Log("Has avoided jumpscare?");
                hasAvoidedJumpscare = true;
                makeSureHasAvoidedJumpscareDoesntTurnFalse = true;
                //leftEyeHallwayAvertedObject.SetActive(true);
                leftEyeHallwayAvertedObject.GetComponent<Animator>().enabled = true;
                leftEyeHallwayAvertedObject.GetComponent<Animator>().Play("LeftHallwayEyeAvertedDoor", 0, 0f);
                if (!leftEyeHallwayAvertedObject.GetComponent<AudioSource>().isPlaying)
                {
                    leftEyeHallwayAvertedObject.GetComponent<AudioSource>().PlayOneShot(hallwayDoorClose);
                }
                Invoke(nameof(LeftHallwayAvertedDoor), 4f);
            }
        }
        Invoke(nameof(JumpscareAfterNotAvertingDanger), 5);
    }

    void AvoidJumpscareRight()
    {
        //JumpscareAfterNotAvertingDanger2();
        if (hasAvoidedJumpscare == false)
        {
            //Debug.Log("need to avoid jumpscare now");            
            if (Input.GetKeyDown(KeyCode.RightArrow) && canCloseDoor == true && isLookingAtScreen == false)
            {
                canCloseDoor = false;                
                //Debug.Log("Has avoided jumpscare?");
                hasAvoidedJumpscare = true;
                makeSureHasAvoidedJumpscareDoesntTurnFalse = true;
                shouldInvokeJumpscare = false;
                shouldNotScarePlayerAfterClosingDoorBug = true;
                //rightEyeHallwayAvertedObject.SetActive(true);
                rightEyeHallwayAvertedObject.GetComponent<Animator>().enabled = true;
                rightEyeHallwayAvertedObject.GetComponent<Animator>().ForceStateNormalizedTime(0);                
                rightEyeHallwayAvertedObject.GetComponent<Animator>().Play("RightHallwayEyeAvertedDoor", 0, 0f);
                if (!rightEyeHallwayAvertedObject.GetComponent<AudioSource>().isPlaying)
                {
                    rightEyeHallwayAvertedObject.GetComponent<AudioSource>().PlayOneShot(hallwayDoorClose);
                }
                Invoke(nameof(RightHallwayAvertedDoor), 4f);                
            }                        
        }
        //Invoke(nameof(JumpscareAfterNotAvertingDanger), 4);
        if (rightHallwayGuidance != null)
        {
            rightHallwayGuidance.SetActive(true);
        }
    }

    void AvoidJumpscareVent()
    {
        if (hasAvoidedJumpscare == false)
        {
            //Debug.Log("need to avoid jumpscare now");
            if (Input.GetKeyDown(KeyCode.UpArrow) && canCloseDoor == true && isLookingAtScreen == false)
            {
                canCloseDoor = false;
                //Debug.Log("Has avoided vent jumpscare?");
                hasAvoidedJumpscare = true;
                makeSureHasAvoidedJumpscareDoesntTurnFalse = true;
                shouldInvokeJumpscare = false;
                //ventAvertedObject.SetActive(true);
                
                //Invoke(nameof(VentAvertedDoor), 4f);
            }
        }
        //Invoke(nameof(JumpscareAfterNotAvertingDanger), 4);
    }

    void LeftHallwayAvertedDoor()
    {
        redEyeLeftGameobject.gameObject.SetActive(false);
        leftEyeHallwayAvertedObject.gameObject.GetComponent<Animator>().enabled = false;
    }

    void RightHallwayAvertedDoor()
    {
        redEyeRightGameobject.gameObject.SetActive(false);
        //rightEyeHallwayAvertedObject.gameObject.GetComponent<Animator>().enabled = false;
    }

    void VentAvertedDoor()
    {
        ventAvertedObject.gameObject.SetActive(false);
        ventAvertedObject.gameObject.GetComponent<Animator>().enabled = false;
    }

    void JumpscareAfterNotAvertingDanger()
    {
        if (leftHallwayGuidance != null)
        {
            Destroy(leftHallwayGuidance);
        }
        spaceGuidance.SetActive(false);
        if (makeSureHasAvoidedJumpscareDoesntTurnFalse == true)
        {
            if (hasAvoidedJumpscare == false)
            {
                hasAvoidedJumpscare = true;
            }
        }
        if (hasAvoidedJumpscare == false)
        {
            //this.GetComponent<Rigidbody>().isKinematic = true;
            //redEye1Left = 500;
            //redEye2Right = 500;
            //redEye3Right = 500;
            //vent4 = 500;
            redEye5Left = 500;
            vent6 = 500;
            vent7 = 500;
            redEye8Right = 500;
            redEye9Right = 500;
            vent10 = 500;
            redEye11Left = 500;
            vent12 = 500;
            vent13 = 500;
            redEye14Right = 500;
            redEye15Left = 500;
            //once timer is created make sure to set timer false here too
            monster.SetActive(true);
            fadeOut.SetActive(true);
            doomSFXEmpty.GetComponent<AudioSource>().PlayOneShot(doomSFX);
            //once created lose screen, make sure to enable it here
            Invoke(nameof(TurnOnLoseScreenAfterDying), 1f);
        }
    }

    void TurnBoolTrueToPrepareForNextJumpscare()
    {
        hasAvoidedJumpscare = true;
        //shouldInvokeJumpscare = false;
        makeSureHasAvoidedJumpscareDoesntTurnFalse = true;
        canCloseDoor = true;
        shouldNotScarePlayerAfterClosingDoorBug = false;
    }

    private void ToggleBetweenLaptopAndExteriorView()
    {        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isTransitioningToScreen == false)
            {
                isLookingAtScreen = !isLookingAtScreen;
            }               
            if (isLookingAtScreen == true)
            {
                cam.transform.localRotation = Quaternion.Euler(0, 0, 0);
                GetComponent<Animator>().Play("ZoomIntoComputerNight2");
                GetComponent<CapsuleCollider>().enabled = false;
                GetComponent<Rigidbody>().isKinematic = true;
                Invoke(nameof(TurnMainScreenActiveAfterZoomingIn), 1f);
            }
            if (isLookingAtScreen == false)
            {
                GetComponent<Animator>().Play("ZoomOutOfComputerNight2");
                GetComponent<CapsuleCollider>().enabled = true;
                GetComponent<Rigidbody>().isKinematic = false;
                MainScreen.SetActive(false);
                Appliances.SetActive(false);
                HomeSupplies.SetActive(false);
                Cleaning.SetActive(false);
            }
        }
    }

    private void TurnMainScreenActiveAfterZoomingIn()
    {
        if (GetComponent<Rigidbody>().isKinematic == false)
        {
            MainScreen.SetActive(true);
        }        
    }

    void StopAudioAfterPlayed()
    {
        if (aS.isPlaying)
        {
            aS.volume = 0f;
            Invoke(nameof(StartAudioAgain), 3.1f);
        }        
    }

    void StartAudioAgain()
    {
        aS.volume = 0.5f;
    }
}
