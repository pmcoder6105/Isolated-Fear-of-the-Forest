using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day1Jumpscare : MonoBehaviour
{
    [SerializeField] GameObject jumpScareTimeline;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isActiveAndEnabled == true)
        {
            GetComponent<Animator>().Play("Shout", 0);
            Time.timeScale = .5f;
            jumpScareTimeline.SetActive(true);
        }
        if (Input.GetKey(KeyCode.C))
        {
            this.gameObject.SetActive(true);
            jumpScareTimeline.SetActive(true);
        }
    }
}
