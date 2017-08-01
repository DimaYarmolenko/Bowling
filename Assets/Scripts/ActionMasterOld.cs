using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster {

	public enum Action { Tidy, Reset, EndTurn, EndGame};

    private  int bowlNumber = 1;
    private  int[] bowls = new int[21];

    public static Action NextAction(List<int> pinsFall)
    {
        ActionMaster actionMaster = new ActionMaster();
        Action result = new Action();

        foreach (int pins in pinsFall)
        {
            result = actionMaster.Bowl(pins);
        }

        return result;

        
    }

    private Action Bowl(int pins)
    {
        if (pins < 0 || pins > 10)      //check if pins amount is in valid range
        {
            throw new UnityException("Invalid amount of pins!");
        }

        bowls[bowlNumber - 1] = pins;

        if (bowlNumber == 21)           //handling the bonus bowl
        {
            return Action.EndGame;
        }

        if (bowlNumber == 20)           //handling the last bowl
        {
            if (LastTwoBowls() < 10)    //no strike/spare in the last bowl
            {
                return Action.EndGame;
            }
            else if (IsGutterBall())     //gutter ball at strike 20
            {
                bowlNumber++;
                return Action.Tidy;
            }
            else if (LastTwoBowls() == 10 && !IsGutterBall()) //spare in the last bowl awarding the bonus bowl
            {
                bowlNumber++;
                return Action.Reset;
            }
            else if ((LastTwoBowls() > 10) && (LastTwoBowls() < 20)) //handling non spare last bowl strike after awarding bonus bowl
            {
                bowlNumber++;
                return Action.Tidy;
            }
        }

        if (pins == 10)                 //handling strikes
        {
            if (bowlNumber >= 19)       //last frame strikes reset pins without passing the turn until the last bowl
            {
                bowlNumber++;
                return Action.Reset;
            }

            //strike gives turn to next player
            bowlNumber += (bowlNumber % 2 == 0) ? 1 : 2;
            return Action.EndTurn;
        }

        if (bowlNumber % 2 != 0)            //handling the first bowl in the frame
        {
            bowlNumber++;
            return Action.Tidy;
        }
        else
        {
            //handling the second bowl in the frame
            bowlNumber++;
            return Action.EndTurn;
        }

        //throw new UnityException("ActionMaster is not sure what to return!");
    }

    private int LastTwoBowls()
    {
        return bowls[bowlNumber - 1] + bowls[bowlNumber - 2];
    }

    private bool IsGutterBall()
    {
        return (bowls[bowlNumber - 1] == 0) ? true : false;
    }
}
