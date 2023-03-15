using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    SurfaceEffector2D surfaceEffector2D;

    [SerializeField] private float torq = 1f;
    [SerializeField] private float boostSpeed = 30f;
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
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddTorque(torq);

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddTorque(-torq);

        }
        else if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.up * 10f);
        }
    }

    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }

    }

}