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

    void Start()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("sd");
        if (other.gameObject.tag == "KitchenDoor")
        {
            Debug.Log("Joe mama");
            Invoke(nameof(GoIntoKitchen), 2);
            LRLightGoingIntoRoom.SetActive(true);
            LRLight.SetActive(false);
            Invoke(nameof(TurnLightBackNormal), 2);
        }

        if (other.gameObject.tag == "KitchenLivingRoomDoor")
        {
            Debug.Log("Joe mama");
            Invoke(nameof(GoIntoLivingRoomFromKitchen), 2);
            KRLightGoingIntoRoom.SetActive(true);
            KRLight.SetActive(false);
            Invoke(nameof(TurnKRLightBackNormal), 2);
        }
        if (other.gameObject.tag == "BedRoomDoor")
        {
            Debug.Log("Joe mama's mama");
            Invoke(nameof(GoIntoBedRoomFromLivingRoom), 2);
            LRLightGoingIntoRoom.SetActive(true);
            LRLight.SetActive(false);
            Invoke(nameof(TurnLightBackNormal), 2);
        }
        if (other.gameObject.tag == "BedLivingRoomDoor")
        {
            Debug.Log("Joe mama's mama's mama");
            Invoke(nameof(GoIntoLivingRoomFromBedRoom), 2);
            BRLightGoingIntoRoom.SetActive(true);
            BRLight.SetActive(false);
            Invoke(nameof(TurnBRLightBackNormal), 2);
        }
        if (other.gameObject.tag == "BackInsideDoor")
        {
            Debug.Log("Joe mama's mama's mama");
            transform.position = new Vector3(-0.348f, -1.473f, 2.35f);
        }
        if (other.gameObject.tag == "GoOutsideDoor")
        {
            Debug.Log("Joe mama's mama's mama");
            transform.position = new Vector3(-0.12f, -1.61f, -0.4f);
        }
    }

    private void GoIntoLivingRoomFromBedRoom()
    {
        transform.position = new Vector3(3.119f, -1.769f, 16.702f);
    }

    private void TurnBRLightBackNormal()
    {
        BRLight.SetActive(true);
    }

    private void GoIntoBedRoomFromLivingRoom()
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
