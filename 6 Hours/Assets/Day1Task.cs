using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day1Task : MonoBehaviour
{
    bool isHoldingBox = false;
    
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
        if (other.gameObject.tag == "Box")
        {
            isHoldingBox = true;
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
