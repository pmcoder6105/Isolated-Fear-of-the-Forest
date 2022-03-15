using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpscare : MonoBehaviour
{
    [SerializeField] GameObject jumpScareTimeline;
    AudioSource aS;
    [SerializeField] AudioClip monsterSoundChangeableDuringTimeline;

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
            if (!aS.isPlaying)
            {
                aS.PlayOneShot(monsterSoundChangeableDuringTimeline);
            }
            Invoke(nameof(Playjumpscare), 4.3f);
        }
    }

    void Playjumpscare()
    {
        if (!aS.isPlaying)
        {
            aS.PlayOneShot(monsterSoundChangeableDuringTimeline);
        }
        Invoke(nameof(StopJumpscare), .00000001f);
    }

    void StopJumpscare()
    {
        aS.Stop();
    }

    private void TurnOnMonster()
    {
        GetComponent<Animator>().enabled = true;
        GetComponent<Animator>().Play("Shout", 0);
    }
}
