using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetect : MonoBehaviour
{
    [SerializeField] private float delay = 0.5f;
    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] AudioClip crashSound;

    

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ground"))
        {
            FindObjectOfType<PlayerController>().DisableControls();
            crashParticles.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSound);
            Invoke("LoadNextScene",delay);
        }
        
    }
    
    void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
    }
    
}
