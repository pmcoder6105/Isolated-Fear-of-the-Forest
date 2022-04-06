using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Night2 : MonoBehaviour
{
    [SerializeField] GameObject MainScreen;
    bool isLookingAtScreen = false;
    [SerializeField] bool isTransitioningToScreen = false;
    [SerializeField] GameObject cam;


    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Animator>().Play("PlayerEnteringRoomNight2", 0);
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
                cam.transform.rotation = Quaternion.Euler(0, 0, 0);                             
                GetComponent<Animator>().Play("ZoomIntoComputerNight2");
                GetComponent<CapsuleCollider>().enabled = false;
                GetComponent<Rigidbody>().isKinematic = true;
                Invoke(nameof(TurnMainScreenActiveAfterZoomingIn), 1f);
            }
            if (isLookingAtScreen == false)
            {
                cam.transform.rotation = Quaternion.Euler(0, 0, 0);
                GetComponent<Animator>().Play("ZoomOutOfComputerNight2");
                GetComponent<CapsuleCollider>().enabled = true;
                GetComponent<Rigidbody>().isKinematic = false;
                MainScreen.SetActive(false);
            }
        }
    }

    private void TurnMainScreenActiveAfterZoomingIn()
    {
        if (GetComponent<Rigidbody>().isKinematic == true)
        {
            MainScreen.SetActive(true);
        }        
    }
}
