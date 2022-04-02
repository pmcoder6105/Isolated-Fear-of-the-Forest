using TMPro;
using UnityEngine;

public class Night1 : MonoBehaviour
{
    [SerializeField] bool aNOn = true;
    Animator aN;
    AudioSource aS;
    bool isOnTrail = false;
    [SerializeField] GameObject monster;
    [SerializeField] GameObject night1Instructions;
    [SerializeField] GameObject doomSFXEmpty;
    [SerializeField] GameObject fadeOut;
    [SerializeField] GameObject bloodOverlay;
    [SerializeField] GameObject radio;
    [SerializeField] GameObject canvas;
    [SerializeField] AudioClip rustle;
    [SerializeField] AudioClip radioSFX;
    [SerializeField] AudioClip doomSFX;
    [SerializeField] AudioClip loseSFX;
    [SerializeField] AudioClip winSFX;
    [SerializeField] AudioClip alarmBeep;
    [SerializeField] GameObject timer;
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject loseScreen;
    Vector3 monsterPos;
    int rustle1;
    int rustle2;
    int rustle3;
    int rustle4;
    int rustle5;
    int rustle6;
    int rustle7;
    float time = 0f;
    bool hasAvoidedJumpscareRustle;
    bool makeSureHasAvoidedDoesntTurnFalse = false;
    bool hasSeenNight1Instructions = false;
    bool shouldStartTimer = false;
    [SerializeField] GameObject audioTrackingBeginningTimeline;
    [SerializeField] GameObject car;
    [SerializeField] public bool shouldSkipIntro = false;
    GameControl gC;

    // Start is called before the first frame update
    void Start()
    {
        aS = GetComponent<AudioSource>();
        aN = GetComponent<Animator>();
        if (shouldSkipIntro == false)
        {
            rustle1 = Random.Range(10 + 30, 30 + 16);
            rustle2 = Random.Range(22 + 30, 30 + 51);
            rustle3 = Random.Range(60 + 30, 30 + 78);
            rustle4 = Random.Range(85 + 30, 30 + 94);
            rustle5 = Random.Range(96 + 30, 30 + 106);
            rustle6 = Random.Range(110 + 30, 30 + 115);
            rustle7 = Random.Range(116 + 30, 30 + 120);
        }        
        DebugKeys();
        Debug.Log(rustle1);
        Debug.Log(rustle2);
        Debug.Log(rustle3);
        Debug.Log(rustle4);
        Debug.Log(rustle5);
        Debug.Log(rustle6);
        Debug.Log(rustle7);
        gC = FindObjectOfType<GameControl>();
    }

    void DebugKeys()
    {
        if (shouldSkipIntro == true)
        {            
            aN.ForceStateNormalizedTime(1);
            audioTrackingBeginningTimeline.SetActive(false);
            fadeOut.GetComponent<Animator>().ForceStateNormalizedTime(1);
            car.SetActive(false);            
            rustle1 = Random.Range(10, 16);
            rustle2 = Random.Range(22, 51);
            rustle3 = Random.Range(60, 78);
            rustle4 = Random.Range(85, 94);
            rustle5 = Random.Range(96, 106);
            rustle6 = Random.Range(110, 115);
            rustle7 = Random.Range(116, 120);          
        }        
    }   

    // Update is called once per frame
    void Update()
    {
        EnablePlayerMovementAfterCutscene();
        RustleTest();
        RunTime();
        if (Input.GetKeyDown(KeyCode.H))
        {
            this.gameObject.transform.position = new Vector3(12.71f, -6.497f, -18.334f);
        }
    }

