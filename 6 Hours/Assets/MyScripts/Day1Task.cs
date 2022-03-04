using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day1Task : MonoBehaviour
{
    [SerializeField] GameObject boxAnim;
    [SerializeField] GameObject boxToPlaceInside;
    [SerializeField] GameObject placedBox;
    [SerializeField] GameObject firstObjective;
    [SerializeField] GameObject secondObjective;
    [SerializeField] GameObject thirdObjective;
    [SerializeField] GameObject fourthObjective;
    [SerializeField] GameObject kitchenDoor;
    [SerializeField] GameObject bedroomDoor;
    [SerializeField] GameObject roomLockedText;
    [SerializeField] GameObject kitchenLockedCollider;
    [SerializeField] GameObject bedLockedCollider;
    [SerializeField] GameObject chainedFence1Anim;
    [SerializeField] GameObject chainedFence2Anim;
    [SerializeField] GameObject jumpScareCollider;
    [SerializeField] GameObject monster;
    [SerializeField] AudioClip placeBoxSFX;
    AudioSource aS;
    bool hasPickedBox = false;
    bool ableToPlaceBox = false;
    bool hasSeenBedroom = false;

    // Start is called before the first frame update
    void Start()
    {
        aS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ableToPlaceBox);
        if (ableToPlaceBox == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("Box?");
                boxToPlaceInside.SetActive(true);
                if (ableToPlaceBox == true)
                {
                    if (!aS.isPlaying)
                    {
                        aS.PlayOneShot(placeBoxSFX);
                    }
                }
                Invoke(nameof(ReplaceBox), 0.1f);
                firstObjective.SetActive(false);
                secondObjective.SetActive(true);
                boxAnim.SetActive(false);
                Destroy(kitchenLockedCollider);
                Destroy(bedLockedCollider);
                kitchenDoor.GetComponent<BoxCollider>().enabled = true;
                bedroomDoor.GetComponent<BoxCollider>().enabled = true;
            }
        }
        if (ableToPlaceBox == true)
        {
            Invoke(nameof(TurnOffBoxSFX), 1f);
        }
    }

    private void TurnOffBoxSFX()
    {
        ableToPlaceBox = false;
    }

    void CantEnterRoom()
    {
        roomLockedText.SetActive(false);
    }

    void ReplaceBox()
    {
        placedBox.transform.position = boxToPlaceInside.transform.position;
        placedBox.transform.rotation = boxToPlaceInside.transform.rotation;
        placedBox.SetActive(true);
        Destroy(boxToPlaceInside);
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Box")
        {
            Debug.Log("Picked Up Box");
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            boxAnim.SetActive(true);
            hasPickedBox = true;
        }
        if (hasPickedBox == true)
        {
            if (other.gameObject.tag == "Floor")
            {
                Debug.Log("touched floor");
                ableToPlaceBox = true;
            }
            if (other.gameObject.tag != "Floor")
            {
                ableToPlaceBox = false;
            }
        }
        if (ableToPlaceBox == false && other.gameObject.tag == "KitchenLocked" || other.gameObject.tag == "BedLocked")
        {
            roomLockedText.SetActive(true);
            Invoke(nameof(CantEnterRoom), 2);
        }
        if (other.gameObject.tag == "BedRoomDoor")
        {
            Invoke(nameof(WhatIsThisPlace), 2);
            Invoke(nameof(GetAway), 6);
        }
        if (hasSeenBedroom == true && other.gameObject.tag == "Ground")
        {
            chainedFence1Anim.SetActive(true);
            chainedFence2Anim.SetActive(true);
            jumpScareCollider.SetActive(true);
        }
        if (other.gameObject.tag == "JumpScare")
        {
            Invoke(nameof(TurnOnMonster), 0);
        }
    }

    private void TurnOnMonster()
    {
        monster.SetActive(true);
    }

    private void WhatIsThisPlace()
    {
        secondObjective.SetActive(false);
        thirdObjective.SetActive(true);
    }

    void GetAway()
    {
        thirdObjective.SetActive(false);
        fourthObjective.SetActive(true);
        hasSeenBedroom = true;
    }
}
