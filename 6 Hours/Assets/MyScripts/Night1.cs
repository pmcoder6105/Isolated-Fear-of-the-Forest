using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Night1 : MonoBehaviour
{
    [SerializeField] bool aNOn = true;
    Animator aN;
    bool isOnTrail = false;
    [SerializeField] GameObject monster;
    [SerializeField] GameObject fadeOut;
    Vector3 monsterPos;

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
        if (aNOn == false)
        {
            aN.enabled = false;
        }
        else if (aNOn == true)
        {
            aN.enabled = true;
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
            monsterPos = monster.gameObject.transform.position;
            aNOn = true;
            GetComponent<Animator>().enabled = true;
            aN.enabled = true;
            Debug.Log("dead");
            JumpscareMonster();            
            aN.Play("DeathAnimNight1", 0);
            this.GetComponent<Rigidbody>().isKinematic = true;
            fadeOut.GetComponent<Animator>().Play("DeathFadeOut", 0);
        }
    }

    void JumpscareMonster()
    {
        monster.SetActive(true);
        monster.gameObject.transform.position = monsterPos;
    }
}
