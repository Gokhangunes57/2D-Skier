using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    SurfaceEffector2D surfaceEffector2D;

    [SerializeField] private float torq = 10f;
    [SerializeField] private float boostSpeed = 40f;
    [SerializeField] private float baseSpeed = 20f;
    bool CanMove = true;
    [SerializeField] AudioClip gamemusic;




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        GetComponent<AudioSource>().PlayOneShot(gamemusic);

    }

    // Update is called once per frame
    void Update()
    {
        if (CanMove)
        {

            Rotate();
            
            RespondToBoost();

        }

    }

    public void DisableControls()
    {
        CanMove = false;
    }

    void Rotate()
    {
       Debug.Log("çalıştı");
    }

    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddTorque(torq);
            Debug.Log("çalıştı left");

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddTorque(-torq);
            Debug.Log("çalıştı right");

        }
        else if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.up * 10f);
        }
        
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
        
        

    }

}