    private void RunTime()
    {
        if (shouldStartTimer == true)
        {
            timer.SetActive(true);
            if (shouldSkipIntro == false)
            {
                float timeNeeded = Time.time - 30;
                timer.GetComponent<TMP_Text>().text = timeNeeded.ToString();
                if (Time.time > 140 && Time.time < 149)
                {
                    if (!aS.isPlaying)
                    {
                        timer.GetComponent<TMP_Text>().text = "2:00";
                        aS.Stop();
                        aS.PlayOneShot(alarmBeep);
                        Invoke(nameof(StopAudioWithEpsilon), 3);
                        Invoke(nameof(Jumpscare), 2f);
                    }
                    bloodOverlay.SetActive(true);
                    Invoke(nameof(TurnFadeOutBackOffLose), 1f);
                    Invoke(nameof(TurnOnLoseScreen), 1f);
                    doomSFXEmpty.GetComponent<AudioSource>().PlayOneShot(doomSFX);
                    this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
                }
            }  
            if (shouldSkipIntro == true)
            {
                timer.GetComponent<TMP_Text>().text = Time.timeSinceLevelLoad.ToString();
                if (Time.time > 120 && Time.time < 129)
                {
                    if (!aS.isPlaying)
                    {
                        timer.GetComponent<TMP_Text>().text = "2:00";
                        aS.Stop();
                        aS.PlayOneShot(alarmBeep);
                        Invoke(nameof(StopAudioWithEpsilon), 3);
                        Invoke(nameof(Jumpscare), 0.5f);
                    }
                    bloodOverlay.SetActive(true);
                    Invoke(nameof(TurnFadeOutBackOffLose), 1f);
                    Invoke(nameof(TurnOnLoseScreen), 1f);
                    doomSFXEmpty.GetComponent<AudioSource>().PlayOneShot(doomSFX);
                    this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
                }
            }
        }
        
    }

    void StopAudioWithEpsilon()
    {
        aS.Stop();
    }

