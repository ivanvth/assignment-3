namespace TicTacToeTest;

using System;
using NUnit.Framework;
using TicTacToe;

public class BoardCheckerTest {

    public Board board;
    public BoardChecker boardChecker;

    [SetUp]
    public void Setup() {
        board = new Board(3);
        boardChecker = new BoardChecker();
    }

    [Test]
    public void DiagonalWinTest() {
        // CODE HERE!
        Assert.Fail();
    }

    [Test]
    public void RowWinTest() {
        // CODE HERE!
        Assert.Fail();
    }
    
    [Test]
    public void ColumnWinTest() {
        // CODE HERE!
        Assert.Fail();
    }

    [Test]
    public void InconclusiveTest() {
        // CODE HERE!
        Assert.Fail();
    }

    [Test]
    public void TiedTest() {
        // CODE HERE!
        Assert.Fail();
    }
}
