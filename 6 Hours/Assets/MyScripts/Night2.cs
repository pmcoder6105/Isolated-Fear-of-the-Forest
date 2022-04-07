using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Night2 : MonoBehaviour
{
    [SerializeField] GameObject MainScreen;
    [SerializeField] GameObject Appliances;
    [SerializeField] GameObject HomeSupplies;
    [SerializeField] GameObject Cleaning;
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

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Animator>().Play("PlayerEnteringRoomNight2", 0);
        bT = FindObjectOfType<Buttons>();
        redEye1Left = Random.Range(6, 13);
        redEye2Right = Random.Range(14, 25);
        redEye3Right = Random.Range(27, 36);
        vent4 = Random.Range(37, 48);
        redEye5Left = Random.Range(50, 70);
        vent6 = Random.Range(71, 83);
        vent7 = Random.Range(85, 100);
        redEye8Right = Random.Range(110, 130);
        redEye9Right = Random.Range(135, 145);
        vent10 = Random.Range(146, 150);
        redEye10Left = Random.Range(151, 157);
        vent11 = Random.Range(158, 165);
        vent12 = Random.Range(166, 170);
        vent13 = Random.Range(171, 174);
        redEye14Right = Random.Range(175, 177);
        redEye15Left = Random.Range(177, 180);
    }

    // Update is called once per frame
    void Update()
    {
        ToggleBetweenLaptopAndExteriorView();
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
