using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Ball))]
public class DragLaunch : MonoBehaviour {

    private Ball ball;
    private Vector3 mousePos;
    private float time;
    private GameObject floor;
    private float xMin, xMax;

    // Use this for initialization
	void Start () {
        ball = GetComponent<Ball>();
        floor = GameObject.Find("Floor");

        xMin = floor.transform.position.x - (floor.transform.lossyScale.x / 2);
        xMax = floor.transform.position.x + (floor.transform.lossyScale.x / 2);
    }

    public void DragStart() {
        mousePos = Input.mousePosition;
        time = Time.time;
    }

    public void DragEnd() {
        Vector3 velocity = new Vector3();
        Vector3 currentMousePos = Input.mousePosition;
        float currentTime = Time.time;

        float angle = currentMousePos.x - mousePos.x;
        float lenghts = Mathf.Sqrt(Mathf.Pow(currentMousePos.x - mousePos.x, 2) + Mathf.Pow(currentMousePos.y - mousePos.y, 2) + Mathf.Pow(currentMousePos.z - mousePos.z, 2));
        velocity.z = lenghts / (currentTime - time);
        velocity.x = angle;
        ball.Launch(velocity);

    }

    public void MoveStart(float xNudge)
    {
        if (!ball.IsInPlay())
        {
            float xPos = transform.position.x;
            float yPos = transform.position.y;
            float zPos = transform.position.z;
            Vector3 newPos = new Vector3(Mathf.Clamp(xPos + xNudge, xMin, xMax), yPos, zPos);
            transform.position = newPos;
        }
    }
}
