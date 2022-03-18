using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Night1 : MonoBehaviour
{
    [SerializeField] bool aNOn = true;
    Animator aN;
    AudioSource aS;
    bool isOnTrail = false;
    [SerializeField] GameObject monster;
    [SerializeField] GameObject fadeOut;
    [SerializeField] AudioClip rustle;
    Vector3 monsterPos;
    int rustle1;
    int rustle2;
    int rustle3;
    int rustle4;
    int rustle5;
    int rustle6;
    int rustle7;
    float time = 0f;
    int timeInSeconds;
    // Start is called before the first frame update
    void Start()
    {
        aS = GetComponent<AudioSource>();
        aN = GetComponent<Animator>();
        rustle1 = Random.Range(4+24, 24+16);
        rustle2 = Random.Range(22+24, 24+51);
        rustle3 = Random.Range(60+24, 24+78);
        rustle4 = Random.Range(85+24, 24+94);
        rustle5 = Random.Range(96+24, 24+106);
        rustle6 = Random.Range(110+24, 24+115);
        rustle7 = Random.Range(116+24, 24+120);
        Debug.Log(rustle1);
        Debug.Log(rustle2);
        Debug.Log(rustle3);
        Debug.Log(rustle4);
        Debug.Log(rustle5);
        Debug.Log(rustle6);
        Debug.Log(rustle7);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Mathf.Round(time);
        EnablePlayerMovementAfterCutscene();       
        if (time == rustle1)
        {
            aS.PlayOneShot(rustle);
            Debug.Log("played rustle");
        }
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
