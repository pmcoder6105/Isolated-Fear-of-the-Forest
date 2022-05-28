using UnityEngine.AI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Night3 : MonoBehaviour
{
    [SerializeField] public NavMeshAgent monsterAI;
    [SerializeField] GameObject timeline;
    [SerializeField] public GameObject prefabedMonster;
    [SerializeField] GameObject carPortal;
    [SerializeField] GameObject carPortalTimeline;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject doomSFXObject;
    [SerializeField] GameObject doomSFXOpeningObject;
    [SerializeField] GameObject doomSFXWinObject;
    [SerializeField] GameObject fadeOutObject;
    [SerializeField] GameObject fadeOutWinObject;
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject loseScreen;
    [SerializeField] GameObject instructions;
    [SerializeField] public GameObject capsule1Button;
    [SerializeField] public GameObject capsule2Button;
    [SerializeField] public GameObject capsule3Button;
    [SerializeField] GameObject cam;
    [SerializeField] public Transform player;
    public bool isLookingAtCapsule1 = false;
    public bool isLookingAtCapsule2 = false;
    public bool isLookingAtCapsule3 = false;
    public bool canZoomIn = true;
    bool inRangeCapsule1 = false;
    bool inRangeCapsule2 = false;
    bool inRangeCapsule3 = false;
    public bool shouldSkipIntro = false;
    [SerializeField] AudioClip doomSFX;
    Vector3 posOfPlayerWhenCompleting3Capsules;
    Quaternion rotOfPlayerWhenCompleting3Capsules;

    Animator aN;
    Buttons bT;


    // Start is called before the first frame update
    void Start()
    {
        aN = GetComponent<Animator>();
        bT = FindObjectOfType<Buttons>();
        Debug.Log(Time.timeSinceLevelLoad);
        capsule1Button.SetActive(false);        
    }

    // Update is called once per frame
    void Update()
    {
        monsterAI.SetDestination(player.position);
        monsterAI.GetComponent<Animator>().Play("Walk", 0);

        if (bT.monsterSpeed == 1)
        {
            monsterAI.speed = 4;
        }
        if (bT.monsterSpeed == 2)
        {
            monsterAI.speed = 4.5f;
        }
        if (bT.monsterSpeed == 3)
        {
            monsterAI.speed = 5.5f;
        }
        if (Input.GetKeyDown(KeyCode.Space) && inRangeCapsule1 == true && bT.capsule1 != null)
        {           
            aN.enabled = true;
            cam.transform.localRotation = Quaternion.Euler(0, 0, 0);
            GetComponent<Rigidbody>().isKinematic = true;            
            if (canZoomIn == true)
            {
                aN.Play("ZoomIntoCapsule1", 0);
            }
            canvas.GetComponent<Animator>().Play("EnableCapsule1Button", 0);            
            isLookingAtCapsule1 = true;
            Invoke(nameof(TurnOnButton1), 1f);
            Cursor.lockState = CursorLockMode.None;
            //capsule1Button.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && inRangeCapsule2 == true && bT.capsule2 != null)
        {
            aN.enabled = true;
            cam.transform.localRotation = Quaternion.Euler(0, 0, 0);
            GetComponent<Rigidbody>().isKinematic = true;
            if (canZoomIn == true)
            {
                aN.Play("ZoomIntoCapsule2", 0);
            }
            canvas.GetComponent<Animator>().Play("EnableCapsule2Button", 0);
            isLookingAtCapsule2 = true;
            Invoke(nameof(TurnOnButton2), 1f);
            Cursor.lockState = CursorLockMode.None;
            //capsule1Button.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Space) && inRangeCapsule3 == true && bT.capsule3 != null)
        {
            aN.enabled = true;
            cam.transform.localRotation = Quaternion.Euler(0, 0, 0);
            GetComponent<Rigidbody>().isKinematic = true;
            if (canZoomIn == true)
            {
                aN.Play("ZoomIntoCapsule3", 0);
            }
            canvas.GetComponent<Animator>().Play("EnableCapsule3Button", 0);
            isLookingAtCapsule3 = true;
            Invoke(nameof(TurnOnButton3), 1f);
            Cursor.lockState = CursorLockMode.None;
            //capsule1Button.SetActive(true);
        }

        if (Time.timeSinceLevelLoad >= 11 && shouldSkipIntro == false && instructions != null)
        {
            timeline.SetActive(false);
            instructions.SetActive(true);
        }
        else if (shouldSkipIntro == true && instructions != null)
        {
            timeline.SetActive(false);
            instructions.SetActive(true);
        }
        if (timeline.active == false && Time.timeSinceLevelLoad <= 12 && shouldSkipIntro == false)
        {
            aN.enabled = false;
        }
        if (shouldSkipIntro == true && Time.timeSinceLevelLoad >= 0.1f)
        {
            aN.enabled = false;
        }

        if (bT.capsule1 == null && bT.capsule2 == null && bT.capsule3 == null)
        {
            carPortal.SetActive(true);
            carPortalTimeline.SetActive(true);
            Invoke(nameof(TurnCameraPositionBack), 16f);
        }
        if (instructions.active == true)
        {
            if (!doomSFXOpeningObject.GetComponent<AudioSource>().isPlaying)
            {
                doomSFXOpeningObject.GetComponent<AudioSource>().PlayOneShot(doomSFX);
            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Destroy(instructions);
            }
        }
    }

    void TurnOnButton1()
    {
        Debug.Log("time to click button");
        if (capsule1Button.active == false)
        {
            capsule1Button.SetActive(true);
        }        
    }

    void TurnCameraPositionBack()
    {
        cam.SetActive(true);
        Destroy(carPortalTimeline);
    }
    void TurnOnButton2()
    {
        Debug.Log("time to click button");
        if (capsule2Button.active == false)
        {
            capsule2Button.SetActive(true);
        }
    }

    void TurnOnButton3()
    {
        Debug.Log("time to click button");
        if (capsule3Button.active == false)
        {
            capsule3Button.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Capsule1Field")
        {
            inRangeCapsule1 = true;
        }
        else if (other.gameObject.tag != "Capsule1Field")
        {
            inRangeCapsule1 = false;
        }
        if (other.gameObject.tag == "Capsule2Field")
        {
            inRangeCapsule2 = true;
        }
        else if (other.gameObject.tag != "Capsule2Field")
        {
            inRangeCapsule2 = false;
        }
        if (other.gameObject.tag == "Capsule3Field")
        {
            inRangeCapsule3 = true;
        }
        else if (other.gameObject.tag != "Capsule3Field")
        {
            inRangeCapsule3 = false;
        }
        if (other.gameObject.tag == "Car")
        {
            Debug.Log("won");
            fadeOutWinObject.SetActive(true);
            GetComponent<Rigidbody>().isKinematic = true;
            doomSFXWinObject.GetComponent<AudioSource>().PlayOneShot(doomSFX);
            GetComponent<CapsuleCollider>().enabled = false;            
            Invoke(nameof(TurnOnWinScreen), 2f);
        }
    }
    void TurnOnWinScreen()
    {
        winScreen.SetActive(true);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Monster")
        {
            prefabedMonster.SetActive(true);
            doomSFXObject.GetComponent<AudioSource>().PlayOneShot(doomSFX);
            fadeOutObject.SetActive(true);
            monsterAI.gameObject.SetActive(false);
            Destroy(monsterAI);
            Debug.Log("your dead");
            Invoke(nameof(TurnOnLoseScreen), 2f);
        }
    }
    void TurnOnLoseScreen()
    {
        loseScreen.SetActive(true);
    }
}
