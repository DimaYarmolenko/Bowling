using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    private Vector3 offset;

    public GameObject ball;
    
    // Use this for initialization
	void Start ()
    {
        offset = new Vector3(0, 50f, -100f);
        AttachToTheBall();
    }

    

    // Update is called once per frame
    void Update () {
        if (ball.transform.position.z < 1829 + offset.z) {
            AttachToTheBall();
        }
	}

    private void AttachToTheBall()
    {
        transform.position = ball.transform.position + offset;
    }
}
