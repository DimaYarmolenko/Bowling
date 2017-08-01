using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    private List<Text> rollsCard, framesCard;
    
    // Use this for initialization
	void Start () {
        rollsCard = new List<Text>();
        framesCard = new List<Text>();

        foreach (Text item in GetComponentsInChildren<Text>())
        {
            if (item.tag == "Roll")
            {
                rollsCard.Add(item);
            }
            else if (item.tag == "Frame")
            {
                framesCard.Add(item);
            }
        }      
	}

    public void FillRolls(List<int> rolls)
    {
        string formatedRolls = FormatRolls(rolls);

        for (int i = 0; i < formatedRolls.Length; i++)
        {
            rollsCard[i].text = formatedRolls[i].ToString();
        }
    }

    public void FillFrames(List<int> frames)
    {
        for (int i = 0; i < frames.Count; i++)
        {
            framesCard[i].text = frames[i].ToString();
        }
    }

    public static string FormatRolls(List<int> rolls)
    {
        string output = "";
        int strikes = 0;        //to shift i value in endframe check

        for (int i = 0; i < rolls.Count; i++)
        {
            if ((i + strikes == 20) && (rolls[i] + rolls[i - 1] == 10)) //bonus bowl spare handling
            {
                output += "/";
            }
            else if (((i + strikes) % 2 != 0) && (rolls[i] + rolls[i-1] == 10) && (rolls[i] != 0))  //spare
            {
                output += "/";
            }
            else if (rolls[i] == 10)    //strike
            {
                if (i + strikes >= 18)  //last frame srikes
                {
                    output += "X";
                }
                else
                {
                    output += "X ";
                    strikes++;
                }
            }
            else if(rolls[i] == 0)
            {
                output += "-";
            }
            else
            {
                output += rolls[i].ToString();
            }
        }

        return output;
    }


}
