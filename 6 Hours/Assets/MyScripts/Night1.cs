using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Night1 : MonoBehaviour
{
    [SerializeField] bool isCutsceneDone = false;
    Animator aN;
    bool isOnTrail = false;
    [SerializeField] GameObject monster;
    int leftOrRightJumpscare;
    
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
            //isOnTrail = true;
        }
        else if (other.gameObject.tag != "Trail")
        {
            //isOnTrail = false;
            Debug.Log("dead");
            monster.gameObject.SetActive(true);
            leftOrRightJumpscare = Random.Range(1, 3);
            if (leftOrRightJumpscare == 1)
            {
                Debug.Log("right jumpscare");
            }
            if (leftOrRightJumpscare == 2)
            {
                Debug.Log("left jumpscare");
            }
        }
    }
}
