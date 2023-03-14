using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    
    [SerializeField] ParticleSystem finishParticles;
    [SerializeField] AudioSource finishSound;
    GameObject player;
    SurfaceEffector2D surfaceEffector2D;

    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
        player = GameObject.FindWithTag("Player");
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
           
            finishSound.Play();
            surfaceEffector2D.speed = 0;
            
        }
    }

    private void Update()
    {
        if ( player.transform.position.x>560)
        {
            finishParticles.Play();
        }
    }

    
}
