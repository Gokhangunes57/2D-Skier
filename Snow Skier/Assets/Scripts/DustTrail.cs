using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] private ParticleSystem dustTrail;

    private int score = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    bool ExitWorked = false;


    

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            
            ExitWorked = true;
            dustTrail.Stop();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            ExitWorked = false;
            dustTrail.Play();
        }
    }

    private void Update()
    {
        if (ExitWorked == true)
        {
            Score();
          

        }

    }

    void Score()
    {
        
        score++;
       scoreText.text = "Score: " + score.ToString();
    }
}
