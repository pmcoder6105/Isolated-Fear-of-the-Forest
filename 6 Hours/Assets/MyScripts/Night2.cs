using UnityEngine;

public class Night2 : MonoBehaviour
{
    [SerializeField] GameObject laptop;
    [SerializeField] GameObject MainScreen;
    [SerializeField] GameObject Appliances;
    [SerializeField] GameObject HomeSupplies;
    [SerializeField] GameObject Cleaning;
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
    [SerializeField] public GameObject doomSFXEmpty15;
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
    [SerializeField] GameObject redEyeLeftGameobject;
    [SerializeField] GameObject redEyeRightGameobject;
    bool hasAvoidedJumpscare = true;
    bool makeSureHasAvoidedJumpscareDoesntTurnFalse = false;
    AudioSource aS;
    [SerializeField] AudioClip redEyesDoomSfx;
    [SerializeField] public AudioClip doomSFX;
    [SerializeField] AudioClip hallwayDoorClose;
    [SerializeField] GameObject leftEyeHallwayAvertedObject;
    [SerializeField] GameObject rightEyeHallwayAvertedObject;
    [SerializeField] GameObject ventDarknessGameobject;
    [SerializeField] GameObject ventAvertedObject;
    [SerializeField] AudioClip crawlingInVent;
    bool canCloseDoor = true;
    bool shouldInvokeJumpscare = false;
    bool shouldNotScarePlayerAfterClosingDoorBug = false;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Animator>().Play("PlayerEnteringRoomNight2", 0);
        bT = FindObjectOfType<Buttons>();
        redEye1Left = Random.Range(5 + 10, 9 + 10);
        redEye2Right = Random.Range(15 + 10, 10 + 21);
        redEye3Right = Random.Range(27 + 10, 10 + 35);
        vent4 = Random.Range(40 + 10, 10 + 43);
        redEye5Left = Random.Range(50 + 10, 10 + 57);
        vent6 = Random.Range(65 + 10, 10 + 71);
        vent7 = Random.Range(78 + 10, 10 + 85);
        redEye8Right = Random.Range(95 + 10, 10 + 104);
        redEye9Right = Random.Range(111 + 10, 10 + 119);
        vent10 = Random.Range(126 + 10, 10 + 131);
        redEye11Left = Random.Range(138 + 10, 10 + 145);
        vent12 = Random.Range(160 + 10, 10 + 175);
        vent13 = Random.Range(182 + 10, 10 + 189);
        redEye14Right = Random.Range(195 + 10, 10 + 201);
        redEye15Left = Random.Range(206 + 10, 10 + 210);
        aS = GetComponent<AudioSource>();
        leftEyeHallwayAvertedObject.GetComponent<Animator>().enabled = false;        
        ventAvertedObject.GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(shouldNotScarePlayerAfterClosingDoorBug + " this is shouldNotScarePlayerAfterClosingDoorBug");
        ToggleBetweenLaptopAndExteriorView();
        if (Time.time >= redEye1Left && Time.time <= redEye1Left + 5)
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
        }        
        if (Time.time >= redEye2Right && Time.time <= redEye2Right + 5.11f)
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
            if (redEyeRightGameobject.active == false)
            {
                redEyeRightGameobject.GetComponent<Animator>().enabled = true;
            }
            redEyeRightGameobject.GetComponent<Animator>().Play("RedEyesLightRight", 0);
            Invoke(nameof(StopRightEyeFromLooping), 4);
            hasAvoidedJumpscare = false;         
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 6);
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log("Me gusta?");
                Destroy(monster2);
                Destroy(fadeOut2);
                Destroy(doomSFXEmpty2);
            }
        }

        if (Time.time >= redEye3Right && Time.time <= redEye3Right + 5.11f)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
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
            if (redEyeRightGameobject.active == false)
            {
                redEyeRightGameobject.GetComponent<Animator>().enabled = true;
            }
            redEyeRightGameobject.GetComponent<Animator>().Play("RedEyesLightRight", 0);
            Invoke(nameof(StopRightEyeFromLooping), 4);
            hasAvoidedJumpscare = false;            
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 6);            
        }

        if (Time.time >= vent4 && Time.time <= vent4 + 5.11f)
        {
            shouldInvokeJumpscare = true;
            AvoidJumpscareVent();
            Invoke(nameof(StartJumpscareForAllJumpscaresWithBug4), 5.1f);
            if (!ventDarknessGameobject.GetComponent<AudioSource>().isPlaying && monster4 == null)
            {
                ventDarknessGameobject.GetComponent<AudioSource>().volume = 0.5f;
                ventDarknessGameobject.GetComponent<AudioSource>().PlayOneShot(crawlingInVent);
            }            
            else if (hasAvoidedJumpscare == true)
            {
                ventDarknessGameobject.GetComponent<AudioSource>().Stop();
            }
            hasAvoidedJumpscare = false;            
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 6);
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("Me gusta?");
                Destroy(monster4);
                Destroy(fadeOut4);
                Destroy(doomSFXEmpty4);
            }
        }
        if (Time.time >= redEye5Left && Time.time <= redEye5Left + 5.11f)
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
            if (redEyeLeftGameobject.active == false)
            {
                redEyeLeftGameobject.GetComponent<Animator>().enabled = true;
            }
            redEyeLeftGameobject.GetComponent<Animator>().Play("RedEyesLightRight", 0);
            Invoke(nameof(StopLeftEyeFromLooping), 4);
            hasAvoidedJumpscare = false;
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 6);
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Debug.Log("Me gusta?");
                Destroy(monster5);
                Destroy(fadeOut5);
                Destroy(doomSFXEmpty5);
            }
        }

        if (Time.time >= vent6 && Time.time <= vent6 + 5.11f)
        {
            shouldInvokeJumpscare = true;
            AvoidJumpscareVent();
            Invoke(nameof(StartJumpscareForAllJumpscaresWithBug6), 5.1f);
            if (!ventDarknessGameobject.GetComponent<AudioSource>().isPlaying && monster4 == null)
            {
                ventDarknessGameobject.GetComponent<AudioSource>().volume = 0.5f;
                ventDarknessGameobject.GetComponent<AudioSource>().PlayOneShot(crawlingInVent);
            }
            else if (hasAvoidedJumpscare == true)
            {
                ventDarknessGameobject.GetComponent<AudioSource>().Stop();
            }
            hasAvoidedJumpscare = false;
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 6);
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("Me gusta?");
                Destroy(monster6);
                Destroy(fadeOut6);
                Destroy(doomSFXEmpty6);
            }
        }
        if (Time.time >= vent7 && Time.time <= vent7 + 5.11f)
        {
            shouldInvokeJumpscare = true;
            AvoidJumpscareVent();
            Invoke(nameof(StartJumpscareForAllJumpscaresWithBug7), 5.1f);
            if (!ventDarknessGameobject.GetComponent<AudioSource>().isPlaying && monster4 == null)
            {
                ventDarknessGameobject.GetComponent<AudioSource>().volume = 0.5f;
                ventDarknessGameobject.GetComponent<AudioSource>().PlayOneShot(crawlingInVent);
            }
            else if (hasAvoidedJumpscare == true)
            {
                ventDarknessGameobject.GetComponent<AudioSource>().Stop();
            }
            hasAvoidedJumpscare = false;
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 6);
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("Me gusta?");
                Destroy(monster7);
                Destroy(fadeOut7);
                Destroy(doomSFXEmpty7);
            }
        }
        if (Time.time >= redEye8Right && Time.time <= redEye8Right + 5.11f)
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
            if (redEyeRightGameobject.active == false)
            {
                redEyeRightGameobject.GetComponent<Animator>().enabled = true;
            }
            redEyeRightGameobject.GetComponent<Animator>().Play("RedEyesLightRight", 0);
            Invoke(nameof(StopRightEyeFromLooping), 4);
            hasAvoidedJumpscare = false;
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 6);
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log("Me gusta?");
                Destroy(monster8);
                Destroy(fadeOut8);
                Destroy(doomSFXEmpty8);
            }
        }
        if (Time.time >= redEye9Right && Time.time <= redEye9Right + 5.11f)
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
            if (redEyeRightGameobject.active == false)
            {
                redEyeRightGameobject.GetComponent<Animator>().enabled = true;
            }
            redEyeRightGameobject.GetComponent<Animator>().Play("RedEyesLightRight", 0);
            Invoke(nameof(StopRightEyeFromLooping), 4);
            hasAvoidedJumpscare = false;
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 6);
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log("Me gusta?");
                Destroy(monster9);
                Destroy(fadeOut9);
                Destroy(doomSFXEmpty9);
            }
        }
        if (Time.time >= vent10 && Time.time <= vent10 + 5.11f)
        {
            shouldInvokeJumpscare = true;
            AvoidJumpscareVent();
            Invoke(nameof(StartJumpscareForAllJumpscaresWithBug10), 5.1f);
            if (!ventDarknessGameobject.GetComponent<AudioSource>().isPlaying && monster4 == null)
            {
                ventDarknessGameobject.GetComponent<AudioSource>().volume = 0.5f;
                ventDarknessGameobject.GetComponent<AudioSource>().PlayOneShot(crawlingInVent);
            }
            else if (hasAvoidedJumpscare == true)
            {
                ventDarknessGameobject.GetComponent<AudioSource>().Stop();
            }
            hasAvoidedJumpscare = false;
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 6);
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("Me gusta?");
                Destroy(monster10);
                Destroy(fadeOut10);
                Destroy(doomSFXEmpty10);
            }
        }
        if (Time.time >= redEye11Left && Time.time <= redEye11Left + 5.11f)
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
            if (redEyeLeftGameobject.active == false)
            {
                redEyeLeftGameobject.GetComponent<Animator>().enabled = true;
            }
            redEyeLeftGameobject.GetComponent<Animator>().Play("RedEyesLightRight", 0);
            Invoke(nameof(StopLeftEyeFromLooping), 4);
            hasAvoidedJumpscare = false;
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 6);
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Debug.Log("Me gusta?");
                Destroy(monster11);
                Destroy(fadeOut11);
                Destroy(doomSFXEmpty11);
            }
        }
        if (Time.time >= vent12 && Time.time <= vent12 + 5.11f)
        {
            shouldInvokeJumpscare = true;
            AvoidJumpscareVent();
            Invoke(nameof(StartJumpscareForAllJumpscaresWithBug12), 5.1f);
            if (!ventDarknessGameobject.GetComponent<AudioSource>().isPlaying && monster4 == null)
            {
                ventDarknessGameobject.GetComponent<AudioSource>().volume = 0.5f;
                ventDarknessGameobject.GetComponent<AudioSource>().PlayOneShot(crawlingInVent);
            }
            else if (hasAvoidedJumpscare == true)
            {
                ventDarknessGameobject.GetComponent<AudioSource>().Stop();
            }
            hasAvoidedJumpscare = false;
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 6);
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("Me gusta?");
                Destroy(monster12);
                Destroy(fadeOut12);
                Destroy(doomSFXEmpty12);
            }
        }
        if (Time.time >= vent13 && Time.time <= vent13 + 5.11f)
        {
            shouldInvokeJumpscare = true;
            AvoidJumpscareVent();
            Invoke(nameof(StartJumpscareForAllJumpscaresWithBug13), 5.1f);
            if (!ventDarknessGameobject.GetComponent<AudioSource>().isPlaying && monster4 == null)
            {
                ventDarknessGameobject.GetComponent<AudioSource>().volume = 0.5f;
                ventDarknessGameobject.GetComponent<AudioSource>().PlayOneShot(crawlingInVent);
            }
            else if (hasAvoidedJumpscare == true)
            {
                ventDarknessGameobject.GetComponent<AudioSource>().Stop();
            }
            hasAvoidedJumpscare = false;
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 6);
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("Me gusta?");
                Destroy(monster13);
                Destroy(fadeOut13);
                Destroy(doomSFXEmpty13);
            }
        }
        if (Time.time >= redEye14Right && Time.time <= redEye14Right + 5.11f)
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
            if (redEyeRightGameobject.active == false)
            {
                redEyeRightGameobject.GetComponent<Animator>().enabled = true;
            }
            redEyeRightGameobject.GetComponent<Animator>().Play("RedEyesLightRight", 0);
            Invoke(nameof(StopRightEyeFromLooping), 4);
            hasAvoidedJumpscare = false;
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 6);
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log("Me gusta?");
                Destroy(monster14);
                Destroy(fadeOut14);
                Destroy(doomSFXEmpty14);
            }
        }
        if (Time.time >= redEye15Left && Time.time <= redEye15Left + 5.11f)
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
            if (redEyeLeftGameobject.active == false)
            {
                redEyeLeftGameobject.GetComponent<Animator>().enabled = true;
            }
            redEyeLeftGameobject.GetComponent<Animator>().Play("RedEyesLightRight", 0);
            Invoke(nameof(StopLeftEyeFromLooping), 4);
            hasAvoidedJumpscare = false;
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 6);
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Debug.Log("Me gusta?");
                Destroy(monster15);
                Destroy(fadeOut15);
                Destroy(doomSFXEmpty15);
            }
        }
        if (monster.active || monster2.active || monster3.active || monster4.active || monster5.active || monster6.active || 
            monster7.active || monster8.active || monster9.active || monster10.active || monster11.active || monster12.active || monster13.active || monster14.active || monster15.active)
        {
            MainScreen.SetActive(false);
            Appliances.SetActive(false);
            HomeSupplies.SetActive(false);
            Cleaning.SetActive(false);
            laptop.SetActive(false);
        }
    }

    void StartJumpscareForAllJumpscaresWithBug2()
    {        
        monster2.SetActive(true);
        fadeOut2.SetActive(true);
        doomSFXEmpty2.GetComponent<AudioSource>().PlayOneShot(doomSFX);                    
    }
    void StartJumpscareForAllJumpscaresWithBug3()
    {
        monster3.SetActive(true);
        fadeOut3.SetActive(true);
        doomSFXEmpty3.GetComponent<AudioSource>().PlayOneShot(doomSFX);
    }
    void StartJumpscareForAllJumpscaresWithBug4()
    {
        monster4.SetActive(true);
        fadeOut4.SetActive(true);
        //doomSFXEmpty4.GetComponent<AudioSource>().PlayOneShot(doomSFX);
    }
    void StartJumpscareForAllJumpscaresWithBug5()
    {
        monster5.SetActive(true);
        fadeOut5.SetActive(true);
        doomSFXEmpty5.GetComponent<AudioSource>().PlayOneShot(doomSFX);
    }
    
    void StartJumpscareForAllJumpscaresWithBug6()
    {
        monster6.SetActive(true);
        fadeOut6.SetActive(true);
        //doomSFXEmpty4.GetComponent<AudioSource>().PlayOneShot(doomSFX);
    }
    void StartJumpscareForAllJumpscaresWithBug7()
    {
        monster7.SetActive(true);
        fadeOut7.SetActive(true);
        //doomSFXEmpty4.GetComponent<AudioSource>().PlayOneShot(doomSFX);
    }
    void StartJumpscareForAllJumpscaresWithBug8()
    {
        monster8.SetActive(true);
        fadeOut8.SetActive(true);
        doomSFXEmpty8.GetComponent<AudioSource>().PlayOneShot(doomSFX);
    }
    void StartJumpscareForAllJumpscaresWithBug9()
    {
        monster9.SetActive(true);
        fadeOut9.SetActive(true);
        doomSFXEmpty9.GetComponent<AudioSource>().PlayOneShot(doomSFX);
    }
    void StartJumpscareForAllJumpscaresWithBug10()
    {
        monster10.SetActive(true);
        fadeOut10.SetActive(true);
        //doomSFXEmpty4.GetComponent<AudioSource>().PlayOneShot(doomSFX);
    }
    void StartJumpscareForAllJumpscaresWithBug11()
    {
        monster11.SetActive(true);
        fadeOut11.SetActive(true);
        doomSFXEmpty11.GetComponent<AudioSource>().PlayOneShot(doomSFX);
    }
    void StartJumpscareForAllJumpscaresWithBug12()
    {
        monster12.SetActive(true);
        fadeOut12.SetActive(true);
        //doomSFXEmpty11.GetComponent<AudioSource>().PlayOneShot(doomSFX);

    }
    void StartJumpscareForAllJumpscaresWithBug13()
    {
        monster12.SetActive(true);
        fadeOut12.SetActive(true);
        //doomSFXEmpty11.GetComponent<AudioSource>().PlayOneShot(doomSFX);
    }
    void StartJumpscareForAllJumpscaresWithBug14()
    {
        monster14.SetActive(true);
        fadeOut14.SetActive(true);
        doomSFXEmpty14.GetComponent<AudioSource>().PlayOneShot(doomSFX);
    }
    void StartJumpscareForAllJumpscaresWithBug15()
    {
        monster15.SetActive(true);
        fadeOut15.SetActive(true);
        doomSFXEmpty15.GetComponent<AudioSource>().PlayOneShot(doomSFX);
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

    void AvoidJumpscareLeft()
    {
        if (hasAvoidedJumpscare == false)
        {            
            //Debug.Log("need to avoid jumpscare now");
            if (Input.GetKeyDown(KeyCode.LeftArrow) && canCloseDoor == true)
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
            if (Input.GetKeyDown(KeyCode.RightArrow) && canCloseDoor == true)
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
    }

    void AvoidJumpscareVent()
    {
        if (hasAvoidedJumpscare == false)
        {
            //Debug.Log("need to avoid jumpscare now");
            if (Input.GetKeyDown(KeyCode.UpArrow) && canCloseDoor == true)
            {
                canCloseDoor = false;
                //Debug.Log("Has avoided vent jumpscare?");
                hasAvoidedJumpscare = true;
                makeSureHasAvoidedJumpscareDoesntTurnFalse = true;
                shouldInvokeJumpscare = false;
                //ventAvertedObject.SetActive(true);
                ventAvertedObject.GetComponent<Animator>().enabled = true;
                ventAvertedObject.GetComponent<Animator>().Play("VentAverted", 0, 0f);
                if (!ventAvertedObject.GetComponent<AudioSource>().isPlaying)
                {
                    ventDarknessGameobject.GetComponent<AudioSource>().Stop();
                    ventAvertedObject.GetComponent<AudioSource>().volume = 0.2f;
                    ventAvertedObject.GetComponent<AudioSource>().PlayOneShot(hallwayDoorClose);
                }
                Invoke(nameof(VentAvertedDoor), 4f);
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
