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
        GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isActiveAndEnabled == true)
        {
            Invoke(nameof(TurnOnMonster), 4.4f);
            jumpScareTimeline.SetActive(true);
        }
    }

    private void TurnOnMonster()
    {
        GetComponent<Animator>().enabled = true;
        GetComponent<Animator>().Play("Shout", 0);
        if (!aS.isPlaying)
        {
            aS.PlayOneShot(jumpScare);
        }
    }
}
