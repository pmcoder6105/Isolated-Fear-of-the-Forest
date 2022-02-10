using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day1Jumpscare : MonoBehaviour
{
    [SerializeField] GameObject jumpScareTimeline;
    AudioSource aS;
    [SerializeField] AudioClip jumpScare;

    // Start is called before the first frame update
    void Start()
    {
        aS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isActiveAndEnabled == true)
        {
            GetComponent<Animator>().Play("Shout", 0);
            Time.timeScale = .5f;
            jumpScareTimeline.SetActive(true);
            if (!aS.isPlaying)
            {
                aS.PlayOneShot(jumpScare);
            }
        }
    }
}
