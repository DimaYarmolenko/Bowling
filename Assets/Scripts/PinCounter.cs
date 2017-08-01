using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {

    private int lastStandingCount = -1;
    private int standingPinsBeforeBowl = 10;
    private float lastChangeTime;
    private bool ballLeftTheBox = false;
    private FlowManager flowManager;

    public Text pinDisplay;
    

    // Use this for initialization
    void Start () {
        flowManager = FindObjectOfType<FlowManager>();
	}
	
	// Update is called once per frame
	void Update () {
        pinDisplay.text = CountStanding().ToString();

        if (ballLeftTheBox)
        {
            CheckStanding();
        }
	}

    private int CountStanding()
    {
        int res = 0;

        foreach (Pin item in FindObjectsOfType<Pin>())
        {
            if (item.IsStanding())
            {
                res++;
            }
        }
        return res;
    }

    void CheckStanding()
    {
        int standingPins = CountStanding();
        float timeToWait = 3f;

        if (standingPins != lastStandingCount)
        {
            lastStandingCount = standingPins;
            lastChangeTime = Time.time;
            return;
        }

        if ((Time.time - lastChangeTime) > timeToWait)
        {
            PinsHaveSattled();
        }
    }

    void PinsHaveSattled()
    {
        flowManager.PinFall(standingPinsBeforeBowl - lastStandingCount);
        standingPinsBeforeBowl = lastStandingCount;
        lastStandingCount = -1;
        pinDisplay.color = Color.green;
        ballLeftTheBox = false;
    }

    public void Reset()
    {
        standingPinsBeforeBowl = 10;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Ball>())
        {
            ballLeftTheBox = true;
            pinDisplay.color = Color.red;
        }
    }
}
