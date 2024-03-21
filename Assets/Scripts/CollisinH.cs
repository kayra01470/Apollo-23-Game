using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisinH : MonoBehaviour
{
    [SerializeField] AudioClip collisionSound;
    [SerializeField] AudioClip success;
    AudioSource audioSource;
    bool isTrans = false;
    [SerializeField] ParticleSystem collisionParticle;
    [SerializeField] ParticleSystem successParticle;
    
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    
    
    
     void OnCollisionEnter(Collision other) {

        if(isTrans)
        {
            return;
        }
            
        switch(other.gameObject.tag) 
    {
        case "Friends":
            Debug.Log("It is friendly, don't afraid");
            break;
        case "Finish":
            FinishSequence();
            break;
        case "Fuel":
            Debug.Log("You get fuel");
            break;   
        default:
            DeathSequence();
            break;
            
    }
        
    }

    void Respawn()
    {   
        int myIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(myIndex);
    }

    void NextLevel()
    {
        
        int myIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = myIndex +1 ;
        
        if (nextIndex == SceneManager.sceneCountInBuildSettings)
        {
            Application.Quit();
            nextIndex = 0;
        }
        SceneManager.LoadScene(nextIndex);

    }

    void FinishSequence()
    {   
        
        isTrans = true;
        GetComponent<Movement>().enabled = false;
        audioSource.Stop();
        successParticle.Play();
        audioSource.PlayOneShot(success, 0.5f);
        GetComponent<Rigidbody>().freezeRotation = true;
        Invoke("NextLevel", 0.4f);
    }

    void DeathSequence()
    {   
        
        isTrans = true;
        audioSource.Stop();
        collisionParticle.Play();
        audioSource.PlayOneShot(collisionSound);
        GetComponent<Movement>().enabled = false;
        Invoke("Respawn", 0.5f);
    }
   
    
}