    void RustleTest()
    {
        time += Time.deltaTime;
        if (time >= rustle1 && time <= rustle1 + 1)
        {
            hasAvoidedJumpscareRustle = false;
            AvoidJumpscare();
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 5f);
            aS.volume = 0.01f;
        }
        if (time >= rustle2 && time <= rustle2 + 1)
        {
            hasAvoidedJumpscareRustle = false;
            AvoidJumpscare();
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 5f);
            aS.volume = 0.01f;
        }
        if (time >= rustle3 && time <= rustle3 + 1)
        {
            hasAvoidedJumpscareRustle = false;
            AvoidJumpscare();
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 5f);
            aS.volume = 0.01f;
        }
        if (time >= rustle4 && time <= rustle4 + 1)
        {
            hasAvoidedJumpscareRustle = false;
            AvoidJumpscare();
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 5f);
            aS.volume = 0.01f;
        }
        if (time >= rustle5 && time <= rustle5 + 1)
        {
            hasAvoidedJumpscareRustle = false;
            AvoidJumpscare();
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 5f);
            aS.volume = 0.01f;
        }
        if (time >= rustle6 && time <= rustle6 + 1)
        {
            hasAvoidedJumpscareRustle = false;
            AvoidJumpscare();
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 5f);
            aS.volume = 0.01f;
        }
        if (time >= rustle7 && time <= rustle7 + 1)
        {
            hasAvoidedJumpscareRustle = false;
            AvoidJumpscare();
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 5f);
            aS.volume = 0.01f;
        }
    }

    private void TurnBoolTrueToPrepareForNextJumpscare()
    {
        hasAvoidedJumpscareRustle = true;
    }

    void AvoidJumpscare()
    {
        if (hasAvoidedJumpscareRustle == false)
        {
            if (!aS.isPlaying)
            {
                aS.Stop();
                aS.PlayOneShot(rustle);
            }
            Debug.Log("played rustle");
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                hasAvoidedJumpscareRustle = true;
                makeSureHasAvoidedDoesntTurnFalse = true;
                
                Debug.Log("averted jumpscare?");
                if (!radio.GetComponent<AudioSource>().isPlaying)
                {
                    //radio.GetComponent<AudioSource>().Stop();
                    radio.GetComponent<AudioSource>().PlayOneShot(radioSFX);
                }
                else if (radio.GetComponent<AudioSource>().isPlaying)
                {
                    radio.GetComponent<AudioSource>().Stop();
                    radio.GetComponent<AudioSource>().PlayOneShot(radioSFX);
                }
                return;
            }
        }
        Invoke(nameof(JumpscareAfterNotPlayingAudio), 2f);
    }

    void JumpscareAfterNotPlayingAudio()
    {
        if (makeSureHasAvoidedDoesntTurnFalse == true)
        {
            if (hasAvoidedJumpscareRustle == false)
            {
                hasAvoidedJumpscareRustle = true;
            }
        }        
        if (hasAvoidedJumpscareRustle == false)
        {
            Jumpscare();
            bloodOverlay.SetActive(true);
            Invoke(nameof(TurnFadeOutBackOffLose), 1f);
            Invoke(nameof(TurnOnLoseScreen), 1f);
            doomSFXEmpty.GetComponent<AudioSource>().PlayOneShot(doomSFX);
            this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
        }
    }

    void EnablePlayerMovementAfterCutscene()
    {
        if (aNOn == false)
        {
            aN.enabled = false;
            night1Instructions.SetActive(true);
        }
        else if (aNOn == true)
        {
            aN.enabled = true;
        }
        if (night1Instructions.active == true)
        {
            Invoke(nameof(PlayerHasSeenInstructions), 5f);
            NightOneInstructionsOff();
            shouldStartTimer = true;
            if (!aS.isPlaying)
            {
                aS.Stop();
                Invoke(nameof(PlayDoomSFX), 0.1f);
                Invoke(nameof(StopMusic), 7);
            }            
        }
    }

    private void PlayerHasSeenInstructions()
    {
        hasSeenNight1Instructions = true;
    }

    void NightOneInstructionsOff()
    {
        if (hasSeenNight1Instructions == true)
        {
            Invoke(nameof(PlayGame), .1f);
        }
    }

    void PlayGame()
    {
        canvas.SetActive(false);
        shouldStartTimer = true;
    }

    private void PlayDoomSFX()
    {
        doomSFXEmpty.GetComponent<AudioSource>().PlayOneShot(doomSFX);
    }

    void StopMusic()
    {
        doomSFXEmpty.SetActive(false);
    }

    void OnCollisionEnter(Collision other)
    {
        CheckIfOnTrail(other);
        if (other.gameObject.tag == "House")
        {
            Debug.Log("youve won");
            aS.Stop();
            this.gameObject.GetComponent<Rigidbody>().useGravity = false;
            this.gameObject.GetComponent<GameControl>().enabled = false;
            this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            monster = null;
            gC.walkingEmpty.SetActive(false);
            fadeOut.GetComponent<Animator>().Play("DeathFadeOut", 0);
            rustle1 = 500;
            rustle2 = 500;
            rustle3 = 500;
            rustle4 = 500;
            rustle5 = 500;
            rustle6 = 500;
            rustle7 = 500;
            Invoke(nameof(TurnFadeOutBackOffWin), 1f);
            timer.SetActive(false);
            this.gameObject.GetComponent<Animator>().enabled = true;
            aN.Play("TurnOffControlToEnableCursor", 0);
            doomSFXEmpty.GetComponent<AudioSource>().PlayOneShot(doomSFX);
        }
    }

    private void TurnFadeOutBackOffWin()
    {
        fadeOut.SetActive(false);
        winScreen.SetActive(true);
        if (!aS.isPlaying)
        {
            aS.PlayOneShot(winSFX);
        }
    }

    void CheckIfOnTrail(Collision other)
    {
        if (other.gameObject.tag != "Trail" && other.gameObject.tag != "House")
        {
            //isOnTrail = false;            
            Jumpscare();
            bloodOverlay.SetActive(true);
            Invoke(nameof(TurnFadeOutBackOffLose), 1f);
            Invoke(nameof(TurnOnLoseScreen), 1f);
            doomSFXEmpty.GetComponent<AudioSource>().PlayOneShot(doomSFX);
            this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
        }
    }

    private void TurnOnLoseScreen()
    {
        loseScreen.SetActive(true);
    }

    void TurnFadeOutBackOffLose()
    {
        fadeOut.SetActive(false);
    }

    void Jumpscare()
    {
        //monsterPos = monster.gameObject.transform.position;
        aNOn = true;
        GetComponent<Animator>().enabled = true;
        aN.enabled = true;
        Debug.Log("dead");
        JumpscareMonster();
        aN.Play("DeathAnimNight1", 0);
        this.GetComponent<Rigidbody>().isKinematic = true;
        timer.SetActive(false);
        gC.walkingEmpty.SetActive(false);
        rustle1 = 500;
        rustle2 = 500;
        rustle3 = 500;
        rustle4 = 500;
        rustle5 = 500;
        rustle6 = 500;
        rustle7 = 500;
        gC.flashlight.SetActive(false);
    }

    void JumpscareMonster()
    {
        monster.SetActive(true);
        //monster.gameObject.transform.position = monsterPos;
    }
}
