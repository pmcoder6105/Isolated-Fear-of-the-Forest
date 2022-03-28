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
    [SerializeField] GameObject radio;
    [SerializeField] GameObject canvas;
    [SerializeField] AudioClip rustle;
    [SerializeField] AudioClip radioSFX;
    [SerializeField] AudioClip doomSFX;
    [SerializeField] AudioClip alarmBeep;
    [SerializeField] GameObject timer;
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
    [SerializeField] bool shouldSkipIntro = false;

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
        Debug.Log(rustle1);
        Debug.Log(rustle2);
        Debug.Log(rustle3);
        Debug.Log(rustle4);
        Debug.Log(rustle5);
        Debug.Log(rustle6);
        Debug.Log(rustle7);
        DebugKeys();
    }

    void DebugKeys()
    {
        if (shouldSkipIntro == true)
        {
            aN.ForceStateNormalizedTime(1);
            audioTrackingBeginningTimeline.SetActive(false);
            fadeOut.GetComponent<Animator>().ForceStateNormalizedTime(1);
            car.SetActive(false);
            //timer.GetComponent<TMP_Text>().text = "0";
            timer.GetComponent<TMP_Text>().text = Time.time.ToString();
            rustle1 = Random.Range(10, 16);
            rustle2 = Random.Range(22, 51);
            rustle3 = Random.Range(60, 78);
            rustle4 = Random.Range(85, 94);
            rustle5 = Random.Range(96, 106);
            rustle6 = Random.Range(110, 115);
            rustle7 = Random.Range(116, 120);
            Debug.Log(Time.timeSinceLevelLoad);
        }
    }   

    // Update is called once per frame
    void Update()
    {
        EnablePlayerMovementAfterCutscene();
        RustleTest();
        RunTime();
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
            }                       
        }
        if (Time.time > 144 && Time.time < 149)
        {
            if (!aS.isPlaying)
            {
                timer.GetComponent<TMP_Text>().text = "2:00";
                aS.Stop();
                aS.PlayOneShot(alarmBeep);
                //Invoke(nameof(StopAudioWithEpsilon), Mathf.Epsilon);
                Invoke(nameof(Jumpscare), 2f);
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
        }
        if (time >= rustle2 && time <= rustle2 + 1)
        {
            hasAvoidedJumpscareRustle = false;
            AvoidJumpscare();
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 5f);
        }
        if (time >= rustle3 && time <= rustle3 + 1)
        {
            hasAvoidedJumpscareRustle = false;
            AvoidJumpscare();
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 5f);
        }
        if (time >= rustle4 && time <= rustle4 + 1)
        {
            hasAvoidedJumpscareRustle = false;
            AvoidJumpscare();
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 5f);
        }
        if (time >= rustle5 && time <= rustle5 + 1)
        {
            hasAvoidedJumpscareRustle = false;
            AvoidJumpscare();
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 5f);
        }
        if (time >= rustle6 && time <= rustle6 + 1)
        {
            hasAvoidedJumpscareRustle = false;
            AvoidJumpscare();
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 5f);
        }
        if (time >= rustle7 && time <= rustle7 + 1)
        {
            hasAvoidedJumpscareRustle = false;
            AvoidJumpscare();
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 5f);
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
            Time.timeScale = 1f;
            Invoke(nameof(PlayerHasSeenInstructions), 5f);
            NightOneInstructionsOff();
            shouldStartTimer = true;
            if (!aS.isPlaying)
            {
                aS.Stop();
                Invoke(nameof(PlayDoomSFX), 0.1f);
                Invoke(nameof(StopMusic), 5);
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
        Time.timeScale = 1;
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
    }

    void CheckIfOnTrail(Collision other)
    {
        if (other.gameObject.tag == "Trail")
        {
            //isOnTrail = true;
        }
        else if (other.gameObject.tag != "Trail")
        {
            //isOnTrail = false;            
            Jumpscare();
        }
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
        fadeOut.GetComponent<Animator>().Play("DeathFadeOut", 0);
    }

    void JumpscareMonster()
    {
        monster.SetActive(true);
        //monster.gameObject.transform.position = monsterPos;
    }
}
