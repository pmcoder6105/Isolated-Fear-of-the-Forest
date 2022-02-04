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
    [SerializeField] GameObject chainedFence1;
    [SerializeField] GameObject chainedFence2;
    bool hasPickedBox = false;
    bool ableToPlaceBox = false;

    // Start is called before the first frame update
    void Start()
    {
        
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
                Invoke(nameof(ReplaceBox), 0.5f);
                firstObjective.SetActive(false);
                secondObjective.SetActive(true);
                boxAnim.SetActive(false);
                Destroy(kitchenLockedCollider);
                Destroy(bedLockedCollider);
                kitchenDoor.GetComponent<BoxCollider>().enabled = true;
                bedroomDoor.GetComponent<BoxCollider>().enabled = true;
            }
        }
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
        Destroy(chainedFence1);
        Destroy(chainedFence2);
    }
}
