using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster {

    public static List<int> ScoreCumulative(List<int> scores)
    {
        List<int> cumulativeScores = new List<int>();
        int scoreAcumulator = 0;

        foreach (int score in ScoreFrames(scores))
        {
            scoreAcumulator += score;
            cumulativeScores.Add(scoreAcumulator);
        }

        return cumulativeScores;

    }

    public static List<int> ScoreFrames(List<int> rolls)
    {
        List<int> scores = new List<int>();
        int strikes = 0;                        //counts strikes to shift iterator value in odd/even check

        for (int i = 0; i < rolls.Count; i++)
        {
            if (scores.Count == 10) {break;}    //no more than 10 frames

            if ((i + strikes) % 2 != 0)     //if it's the frame's end
            {
                if ((i + 1 < rolls.Count) && (rolls[i] + rolls[i - 1] == 10))   //if it's spare
                {
                    scores.Add(10 + rolls[i + 1]);
                    continue;
                }
                else if(rolls[i] + rolls[i - 1] < 10)   //open frame
                {
                    scores.Add(rolls[i] + rolls[i - 1]);
                    continue;
                }
            }

            if ((rolls[i] == 10) && (i + 2 < rolls.Count))  //if there are two more bowls after strike
            {
                scores.Add(10 + rolls[i + 1] + rolls[i + 2]);
                strikes++;
            }
        }
        return scores;
    }
}
