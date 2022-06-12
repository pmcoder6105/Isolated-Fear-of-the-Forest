using TMPro;
using UnityEngine;

public class Night1 : MonoBehaviour
{
    [SerializeField] bool aNOn = true;
    Animator aN;
    AudioSource aS;
    [SerializeField] GameObject monster;
    [SerializeField] GameObject night1Instructions;
    [SerializeField] public GameObject doomSFXEmpty;
    [SerializeField] public GameObject fadeOut;
    [SerializeField] GameObject fadeOutDeathObject;
    [SerializeField] GameObject bloodOverlay;
    [SerializeField] GameObject radio;
    [SerializeField] GameObject canvas;
    [SerializeField] AudioClip rustle;
    [SerializeField] AudioClip radioSFX;
    [SerializeField] public AudioClip doomSFX;
    [SerializeField] AudioClip loseSFX;
    [SerializeField] public AudioClip winSFX;
    [SerializeField] AudioClip alarmBeep;
    [SerializeField] GameObject timer;
    [SerializeField] GameObject rustleEmpty;
    [SerializeField] GameObject rustleEmpty2;
    [SerializeField] GameObject rustleEmpty3;
    [SerializeField] GameObject rustleEmpty4;
    [SerializeField] GameObject rustleEmpty5;
    [SerializeField] GameObject rustleEmpty6;
    [SerializeField] GameObject rustleEmpty7;
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject loseScreen;
    [SerializeField] GameObject guidanceText;
    [SerializeField] GameObject guidanceAudioEmpty;
    [SerializeField] GameObject winScreenCam;
    [SerializeField] AudioClip guidanceAudioClip;
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
    public bool freezeTime = false;
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
        rustle1 = Random.Range(30 + 30, 30 + 45);
        rustle2 = Random.Range(55 + 30, 30 + 70);
        rustle3 = Random.Range(80 + 30, 30 + 95);
        rustle4 = Random.Range(105 + 30, 30 + 120);
        rustle5 = Random.Range(130 + 30, 30 + 145);
        rustle6 = Random.Range(155 + 30, 30 + 170);
        rustle7 = Random.Range(170 + 30, 30 + 180);                        
        gC = FindObjectOfType<GameControl>();
    }   

    // Update is called once per frame
    void Update()
    {
        EnablePlayerMovementAfterCutscene();
        Invoke(nameof(RustleTest), 31f);
        RunTime();
        if (night1Instructions == null)
        {            
            if (!guidanceAudioEmpty.GetComponent<AudioSource>().isPlaying)
            {
                guidanceAudioEmpty.GetComponent<AudioSource>().PlayOneShot(guidanceAudioClip);
            }
            if (Time.timeSinceLevelLoad >= 29+31)
            {
                Debug.Log("Time to destroy guidance clip");
                Destroy(guidanceAudioEmpty);
            }
        }
        if (loseScreen.activeInHierarchy)
        {
            Cursor.lockState = CursorLockMode.None;
            aS.volume = 0.5f;
        }
        if (winScreen.activeInHierarchy)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Debug.Log("win screen should be active");
            aN.enabled = true;
            aN.Play("DeathAnimNight1", 0);
            aS.volume = 0.5f;
            //Destroy(this.gameObject);
            //winScreenCam.SetActive(true);
        }
        if (freezeTime == true)
        {
            Time.timeScale = 0;
        }
        if (night1Instructions == null)
        {
            Time.timeScale = 1;
        }
        if (Time.timeSinceLevelLoad >= 31 && Time.timeSinceLevelLoad <= 32)
        {
            freezeTime = true;
        } 
    }

    void RunTime()
    {
        timer.GetComponent<Timer>().enabled = true;
        //if (night1Instructions.activeInHierarchy && night1Instructions != null)
        //{
        //    freezeTime = true;
        //}
        if (shouldStartTimer == true && this.gameObject.GetComponent<CapsuleCollider>().enabled == true) 
        {
            timer.SetActive(true);
            float timeNeeded = Time.timeSinceLevelLoad - 30;
            timer.GetComponent<TMP_Text>().text = timeNeeded.ToString();
            //CHECK HERE IF FUTURE ME SEES A BUG IN JUMPSCARE TIMER WHILE PLAYTESTING 
            if (Time.timeSinceLevelLoad > 180+30)
            {
                if (!aS.isPlaying)
                {
                    timer.GetComponent<TMP_Text>().text = "2:00";
                    aS.Stop();
                    aS.PlayOneShot(alarmBeep);
                    Invoke(nameof(StopAudioWithEpsilon), 3);
                    Invoke(nameof(Jumpscare), 4f);
                }
                bloodOverlay.SetActive(true);
                Invoke(nameof(TurnFadeOutBackOffLose), 1f);
                Invoke(nameof(TurnOnLoseScreen), 1f);
                doomSFXEmpty.GetComponent<AudioSource>().PlayOneShot(doomSFX);
                this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            } 
        }        
    }

    void StopAudioWithEpsilon()
    {
        aS.Stop();
    }

    void RustleTest()
    {
        time += Time.timeSinceLevelLoad;
        if (Time.timeSinceLevelLoad >= rustle1 && Time.timeSinceLevelLoad <= rustle1 + 4)
        {
            if (guidanceText != null)
            {
                guidanceText.SetActive(true);
            }                
            hasAvoidedJumpscareRustle = false;
            Debug.Log("should rustle now");
            AvoidJumpscare();
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 5f);
            aS.volume = 0.05f;
            if (!rustleEmpty.GetComponent<AudioSource>().isPlaying && makeSureHasAvoidedDoesntTurnFalse == false)
            {
                if (!rustleEmpty.GetComponent<AudioSource>().isPlaying)
                {
                    rustleEmpty.GetComponent<AudioSource>().PlayOneShot(rustle);
                }
            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                rustleEmpty.GetComponent<AudioSource>().volume = 0;
            }
        }
        if (Time.timeSinceLevelLoad >= rustle2 && Time.timeSinceLevelLoad <= rustle2 + 4)
        {
            hasAvoidedJumpscareRustle = false;
            AvoidJumpscare();
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 5f);
            aS.volume = 0.05f;
            if (!rustleEmpty2.GetComponent<AudioSource>().isPlaying && makeSureHasAvoidedDoesntTurnFalse == false)
            {
                if (!rustleEmpty2.GetComponent<AudioSource>().isPlaying)
                {
                    rustleEmpty2.GetComponent<AudioSource>().PlayOneShot(rustle);
                }
            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                rustleEmpty2.GetComponent<AudioSource>().volume = 0;
            }
        }
        if (Time.timeSinceLevelLoad >= rustle3 && Time.timeSinceLevelLoad <= rustle3 + 4)
        {
            hasAvoidedJumpscareRustle = false;
            AvoidJumpscare();
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 5f);
            aS.volume = 0.05f;
            if (!rustleEmpty3.GetComponent<AudioSource>().isPlaying && makeSureHasAvoidedDoesntTurnFalse == false)
            {
                if (!rustleEmpty3.GetComponent<AudioSource>().isPlaying)
                {
                    rustleEmpty3.GetComponent<AudioSource>().PlayOneShot(rustle);
                }
            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                rustleEmpty3.GetComponent<AudioSource>().volume = 0;
            }
        }
        if (Time.timeSinceLevelLoad >= rustle4 && Time.timeSinceLevelLoad <= rustle4 + 4)
        {
            hasAvoidedJumpscareRustle = false;
            AvoidJumpscare();
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 5f);
            aS.volume = 0.05f;
            if (!rustleEmpty4.GetComponent<AudioSource>().isPlaying && makeSureHasAvoidedDoesntTurnFalse == false)
            {
                if (!rustleEmpty4.GetComponent<AudioSource>().isPlaying)
                {
                    rustleEmpty4.GetComponent<AudioSource>().PlayOneShot(rustle);
                }
            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                rustleEmpty3.GetComponent<AudioSource>().volume = 0;
            }
        }
        if (Time.timeSinceLevelLoad >= rustle5 && Time.timeSinceLevelLoad <= rustle5 + 4)
        {
            hasAvoidedJumpscareRustle = false;
            AvoidJumpscare();
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 5f);
            aS.volume = 0.05f;
            if (!rustleEmpty5.GetComponent<AudioSource>().isPlaying && makeSureHasAvoidedDoesntTurnFalse == false)
            {
                if (!rustleEmpty5.GetComponent<AudioSource>().isPlaying)
                {
                    rustleEmpty5.GetComponent<AudioSource>().PlayOneShot(rustle);
                }
            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                rustleEmpty4.GetComponent<AudioSource>().volume = 0;
            }
        }
        if (Time.timeSinceLevelLoad >= rustle6 && Time.timeSinceLevelLoad <= rustle6 + 4)
        {
            hasAvoidedJumpscareRustle = false;
            AvoidJumpscare();
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 5f);
            aS.volume = 0.05f;
            if (!rustleEmpty6.GetComponent<AudioSource>().isPlaying && makeSureHasAvoidedDoesntTurnFalse == false)
            {
                if (!rustleEmpty6.GetComponent<AudioSource>().isPlaying)
                {
                    rustleEmpty6.GetComponent<AudioSource>().PlayOneShot(rustle);
                }
            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                rustleEmpty6.GetComponent<AudioSource>().volume = 0;
            }
        }
        if (Time.timeSinceLevelLoad >= rustle7 && Time.timeSinceLevelLoad <= rustle7 + 4)
        {
            hasAvoidedJumpscareRustle = false;
            AvoidJumpscare();
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 5f);
            aS.volume = 0.05f;
            if (!rustleEmpty7.GetComponent<AudioSource>().isPlaying && makeSureHasAvoidedDoesntTurnFalse == false)
            {
                if (!rustleEmpty7.GetComponent<AudioSource>().isPlaying)
                {
                    rustleEmpty7.GetComponent<AudioSource>().PlayOneShot(rustle);
                }
            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                rustleEmpty7.GetComponent<AudioSource>().volume = 0;
            }
        }
    }

    void TurnBoolTrueToPrepareForNextJumpscare()
    {
        hasAvoidedJumpscareRustle = true;
        makeSureHasAvoidedDoesntTurnFalse = false;
    }

    void AvoidJumpscare()
    {
        if (makeSureHasAvoidedDoesntTurnFalse == false)
        {            
            Debug.Log("played rustle");
            if (Input.GetKeyDown(KeyCode.Mouse1) && makeSureHasAvoidedDoesntTurnFalse == false)
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
            if (makeSureHasAvoidedDoesntTurnFalse == true)
            {
                Invoke(nameof(TurnOffAudioSourcesAfterAvoidingJumpscare), 4.1f);
            }
            Invoke(nameof(TurnOffRustleAfterPlayedOnce), 1.2f);
        }
        Invoke(nameof(JumpscareAfterNotPlayingAudio), 4f);
    }

    void TurnOffAudioSourcesAfterAvoidingJumpscare()
    {
        //rustleEmpty.GetComponent<AudioSource>().enabled = false;
        radio.GetComponent<AudioSource>().enabled = false;
        Invoke(nameof(TurnOnAudiosourcesAfterAvoidedJumpscare), 1f);
    }
    void TurnOnAudiosourcesAfterAvoidedJumpscare()
    {
        //rustleEmpty.GetComponent<AudioSource>().enabled = true;
        radio.GetComponent<AudioSource>().enabled = true;
    }

    void JumpscareAfterNotPlayingAudio()
    {
        if (guidanceText != null)
        {
            Destroy(guidanceText);
        }
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

    void TurnOffRustleAfterPlayedOnce()
    {
        rustleEmpty.GetComponent<AudioSource>().enabled = false;
    }

    void EnablePlayerMovementAfterCutscene()
    {
        if (aNOn == false)
        {
            aN.enabled = false;         
        }
        else if (aNOn == true)
        {
            aN.enabled = true;
        }
        if (night1Instructions != null)
        {
            Invoke(nameof(PlayerHasSeenInstructions), 5f);
            NightOneInstructionsOff();
            shouldStartTimer = true;
            if (!aS.isPlaying && night1Instructions.active == true)
            {
                aS.Stop();
                Invoke(nameof(PlayDoomSFX), 0.1f);
                Invoke(nameof(StopMusic), 7);
            }
            if (Input.GetKeyDown(KeyCode.Mouse1) && night1Instructions != null)
            {
                Destroy(night1Instructions);
                aN.enabled = false;
                freezeTime = false;
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
        //canvas.SetActive(false);
        shouldStartTimer = true;
    }

    void PlayDoomSFX()
    {
        if (!doomSFXEmpty.GetComponent<AudioSource>().isPlaying)
        {
            doomSFXEmpty.GetComponent<AudioSource>().PlayOneShot(doomSFX);
        }        
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
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            this.gameObject.GetComponent<GameControl>().enabled = false;
            this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            Destroy(monster);
            gC.walkingEmpty.SetActive(false);
            fadeOutDeathObject.SetActive(true);
            rustle1 = 500;
            rustle2 = 500;
            rustle3 = 500;
            rustle4 = 500;
            rustle5 = 500;
            rustle6 = 500;
            rustle7 = 500;
            Invoke(nameof(TurnFadeOutBackOffWin), 1f);
            timer.SetActive(false);
            doomSFXEmpty.GetComponent<AudioSource>().PlayOneShot(doomSFX);
        }
    }

    private void TurnFadeOutBackOffWin()
    {
        fadeOutDeathObject.SetActive(false);
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
        fadeOutDeathObject.SetActive(true);
        Invoke(nameof(TurnOffFadeOutDeathAfterEnabling), 1f);
        if (!aS.isPlaying)
        {
            aS.PlayOneShot(loseSFX);
        }
    }

    void JumpscareMonster()
    {
        monster.SetActive(true);
        //monster.gameObject.transform.position = monsterPos;
    }
    void TurnOffFadeOutDeathAfterEnabling()
    {
        Destroy(fadeOutDeathObject);
        loseScreen.SetActive(true);
    }
}
