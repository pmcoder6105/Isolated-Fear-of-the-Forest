using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day1Task : MonoBehaviour
{

    [SerializeField] GameObject boxAnim;

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
            Debug.Log("Picked Up Box");
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            boxAnim.SetActive(true);
        }
    }
}
