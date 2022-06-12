using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    [SerializeField] GameObject fadeOutEffect;
    AudioSource aS;
    Rigidbody rB;
    [SerializeField] AudioClip doorOpening1;
    [SerializeField] AudioClip doorOpening2;
    [SerializeField] AudioClip flashlightSFX;
    [SerializeField] AudioClip jumpSFX;
    [SerializeField] public GameObject walkingEmpty;
    [SerializeField] public GameObject flashlight;
    bool isFlashlightOn = false;
    int doorSound;

    void Start()
    {
        aS = GetComponent<AudioSource>();
        rB = GetComponent<Rigidbody>();
        //walkingEmpty.SetActive(false);
        if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 3)
        walkingEmpty.GetComponent<AudioSource>().volume = 0f;
    }

    void Update()
    {
        WalkingSFX();
        FlashlightToggle();
        Cursor.visible = true;
    }

    void FlashlightToggle()
    {
        if (flashlight.active == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                isFlashlightOn = !isFlashlightOn;
                if (!aS.isPlaying)
                {
                    flashlight.GetComponent<AudioSource>().Stop();
                    flashlight.GetComponent<AudioSource>().PlayOneShot(flashlightSFX);                    
                    Invoke(nameof(StopPlayingAudio), 0.3f);
                }
            }
            if (isFlashlightOn == true)
            {
                flashlight.GetComponent<Light>().enabled = true;
            }
            if (isFlashlightOn == false)
            {
                flashlight.GetComponent<Light>().enabled = false;
            }
        }  
    }

    void StopPlayingAudio()
    {
        flashlight.GetComponent<AudioSource>().Stop();
    }

    void WalkingSFX()
    {
        if (Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.D))
        {
            //walkingEmpty.SetActive(true);
            //if (!walkingEmpty.GetComponent<AudioSource>().isPlaying)
            //{
            //    walkingEmpty.GetComponent<AudioSource>().Play();
            //}
            walkingEmpty.GetComponent<AudioSource>().volume = 0.7f;
        }
        if (Input.GetKeyUp(KeyCode.W) ||
            Input.GetKeyUp(KeyCode.S) ||
            Input.GetKeyUp(KeyCode.A) ||
            Input.GetKeyUp(KeyCode.D))
        {
            //walkingEmpty.SetActive(false);
            walkingEmpty.GetComponent<AudioSource>().volume = 0f;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.active == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!aS.isPlaying)
                {
                    aS.PlayOneShot(jumpSFX);
                }
            }
        }
    }
}
