using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transporter : MonoBehaviour
{

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("sd");
        if (other.gameObject.tag == "KitchenDoor")
        {
            Debug.Log("Joe mama");
            transform.position = new Vector3(-10.14f, -1.595f, 9.618f);
        }

        if (other.gameObject.tag == "KitchenLivingRoomDoor")
        {
            Debug.Log("Joe mama");
            transform.position = new Vector3(-5.453f, -1.595f, 9.618f);
        }
        if (other.gameObject.tag == "BedRoomDoor")
        {
            Debug.Log("Joe mama's mama");
            transform.position = new Vector3(2.718f, -1.769f, 20.08f);
        }
        if (other.gameObject.tag == "BedLivingRoomDoor")
        {
            Debug.Log("Joe mama's mama's mama");
            transform.position = new Vector3(3.119f, -1.769f, 16.702f);
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
}
