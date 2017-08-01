using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using System.Linq;

[TestFixture]
public class ScoreDisplayTest {
    [Test]
    public void T00PassingTest()
    {
        Assert.AreEqual(1, 1);
    }
	
    [Test]
    public void T01BowlOne()
    {
        int[] rolls = { 1 };
        string output = "1";
        Assert.AreEqual(output, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T02BowlTwoEightSpare()
    {
        int[] rolls = { 2, 8 };
        string output = "2/";
        Assert.AreEqual(output, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T03Bowl285()
    {
        int[] rolls = { 2, 8, 5 };
        string output = "2/5";
        Assert.AreEqual(output, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T04StrikeBowl()
    {
        int[] rolls = { 10 };
        string output = "X ";
        Assert.AreEqual(output, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T05Bowl10558()
    {
        int[] rolls = { 10, 5,5, 8 };
        string output = "X 5/8";
        Assert.AreEqual(output, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T06SBowl010Spare()
    {
        int[] rolls = { 0,10 };
        string output = "-/";
        Assert.AreEqual(output, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T07LastFrameStrike()
    {
        int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,0,10 };
        string output = "111111111111111111X-/";
        Assert.AreEqual(output, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T08Bowl010()
    {
        int[] rolls = { 0,10 };
        string output = "-/";
        Assert.AreEqual(output, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    // http://slocums.homestead.com/gamescore.html
    [Test]
    [Category("Verification")]
    public void TG01GoldenCopyA()
    {
        int[] rolls = { 10, 7,3, 9,0, 10, 0,8, 8,2, 0,6, 10, 10, 10,8,1 };
        string output = "X 7/9-X -88/-6X X X81";
        Assert.AreEqual(output, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    //http://guttertoglory.com/wp-content/uploads/2011/11/score-2011_11_28.png
    [Category("Verification")]
    [Test]
    public void TG02GoldenCopyB1of3()
    {
        int[] rolls = { 10, 9,1, 9,1, 9,1, 9,1, 7,0, 9,0, 10, 8,2, 8,2,10 };
        string output = "X 9/9/9/9/7-9-X 8/8/X";
        Assert.AreEqual(output, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    //http://guttertoglory.com/wp-content/uploads/2011/11/score-2011_11_28.png
    [Category("Verification")]
    [Test]
    public void TG03GoldenCopyB2of3()
    {
        int[] rolls = { 8,2, 8,1, 9,1, 7,1, 8,2, 9,1, 9,1, 10, 10, 7,1 };
        string output = "8/819/718/9/9/X X 71";
        Assert.AreEqual(output, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    //http://guttertoglory.com/wp-content/uploads/2011/11/score-2011_11_28.png
    [Category("Verification")]
    [Test]
    public void TG04GoldenCopyB3of3()
    {
        int[] rolls = { 10, 10, 9,0, 10, 7,3, 10, 8,1, 6,3, 6,2, 9,1,10 };
        string output = "X X 9-X 7/X 8163629/X";
        Assert.AreEqual(output, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    // http://brownswick.com/wp-content/uploads/2012/06/OpenBowlingScores-6-12-12.jpg
    [Category("Verification")]
    [Test]
    public void TG05GoldenCopyC1of3()
    {
        int[] rolls = { 7,2, 10, 10, 10, 10, 7,3, 10, 10, 9,1, 10,10,9 };
        string output = "72X X X X 7/X X 9/XX9";
        Assert.AreEqual(output, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    // http://brownswick.com/wp-content/uploads/2012/06/OpenBowlingScores-6-12-12.jpg
    [Category("Verification")]
    [Test]
    public void TG06GoldenCopyC2of3()
    {
        int[] rolls = { 10, 10, 10, 10, 9,0, 10, 10, 10, 10, 10,9,1 };
        string output = "X X X X 9-X X X X X9/";
        Assert.AreEqual(output, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

}
