using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private float delay = .5f;
    [SerializeField] ParticleSystem finishParticles;
    [SerializeField] AudioSource finishSound;

    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            finishParticles.Play();
            finishSound.Play();
            Invoke("LoadNextScene",delay);
        }
    }
    
    void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
    }
}
