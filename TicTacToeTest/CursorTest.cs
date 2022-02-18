namespace TicTacToeTest;

using System;
using NUnit.Framework;
using TicTacToe;
using TicTacToe.IO;
using TicTacToe.Interfaces;


public class CursorTest {
    private Cursor cursor;

    [SetUp]
    public void Setup() {
        var keyToMoveMap = new KeyToMoveMap('i', 'k', 'j', 'l', 'q', ' ');
        cursor = new Cursor(3, keyToMoveMap);
        cursor.MoveDown();
        cursor.MoveRight();
    }

    [Test]
    public void CursorCenterTest() {
        Assert.True(cursor.position.X == 1 && cursor.position.Y == 1);
    }

    [Test]
    public void MoveUpTest() {
        // CODE HERE!
        Assert.Fail();
    }

    [Test]
    public void MoveDownTest() {
        // CODE HERE!
        Assert.Fail();
    }
    
    [Test]
    public void MoveLeftTest() {
        // CODE HERE!
        Assert.Fail();
    }

    [Test]
    public void MoveRightTest() {
        // CODE HERE!
        Assert.Fail();
    }   
}
