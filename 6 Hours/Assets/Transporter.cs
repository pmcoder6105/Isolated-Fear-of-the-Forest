using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transporter : MonoBehaviour
{
    [SerializeField] GameObject LRLight;
    [SerializeField] GameObject LRLightGoingIntoRoom;
    [SerializeField] GameObject KRLight;
    [SerializeField] GameObject KRLightGoingIntoRoom;
    [SerializeField] GameObject BRLight;
    [SerializeField] GameObject BRLightGoingIntoRoom;
    [SerializeField] GameObject HWLight;
    [SerializeField] GameObject HWLightGoingIntoRoom;

    void Start()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision");
        if (other.gameObject.tag == "KitchenDoor")
        {
            Debug.Log("Went Into Kitchen");
            Invoke(nameof(GoIntoKitchen), 2);
            LRLightGoingIntoRoom.SetActive(true);
            LRLight.SetActive(false);
            Invoke(nameof(TurnLightBackNormal), 2);
        }

        if (other.gameObject.tag == "KitchenLivingRoomDoor")
        {
            Debug.Log("Went into Living Room");
            Invoke(nameof(GoIntoLivingRoomFromKitchen), 2);
            KRLightGoingIntoRoom.SetActive(true);
            KRLight.SetActive(false);
            Invoke(nameof(TurnKRLightBackNormal), 2);
        }
        if (other.gameObject.tag == "HallWayDoor")
        {
            Debug.Log("Went into hallway");
            Invoke(nameof(GoIntoHallwayFromLivingRoom), 2);
            LRLightGoingIntoRoom.SetActive(true);
            LRLight.SetActive(false);
            Invoke(nameof(TurnLightBackNormal), 2);
        }
        if (other.gameObject.tag == "HallWayLivingRoomDoor")
        {
            Debug.Log("Went into Living ROom");
            Invoke(nameof(GoIntoLivingRoomFromHallway), 2);
            HWLightGoingIntoRoom.SetActive(true);
            HWLight.SetActive(false);
            Invoke(nameof(TurnHWlightBackNormal), 2);
        }
        if (other.gameObject.tag == "BackInsideDoor")
        {
            Debug.Log("Went Inside");
            transform.position = new Vector3(-0.348f, -1.473f, 2.35f);
        }
        if (other.gameObject.tag == "GoOutsideDoor")
        {
            Debug.Log("Went outside");
            Invoke(nameof(GoOutside), 2);
            LRLightGoingIntoRoom.SetActive(true);
            LRLight.SetActive(false);
            Invoke(nameof(TurnLightBackNormal), 2);
        }
        if (other.gameObject.tag == "BedRoomDoor")
        {
            Debug.Log("Went into Bedroom");
            Invoke(nameof(GoIntoBedRoomFromHallway), 2);
            HWLightGoingIntoRoom.SetActive(true);
            HWLight.SetActive(false);
            Invoke(nameof(TurnHWlightBackNormal), 2);
        }
        if (other.gameObject.tag == "BedHallWayDoor")
        {
            Debug.Log("Went into hallway from bedroom");
            Invoke(nameof(GoIntoHallwayFromBedroom), 2);
            BRLightGoingIntoRoom.SetActive(true);
            BRLight.SetActive(false);
            Invoke(nameof(TurnBRLightBackNormal), 2);
        }
    }

    private void GoIntoHallwayFromBedroom()
    {
        transform.position = new Vector3(2.668f, -1.994775f, 27.5f);
    }

    private void TurnHWlightBackNormal()
    {
        HWLight.SetActive(true);
    }

    private void GoIntoBedRoomFromHallway()
    {
        transform.position = new Vector3(2.668f, -1.994775f, 31.042f);
    }

    private void GoOutside()
    {
        transform.position = new Vector3(-0.12f, -1.61f, -0.71f);
    }

    private void GoIntoLivingRoomFromHallway()
    {
        transform.position = new Vector3(3.119f, -1.769f, 16.702f);
    }

    private void TurnBRLightBackNormal()
    {
        BRLight.SetActive(true);
    }

    private void GoIntoHallwayFromLivingRoom()
    {
        transform.position = new Vector3(2.718f, -1.769f, 20.08f);
    }

    private void TurnKRLightBackNormal()
    {
        KRLight.SetActive(true);
    }

    private void GoIntoLivingRoomFromKitchen()
    {
        transform.position = new Vector3(-5.453f, -1.595f, 9.618f);
    }

    private void TurnLightBackNormal()
    {
        LRLight.SetActive(true);
    }

    private void GoIntoKitchen()
    {
        transform.position = new Vector3(-10.14f, -1.595f, 9.618f);
    }
}
