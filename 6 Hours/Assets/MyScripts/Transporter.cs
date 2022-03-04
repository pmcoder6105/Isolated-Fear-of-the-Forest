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
    AudioSource aS;
    [SerializeField] AudioClip doorOpening1;
    [SerializeField] AudioClip doorOpening2;
    [SerializeField] GameObject walkingEmpty;
    bool isTransporting = false;
    int doorSound;
    GameObject collider;

    void Start()
    {
        aS = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.D))
        {
            if (!walkingEmpty.GetComponent<AudioSource>().isPlaying) 
            {
                walkingEmpty.GetComponent<AudioSource>().Play();
            }            
        }
        if (Input.GetKeyUp(KeyCode.W) ||
            Input.GetKeyUp(KeyCode.S) ||
            Input.GetKeyUp(KeyCode.A) ||
            Input.GetKeyUp(KeyCode.D))
        {
            if (walkingEmpty.GetComponent<AudioSource>().isPlaying)
            {
                walkingEmpty.GetComponent<AudioSource>().Pause();
            }
        }
    }
    void OnCollisionEnter(Collision other)
    {
        GoToKitchenFromLivingRoom(other);
        GoToLivingRoomFromKitchen(other);
        GoToHallwayFromLivingRoom(other);
        GoToLivingRoomFromHallway(other);
        GoToLivingRoomFromOutside(other);
        GoOutsideFromLivingRoom(other);
        GoToBedRoomFromHallway(other);
        GoToHallwayFromBedroom(other);
    }

    void GoToHallwayFromBedroom(Collision other)
    {
        if (other.gameObject.tag == "BedHallWayDoor")
        {
            FixDoubleDoorBug(other);
            doorSound = Random.Range(1, 3);
            if (doorSound == 1)
            {
                aS.PlayOneShot(doorOpening1);
            }
            if (doorSound == 2)
            {
                aS.PlayOneShot(doorOpening2);
            }
            Debug.Log("Went into hallway from bedroom");
            Invoke(nameof(GoIntoHallwayFromBedroom), 2);
            BRLightGoingIntoRoom.SetActive(true);
            BRLight.SetActive(false);
            Invoke(nameof(TurnBRLightBackNormal), 2);
        }
    }

    void FixDoubleDoorBug(Collision other)
    {
        other.gameObject.GetComponent<BoxCollider>().enabled = false;
        collider = other.gameObject;
        Invoke(nameof(TurnDoorColliderBackOn), 2f);              
    }

    void TurnDoorColliderBackOn(Collision other)
    {
        collider.GetComponent<BoxCollider>().enabled = true;
    }

    void GoToBedRoomFromHallway(Collision other)
    {
        if (other.gameObject.tag == "BedRoomDoor")
        {
            FixDoubleDoorBug(other);
            doorSound = Random.Range(1, 3);
            if (doorSound == 1)
            {
                aS.PlayOneShot(doorOpening1);
            }
            if (doorSound == 2)
            {
                aS.PlayOneShot(doorOpening2);
            }
            Debug.Log("Went into Bedroom");
            Invoke(nameof(GoIntoBedRoomFromHallway), 2);
            HWLightGoingIntoRoom.SetActive(true);
            HWLight.SetActive(false);
            Invoke(nameof(TurnHWlightBackNormal), 2);
        }
    }

    void GoOutsideFromLivingRoom(Collision other)
    {
        if (other.gameObject.tag == "GoOutsideDoor")
        {
            FixDoubleDoorBug(other);
            doorSound = Random.Range(1, 3);
            if (doorSound == 1)
            {
                aS.PlayOneShot(doorOpening1);
            }
            if (doorSound == 2)
            {
                aS.PlayOneShot(doorOpening2);
            }
            Debug.Log("Went outside");
            Invoke(nameof(GoOutside), 2);
            LRLightGoingIntoRoom.SetActive(true);
            LRLight.SetActive(false);
            Invoke(nameof(TurnLightBackNormal), 2);
        }
    }

    void GoToLivingRoomFromOutside(Collision other)
    {
        if (other.gameObject.tag == "BackInsideDoor")
        {
            FixDoubleDoorBug(other);
            doorSound = Random.Range(1, 3);
            if (doorSound == 1)
            {
                aS.PlayOneShot(doorOpening1);
            }
            if (doorSound == 2)
            {
                aS.PlayOneShot(doorOpening2);
            }
            Debug.Log("Went Inside");
            transform.position = new Vector3(-0.348f, -1.473f, 2.35f);
        }
    }

    void GoToLivingRoomFromHallway(Collision other)
    {
        if (other.gameObject.tag == "HallWayLivingRoomDoor")
        {
            FixDoubleDoorBug(other);
            doorSound = Random.Range(1, 3);
            if (doorSound == 1)
            {
                aS.PlayOneShot(doorOpening1);
            }
            if (doorSound == 2)
            {
                aS.PlayOneShot(doorOpening2);
            }
            Debug.Log("Went into Living ROom");
            Invoke(nameof(GoIntoLivingRoomFromHallway), 2);
            HWLightGoingIntoRoom.SetActive(true);
            HWLight.SetActive(false);
            Invoke(nameof(TurnHWlightBackNormal), 2);
        }
    }

    void GoToHallwayFromLivingRoom(Collision other)
    {
        if (other.gameObject.tag == "HallWayDoor")
        {
            FixDoubleDoorBug(other);
            doorSound = Random.Range(1, 3);
            if (doorSound == 1)
            {
                aS.PlayOneShot(doorOpening1);
            }
            if (doorSound == 2)
            {
                aS.PlayOneShot(doorOpening2);
            }
            Debug.Log("Went into hallway");
            Invoke(nameof(GoIntoHallwayFromLivingRoom), 2);
            LRLightGoingIntoRoom.SetActive(true);
            LRLight.SetActive(false);
            Invoke(nameof(TurnLightBackNormal), 2);
        }
    }

    void GoToLivingRoomFromKitchen(Collision other)
    {
        if (other.gameObject.tag == "KitchenLivingRoomDoor")
        {
            FixDoubleDoorBug(other);
            doorSound = Random.Range(1, 3);
            if (doorSound == 1)
            {
                aS.PlayOneShot(doorOpening1);
            }
            if (doorSound == 2)
            {
                aS.PlayOneShot(doorOpening2);
            }
            Debug.Log("Went into Living Room");
            Invoke(nameof(GoIntoLivingRoomFromKitchen), 2);
            KRLightGoingIntoRoom.SetActive(true);
            KRLight.SetActive(false);
            Invoke(nameof(TurnKRLightBackNormal), 2);
        }
    }

    void GoToKitchenFromLivingRoom(Collision other)
    {
        if (other.gameObject.tag == "KitchenDoor")
        {
            FixDoubleDoorBug(other);
            doorSound = Random.Range(1, 3);
            if (doorSound == 1)
            {
                aS.PlayOneShot(doorOpening1);
            }
            if (doorSound == 2)
            {
                aS.PlayOneShot(doorOpening2);
            }
            Debug.Log("Went Into Kitchen");
            Invoke(nameof(GoIntoKitchen), 2);
            LRLightGoingIntoRoom.SetActive(true);
            LRLight.SetActive(false);
            Invoke(nameof(TurnLightBackNormal), 2);
        }
    }

    void GoIntoHallwayFromBedroom()
    {
        transform.position = new Vector3(2.668f, -1.994775f, 27.5f);
    }

    void TurnHWlightBackNormal()
    {
        HWLight.SetActive(true);
    }

    void GoIntoBedRoomFromHallway()
    {
        transform.position = new Vector3(2.668f, -1.994775f, 31.042f);
    }

    void GoOutside()
    {
        transform.position = new Vector3(-0.12f, -1.61f, -0.71f);
    }

    void GoIntoLivingRoomFromHallway()
    {
        transform.position = new Vector3(3.119f, -1.769f, 16.702f);
    }

    void TurnBRLightBackNormal()
    {
        BRLight.SetActive(true);
    }

    void GoIntoHallwayFromLivingRoom()
    {
        transform.position = new Vector3(2.718f, -1.769f, 20.08f);
    }

    void TurnKRLightBackNormal()
    {
        KRLight.SetActive(true);
    }

    void GoIntoLivingRoomFromKitchen()
    {
        transform.position = new Vector3(-5.453f, -1.595f, 9.618f);
    }

    void TurnLightBackNormal()
    {
        LRLight.SetActive(true);
    }

    void GoIntoKitchen()
    {
        transform.position = new Vector3(-10.14f, -1.595f, 9.618f);
    }
}
