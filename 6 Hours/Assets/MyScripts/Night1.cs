using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Night1 : MonoBehaviour
{
    bool isCutsceneDone = false;
    Animator aN;
    
    // Start is called before the first frame update
    void Start()
    {
        aN = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCutsceneDone == true)
        {
            aN.enabled = false;
        }
    }
}
