using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowManager : MonoBehaviour {

    private List<int> rolls = new List<int>();
    private Ball ball;
    private PinSetter pinSetter;
    private ScoreDisplay scoreDisplay;
    
    // Use this for initialization
	void Start () {
        ball = FindObjectOfType<Ball>();
        pinSetter = FindObjectOfType<PinSetter>();
        scoreDisplay = FindObjectOfType<ScoreDisplay>();
	}

    public void PinFall(int pinsFall)
    {
        try
        {
            rolls.Add(pinsFall);
            pinSetter.Animate(ActionMaster.NextAction(rolls));
            ball.Reset();
        }
        catch
        {

            Debug.Log("Something went wrong in PinFall()");
        }

        try
        {
            scoreDisplay.FillRolls(rolls);
            scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(rolls));
        }
        catch
        {

            Debug.LogWarning("something went wrong in FillRollCards()");
        }

        
    }
}
