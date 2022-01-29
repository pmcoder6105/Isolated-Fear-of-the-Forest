using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenTransporter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("sd");
        if (other.gameObject.tag == "KitchenDoor")
        {
            Debug.Log("Joe mama");
            transform.position = new Vector3(-10.14f, -1.595f, 9.618f);
        }

        if (other.gameObject.tag == "LivingRoomDoor")
        {
            Debug.Log("Joe mama");
            transform.position = new Vector3(-5.453f, -1.595f, 9.618f);
        }
    }
}
