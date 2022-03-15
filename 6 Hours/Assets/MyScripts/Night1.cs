using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Night1 : MonoBehaviour
{
    [SerializeField] bool isCutsceneDone = false;
    Animator aN;
    bool isOnTrail = false;
    [SerializeField] GameObject monster;
    //[SerializeField] AnimationClip death;
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
            GetComponent<Animator>().enabled = true;
            aN.enabled = true;
            Debug.Log("dead");
            monster.gameObject.SetActive(true);
            RandomDirectionOfJumpscare();            
            aN.Play("DeathAnimNight1", 0);
            this.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    void RandomDirectionOfJumpscare()
    {
        monster.transform.localRotation = this.gameObject.transform.localRotation;
        leftOrRightJumpscare = Random.Range(1, 3);
        if (leftOrRightJumpscare == 1)
        {
            Debug.Log("right jumpscare");
            float currentPlayerPosX = this.gameObject.transform.position.x + 2;
            float monsterPosX = monster.transform.position.x;
            monsterPosX = currentPlayerPosX;
            monster.transform.localRotation = Quaternion.Euler(monster.transform.localRotation.x, 90f, monster.transform.localRotation.z);
        }
        if (leftOrRightJumpscare == 2)
        {
            Debug.Log("left jumpscare");
            //monster.transform.position = this.gameObject.transform.position;
        }
    }
}
