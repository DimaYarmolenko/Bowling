using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    private Animator animator;
    private PinCounter pinCounter;


    public GameObject pinSet;
    
    // Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        pinCounter = FindObjectOfType<PinCounter>();
	}


    public void RaisePins() {

        foreach (Pin pin in FindObjectsOfType<Pin>())
        {
            pin.RaiseIfStanding();
        }
        
    }

    public void LowerPins()
    {

        foreach (Pin pin in FindObjectsOfType<Pin>())
        {
            pin.Lower();
        }
    }

    public void RenewPins()
    {
        Instantiate(pinSet, new Vector3(0, 40f, 1829), Quaternion.identity);
        pinCounter.Reset();
    }

    public void Animate(ActionMaster.Action action)
    {
        if (action == ActionMaster.Action.Reset || action == ActionMaster.Action.EndTurn)
        {
            animator.SetTrigger("resetTrigger");
        }
        else if (action == ActionMaster.Action.Tidy)
        {
            animator.SetTrigger("tidyTrigger");
        }
    }
}
