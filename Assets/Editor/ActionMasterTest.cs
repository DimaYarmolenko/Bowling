using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class ActionMasterTest {

    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private ActionMaster.Action endGame = ActionMaster.Action.EndGame;
    private ActionMaster.Action reset = ActionMaster.Action.Reset;

    [Test]
    public void T00PassingTest() {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01Bowl10ResturnsEndTurn()
    {
        List<int> bowls = new List<int> { 10 };
        Assert.AreEqual(endTurn, ActionMaster.NextAction(bowls));
    }

    [Test]
    public void T02FirstBowl8ReturnsTidy()
    {
        List<int> bowls = new List<int> { 8 };
        Assert.AreEqual(tidy, ActionMaster.NextAction(bowls));
    }

    [Test]
    public void T03SecondBowl8ReturnsEndTurn()
    {
        List<int> bowls = new List<int> { 1, 8 };
        Assert.AreEqual(endTurn, ActionMaster.NextAction(bowls));
    }

    [Test]
    public void T04LastBowlNotSpareReturnsEndGame()
    {
        List<int> bowls = new List<int> { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,5 };

        Assert.AreEqual(endGame, ActionMaster.NextAction(bowls));
    }

    [Test]
    public void T05LastBowlSpareReturnsResetIntoBonusBowl()
    {
        List<int> bowls = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,9 };

        Assert.AreEqual(reset, ActionMaster.NextAction(bowls));
    }

    [Test]
    public void T06After18bowlStrikesReturnReset()
    {
        List<int> bowls = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10 };

        Assert.AreEqual(reset, ActionMaster.NextAction(bowls));
    }

    [Test]
    public void T07Bowl20GutterBallReturnsTidy()
    {
        List<int> bowls = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 0 };

        Assert.AreEqual(tidy, ActionMaster.NextAction(bowls));
    }

    [Test]
    public void T08BonusBowlReturnsEndGame()
    {
        List<int> bowls = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 5, 5, 6 };

        Assert.AreEqual(endGame, ActionMaster.NextAction(bowls));
    }

    [Test]
    public void T09SecondStrikeInFrameAddsOneToCounter()
    {
        List<int> bowls = new List<int> { 0, 10, 2, 6 };

        Assert.AreEqual(endTurn, ActionMaster.NextAction(bowls));
    }

    [Test]
    public void T10Dondi10thFrameTurkey()
    {
        List<int> bowls = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 10, 10 };
        
        Assert.AreEqual(endGame, ActionMaster.NextAction(bowls));
    }
}
