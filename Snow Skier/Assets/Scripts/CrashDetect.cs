using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetect : MonoBehaviour
{
    [SerializeField] private float delay = .5f;
    [SerializeField] ParticleSystem crashParticles;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ground"))
        {
            crashParticles.Play();
            Invoke("LoadNextScene",delay);
        }
        
    }
    
    void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
    }
    
}
