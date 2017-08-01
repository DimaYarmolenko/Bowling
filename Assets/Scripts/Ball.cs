using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Rigidbody body;
    private AudioSource audioSource;
    private bool isLaunched = false;
    private Vector3 ballStartPosition;

    public Vector3 launchSpeed;
    
    // Use this for initialization
	void Start ()
    {
        body = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        ballStartPosition = transform.position;

        body.useGravity = false;

        //Launch(launchSpeed);
    }

    public void Launch(Vector3 velocity)
    {
        if (!isLaunched)
        {
            body.useGravity = true;
            body.velocity = velocity;
            audioSource.Play();
            isLaunched = true;
        }
        
    }

    public bool IsInPlay() {
        return isLaunched;
    }

    public void Reset()
    {
        isLaunched = false;
        body.useGravity = false;
        body.velocity = Vector3.zero;
        body.angularVelocity = Vector3.zero;
        transform.rotation = Quaternion.identity;
        transform.position = ballStartPosition;
    }
}
