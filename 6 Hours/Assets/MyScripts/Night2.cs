using UnityEngine;

public class Night2 : MonoBehaviour
{
    [SerializeField] GameObject MainScreen;
    [SerializeField] GameObject Appliances;
    [SerializeField] GameObject HomeSupplies;
    [SerializeField] GameObject Cleaning;
    [SerializeField] GameObject fadeOut;
    [SerializeField] GameObject monster;
    [SerializeField] GameObject doomSFXEmpty;
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
    int redEye10Left;
    int vent11;
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
    [SerializeField] AudioClip doomSFX;
    [SerializeField] AudioClip hallwayDoorClose;
    [SerializeField] GameObject leftEyeHallwayAvertedObject;
    [SerializeField] GameObject rightEyeHallwayAvertedObject;
    [SerializeField] GameObject ventDarknessGameobject;
    [SerializeField] GameObject ventAvertedObject;
    [SerializeField] AudioClip crawlingInVent;
    bool canCloseDoor = true;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Animator>().Play("PlayerEnteringRoomNight2", 0);
        bT = FindObjectOfType<Buttons>();
        redEye1Left = Random.Range(5 + 10,9+ 10);
        redEye2Right = Random.Range(14 + 10,10+ 20);
        redEye3Right = Random.Range(24 + 10,10+ 32);
        vent4 = Random.Range(37+10,10+ 43);
        redEye5Left = Random.Range(47+10,10+ 57);
        vent6 = Random.Range(65+10,10+ 71);
        vent7 = Random.Range(75+10,10+ 81);
        redEye8Right = Random.Range(86+10,10+ 95);
        redEye9Right = Random.Range(101+10, 10+109);
        vent10 = Random.Range(115 + 10,10+ 123);
        redEye10Left = Random.Range(130 + 10, 10+140);
        vent11 = Random.Range(146 + 10, 10+152);
        vent12 = Random.Range(158 + 10, 10 + 164);
        vent13 = Random.Range(170 + 10, 10 + 174);
        redEye14Right = Random.Range(176 + 10, 10 + 180);
        aS = GetComponent<AudioSource>();
        leftEyeHallwayAvertedObject.GetComponent<Animator>().enabled = false;
        //rightEyeHallwayAvertedObject.GetComponent<Animator>().Stop = false;
        ventAvertedObject.GetComponent<Animator>().enabled = false;
        Debug.Log(redEye1Left);
        Debug.Log(redEye2Right);
        Debug.Log(redEye3Right);
        Debug.Log(vent4);
        Debug.Log(redEye5Left);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(canCloseDoor);
        ToggleBetweenLaptopAndExteriorView();
        if (Time.time >= redEye1Left && Time.time <= redEye1Left + 2)
        {
            redEyeLeftGameobject.SetActive(true);
            redEyeLeftGameobject.GetComponent<Animator>().enabled = true;
            redEyeLeftGameobject.GetComponent<Animator>().Play("RedEyesLightLeft", 0);
            hasAvoidedJumpscare = false;
            AvoidJumpscareLeft();
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 4.1f);
            aS.volume = 0.01f;
            aS.Stop();
            aS.PlayOneShot(redEyesDoomSfx);
        }

        if (Time.time >= redEye2Right && Time.time <= redEye2Right + 1)
        {
            redEyeRightGameobject.SetActive(true);
            if (redEyeRightGameobject.active == false)
            {
                redEyeRightGameobject.GetComponent<Animator>().enabled = true;
            }
            redEyeRightGameobject.GetComponent<Animator>().Play("RedEyesLightRight", 0);
            Invoke(nameof(StopRightEyeFromLooping), 4);
            hasAvoidedJumpscare = false;
            AvoidJumpscareRight();
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 4.1f);
            aS.volume = 0.01f;
            aS.Stop();
            aS.PlayOneShot(redEyesDoomSfx);
        }

        if (Time.time >= redEye3Right && Time.time <= redEye3Right + 1)
        {
            redEyeRightGameobject.SetActive(true);
            if (redEyeRightGameobject.active == false)
            {
                redEyeRightGameobject.GetComponent<Animator>().enabled = true;
            }
            redEyeRightGameobject.GetComponent<Animator>().Play("RedEyesLightRight", 0);
            Invoke(nameof(StopRightEyeFromLooping), 4);
            hasAvoidedJumpscare = false;
            AvoidJumpscareRight();
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 4.1f);
            aS.volume = 0.01f;
            aS.Stop();
            aS.PlayOneShot(redEyesDoomSfx);
        }

        if (Time.time >= vent4 && Time.time <= vent4 + 2)
        {
            if (!ventDarknessGameobject.GetComponent<AudioSource>().isPlaying && hasAvoidedJumpscare == false)
            {
                ventDarknessGameobject.GetComponent<AudioSource>().volume = 0.3f;
                ventDarknessGameobject.GetComponent<AudioSource>().PlayOneShot(crawlingInVent);
            }            
            else if (hasAvoidedJumpscare == true)
            {
                ventDarknessGameobject.GetComponent<AudioSource>().Stop();
            }
            hasAvoidedJumpscare = false;
            AvoidJumpscareVent();
            Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 4.1f);
        }
    }

    void StopRightEyeFromLooping()
    {
        if (redEyeRightGameobject.active == true)
        {
            redEyeRightGameobject.SetActive(false);
        }
    }

    void AvoidJumpscareLeft()
    {
        if (hasAvoidedJumpscare == false)
        {            
            Debug.Log("need to avoid jumpscare now");
            if (Input.GetKeyDown(KeyCode.LeftArrow) && Cursor.lockState == CursorLockMode.None && canCloseDoor == true)
            {
                canCloseDoor = false;
                Debug.Log("Has avoided jumpscare?");
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
        Invoke(nameof(JumpscareAfterNotAvertingDanger), 4);
    }

    void AvoidJumpscareRight()
    {
        if (hasAvoidedJumpscare == false)
        {
            Debug.Log("need to avoid jumpscare now");
            if (Input.GetKeyDown(KeyCode.RightArrow) && Cursor.lockState == CursorLockMode.None && canCloseDoor == true)
            {
                canCloseDoor = false;
                Debug.Log("Has avoided jumpscare?");
                hasAvoidedJumpscare = true;
                makeSureHasAvoidedJumpscareDoesntTurnFalse = true;
                //rightEyeHallwayAvertedObject.SetActive(true);
                rightEyeHallwayAvertedObject.GetComponent<Animator>().enabled = true;
                rightEyeHallwayAvertedObject.GetComponent<Animator>().Play("RightHallwayEyeAvertedDoor", 0, 0f);
                if (!rightEyeHallwayAvertedObject.GetComponent<AudioSource>().isPlaying)
                {
                    rightEyeHallwayAvertedObject.GetComponent<AudioSource>().PlayOneShot(hallwayDoorClose);
                }
                Invoke(nameof(RightHallwayAvertedDoor), 4f);
            }
        }
        Invoke(nameof(JumpscareAfterNotAvertingDanger), 4);
    }

    void AvoidJumpscareVent()
    {
        if (hasAvoidedJumpscare == false)
        {
            Debug.Log("need to avoid jumpscare now");
            if (Input.GetKeyDown(KeyCode.UpArrow) && Cursor.lockState == CursorLockMode.None && canCloseDoor == true)
            {
                canCloseDoor = false;
                Debug.Log("Has avoided vent jumpscare?");
                hasAvoidedJumpscare = true;
                makeSureHasAvoidedJumpscareDoesntTurnFalse = true;
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
        Invoke(nameof(JumpscareAfterNotAvertingDanger), 4);
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
            this.GetComponent<Rigidbody>().isKinematic = true;
            redEye1Left = 500;
            redEye2Right = 500;
            redEye3Right = 500;
            vent4 = 500;
            redEye5Left = 500;
            vent6 = 500;
            vent7 = 500;
            redEye8Right = 500;
            redEye9Right = 500;
            vent10 = 500;
            redEye10Left = 500;
            vent11 = 500;
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
        canCloseDoor = true;
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
            if (isLookingAtScreen == false && bT.canMoveFromScreen == true)
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
}
