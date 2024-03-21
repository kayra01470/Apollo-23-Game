using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] float mainThrust = 450f;
    [SerializeField] float rotationSpeed = 30f;
    [SerializeField] ParticleSystem leftParticle;
    [SerializeField] ParticleSystem rightParticle;
    [SerializeField] ParticleSystem boostParticle;
    BoxCollider bx;
    
    
    void Thrusting()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            StartThrustingAndParticle();
        }
        else
        {
            audioSource.Stop();
        }    
            
    
    }

    void StartThrustingAndParticle()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        boostParticle.Play();
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);

        }
    }

    void Rotating(){
        if (Input.GetKey(KeyCode.A))
        {
            ProcessGoingLeft();

        }

        else if (Input.GetKey(KeyCode.D))
        {

            ProcessGoingRight();
        }
        else if(Input.GetKey(KeyCode.L))
        {
            int myIndex = SceneManager.GetActiveScene().buildIndex;
            int newIndex = myIndex + 1;
            
            if(newIndex == SceneManager.sceneCountInBuildSettings)
            {
                newIndex = 0;
            }
            SceneManager.LoadScene(newIndex);

        }
        else if(Input.GetKeyDown(KeyCode.C))
        {
            bx.enabled = !bx.enabled;
        }
        else
        {
            rightParticle.Stop();
            leftParticle.Stop();
        }
    }

    private void ProcessGoingRight()
    {
        TransRota(-rotationSpeed);
        if (!rightParticle.isPlaying)
        {

            rightParticle.Play();
        }

    }

    private void ProcessGoingLeft()
    {
        TransRota(rotationSpeed);
        if (!leftParticle.isPlaying)
        {

            leftParticle.Play();

        }
    }

    void TransRota(float value)
    {   rb.freezeRotation = true;
        transform.Rotate(Vector3.forward*Time.deltaTime*value);
        rb.freezeRotation = false;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        bx = GetComponent<BoxCollider>();


    }

    // Update is called once per frame
    void Update()
    {
        Thrusting();
        Rotating();

                        
    }
}
