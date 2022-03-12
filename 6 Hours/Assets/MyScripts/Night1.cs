using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Night1 : MonoBehaviour
{
    [SerializeField] bool isCutsceneDone = false;
    Animator aN;
    bool isOnTrail = false;
    
    // Start is called before the first frame update
    void Start()
    {
        aN = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        EnablePlayerMovementAfterCutscene();
    }

    void EnablePlayerMovementAfterCutscene()
    {
        if (isCutsceneDone == true)
        {
            aN.enabled = false;
        }
    }
    void OnCollisionEnter(Collision other)
    {
        CheckIfOnTrail(other);
    }

    void CheckIfOnTrail(Collision other)
    {
        if (other.gameObject.tag == "Trail")
        {
            isOnTrail = true;
        }
        else
        {
            isOnTrail = false;
        }
    }
}
