using UnityEngine.AI;
using UnityEngine;

public class Night3 : MonoBehaviour
{
    [SerializeField] NavMeshAgent monsterAI;
    [SerializeField] GameObject timeline;
    [SerializeField] Transform player;
    bool isTransitioningToCapsule1 = false;

    Animator aN;

    // Start is called before the first frame update
    void Start()
    {
        aN = GetComponent<Animator>();
        Debug.Log(Time.timeSinceLevelLoad);
    }

    // Update is called once per frame
    void Update()
    {
        monsterAI.SetDestination(player.position);
        monsterAI.GetComponent<Animator>().Play("Walk", 0);

        if (Input.GetKeyDown(KeyCode.Space) && isTransitioningToCapsule1 == false)
        {
            aN.SetBool("isLookingAtCapsule1", true);
            Debug.Log(aN.GetBool("isLookingAtCapsule1"));
            isTransitioningToCapsule1 = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isTransitioningToCapsule1 == true)
        {
            aN.SetBool("isLookingAtCapsule1", false);
            Debug.Log("clicked down space button");
            isTransitioningToCapsule1 = false;
        }

        if (Time.timeSinceLevelLoad >= 11)
        {
            timeline.SetActive(false);
        }
        if (timeline.active == false)
        {
            aN.enabled = false;
        }
    }
}
