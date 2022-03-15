using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Night1Jumpscare : MonoBehaviour
{
    AudioSource aS;
    [SerializeField] AudioClip jumpscare;
    // Start is called before the first frame update
    void Start()
    {
        aS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.active == true)
        {
            if (!aS.isPlaying)
            {
                aS.PlayOneShot(jumpscare);
                Invoke(nameof(Stop), Mathf.Epsilon);
            }
        }
    }

    void Stop()
    {
        GetComponent<Night1Jumpscare>().enabled = false;
        Debug.Log("stop");
        if (aS.isPlaying)
        {
            aS.Stop();
        }       
    }
}
