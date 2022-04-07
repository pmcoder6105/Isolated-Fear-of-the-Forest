using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Night2 : MonoBehaviour
{
    [SerializeField] GameObject MainScreen;
    [SerializeField] GameObject Appliances;
    [SerializeField] GameObject HomeSupplies;
    [SerializeField] GameObject Cleaning;
    [SerializeField] GameObject monster;
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
    [SerializeField] GameObject redEyeLeft1GameObject;
    bool hasAvoidedJumpscare;
    bool makeSureHasAvoidedJumpscareDoesntTurnFalse = false;
    AudioSource aS;
    [SerializeField] AudioClip redEyesDoomSfx;
    [SerializeField] GameObject leftEyeHallwayAvertedObject;
    Night1 n1;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Animator>().Play("PlayerEnteringRoomNight2", 0);
        bT = FindObjectOfType<Buttons>();
        redEye1Left = Random.Range(6 + 10,10+ 13);
        redEye2Right = Random.Range(14 + 10,10+ 25);
        redEye3Right = Random.Range(27 + 10,10+ 36);
        vent4 = Random.Range(37+10,10+ 48);
        redEye5Left = Random.Range(50+10,10+ 70);
        vent6 = Random.Range(71+10,10+ 83);
        vent7 = Random.Range(85+10,10+ 100);
        redEye8Right = Random.Range(110+10,10+ 130);
        redEye9Right = Random.Range(135+10, 10+145);
        vent10 = Random.Range(146 + 10,10+ 150);
        redEye10Left = Random.Range(151 + 10, 10+157);
        vent11 = Random.Range(158 + 10, 10+165);
        vent12 = Random.Range(166 + 10, 10 + 170);
        vent13 = Random.Range(171 + 10, 10 + 174);
        redEye14Right = Random.Range(175 + 10, 10 + 177);
        redEye15Left = Random.Range(177 + 10, 10 + 180);
        aS = GetComponent<AudioSource>();
        n1 = FindObjectOfType<Night1>();
    }

    // Update is called once per frame
    void Update()
    {
        ToggleBetweenLaptopAndExteriorView();
        if (Time.timeSinceLevelLoad >= redEye1Left && Time.timeSinceLevelLoad <= redEye1Left + 1)
        {
            redEyeLeft1GameObject.GetComponent<Animator>().Play("redEyesLeft1", 0);
            hasAvoidedJumpscare = false;
            AvoidJumpscare();
        }
    }

    void AvoidJumpscare()
    {
        if (hasAvoidedJumpscare == false)
        {
            aS.Stop();
            aS.PlayOneShot(redEyesDoomSfx);
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                hasAvoidedJumpscare = true;
                makeSureHasAvoidedJumpscareDoesntTurnFalse = true;
                leftEyeHallwayAvertedObject.GetComponent<Animator>().Play("LeftHallwayEyeAvertedDoor", 0);
                Invoke(nameof(TurnBoolTrueToPrepareForNextJumpscare), 5f);
                aS.volume = 0.01;
            }
        }
        Invoke(nameof(JumpscareAfterNotAvertingDanger), 3);
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
            n1.fadeOut.SetActive(true);
            n1.doomSFXEmpty.GetComponent<AudioSource>().PlayOneShot(n1.doomSFX);
            //once created lose screen, make sure to enable it here
        }
    }

    void TurnBoolTrueToPrepareForNextJumpscare()
    {
        hasAvoidedJumpscare = true;
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
