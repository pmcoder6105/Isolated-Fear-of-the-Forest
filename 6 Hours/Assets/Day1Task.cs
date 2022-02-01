using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day1Task : MonoBehaviour
{
    [SerializeField] GameObject boxAnim;
    [SerializeField] GameObject boxToPlaceInside;
    [SerializeField] GameObject placedBox;
    bool hasPickedBox = false;
    bool ableToPlaceBox = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ableToPlaceBox == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("Box?");
                boxToPlaceInside.SetActive(true);
                Invoke(nameof(ReplaceBox), 0.5f);
            }
        }
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
    }
}
