using UnityEngine.AI;
using UnityEngine;

public class Night3 : MonoBehaviour
{
    [SerializeField] NavMeshAgent monsterAI;
    [SerializeField] GameObject timeline;
    [SerializeField] GameObject canvas;
    [SerializeField] public GameObject capsule1Button;
    [SerializeField] public GameObject capsule2Button;
    [SerializeField] GameObject cam;
    [SerializeField] public Transform player;
    public bool isLookingAtCapsule1 = false;
    public bool isLookingAtCapsule2 = false;
    public bool canZoomIn = true;
    bool inRangeCapsule1 = false;
    bool inRangeCapsule2 = false;

    Animator aN;

    // Start is called before the first frame update
    void Start()
    {
        aN = GetComponent<Animator>();
        Debug.Log(Time.timeSinceLevelLoad);
        capsule1Button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        monsterAI.SetDestination(player.position);
        monsterAI.GetComponent<Animator>().Play("Walk", 0);

        if (Input.GetKeyDown(KeyCode.Space) && inRangeCapsule1 == true)
        {           
            aN.enabled = true;
            cam.transform.localRotation = Quaternion.Euler(0, 0, 0);
            GetComponent<Rigidbody>().isKinematic = true;            
            if (canZoomIn == true)
            {
                aN.Play("ZoomIntoCapsule1", 0);
            }
            canvas.GetComponent<Animator>().Play("EnableCapsule1Button", 0);            
            isLookingAtCapsule1 = true;
            Invoke(nameof(TurnOnButton1), 1f);
            //capsule1Button.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && inRangeCapsule2 == true)
        {
            aN.enabled = true;
            cam.transform.localRotation = Quaternion.Euler(0, 0, 0);
            GetComponent<Rigidbody>().isKinematic = true;
            if (canZoomIn == true)
            {
                aN.Play("ZoomIntoCapsule2", 0);
            }
            canvas.GetComponent<Animator>().Play("EnableCapsule2Button", 0);
            isLookingAtCapsule2 = true;
            Invoke(nameof(TurnOnButton2), 1f);
            //capsule1Button.SetActive(true);
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

    void TurnOnButton1()
    {
        Debug.Log("time to click button");
        if (capsule1Button.active == false)
        {
            capsule1Button.SetActive(true);
        }        
    }
    void TurnOnButton2()
    {
        Debug.Log("time to click button");
        if (capsule2Button.active == false)
        {
            capsule2Button.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Capsule1Field")
        {
            inRangeCapsule1 = true;
        }
        else if (other.gameObject.tag != "Capsule1Field")
        {
            inRangeCapsule1 = false;
        }
        if (other.gameObject.tag == "Capsule2Field")
        {
            inRangeCapsule2 = true;
        }
        else if (other.gameObject.tag != "Capsule2Field")
        {
            inRangeCapsule2 = false;
        }
    }
}
