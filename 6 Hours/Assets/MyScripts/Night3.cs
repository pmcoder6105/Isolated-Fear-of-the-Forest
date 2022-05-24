using UnityEngine.AI;
using UnityEngine;

public class Night3 : MonoBehaviour
{
    [SerializeField] NavMeshAgent monsterAI;
    [SerializeField] GameObject timeline;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject capsule1Button;
    [SerializeField] public Transform player;
    public bool isLookingAtCapsule1 = false;

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            aN.enabled = true;
            GetComponent<Rigidbody>().isKinematic = true;
            aN.Play("ZoomIntoCapsule1", 0);
            canvas.GetComponent<Animator>().Play("EnableCapsule1Button", 0); 
            isLookingAtCapsule1 = true;
        }

        if (Time.timeSinceLevelLoad >= 11)
        {
            timeline.SetActive(false);
        }
        if (timeline.active == false && Time.timeSinceLevelLoad <= 12)
        {
            aN.enabled = false;
        }
    }
}
