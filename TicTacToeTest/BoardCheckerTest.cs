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
    public void DiagonalWinTest1() {
        board.TryInsert(0, 0, PlayerIdentifier.Cross);
        board.TryInsert(1, 1, PlayerIdentifier.Cross);
        board.TryInsert(2, 2, PlayerIdentifier.Cross);
        Assert.AreEqual(BoardState.Winner, boardChecker.CheckBoardState(board));
    }

    [Test]
    public void DiagonalWinTest2() {
        board.TryInsert(0, 2, PlayerIdentifier.Cross);
        board.TryInsert(1, 1, PlayerIdentifier.Cross);
        board.TryInsert(2, 0, PlayerIdentifier.Cross);
        Assert.AreEqual(BoardState.Winner, boardChecker.CheckBoardState(board));
    }

    [Test]
    public void RowWinTest1() {
        board.TryInsert(0, 0, PlayerIdentifier.Cross);
        board.TryInsert(0, 1, PlayerIdentifier.Cross);
        board.TryInsert(0, 2, PlayerIdentifier.Cross);
        Assert.AreEqual(BoardState.Winner, boardChecker.CheckBoardState(board));
    }

    [Test]
    public void RowWinTest2() {
        board.TryInsert(0, 0, PlayerIdentifier.Cross);
        board.TryInsert(0, 1, PlayerIdentifier.Cross);
        board.TryInsert(1, 2, PlayerIdentifier.Cross);
        Assert.AreEqual(BoardState.Inconclusive, boardChecker.CheckBoardState(board));
    }
    
    [Test]
    public void ColumnWinTest1() {
        board.TryInsert(0, 0, PlayerIdentifier.Cross);
        board.TryInsert(1, 0, PlayerIdentifier.Cross);
        board.TryInsert(2, 0, PlayerIdentifier.Cross);
        Assert.AreEqual(BoardState.Winner, boardChecker.CheckBoardState(board));
    }

    [Test]
    public void ColumnWinTest2() {
        board.TryInsert(0, 1, PlayerIdentifier.Cross);
        board.TryInsert(1, 1, PlayerIdentifier.Cross);
        board.TryInsert(2, 1, PlayerIdentifier.Cross);
        Assert.AreEqual(BoardState.Winner, boardChecker.CheckBoardState(board));
    }

    [Test]
    public void InconclusiveTest() {
        board.TryInsert(0, 0, PlayerIdentifier.Cross);
        board.TryInsert(1, 0, PlayerIdentifier.Naught);
        board.TryInsert(2, 0, PlayerIdentifier.Cross);
        board.TryInsert(0, 1, PlayerIdentifier.Naught);
        board.TryInsert(1, 1, PlayerIdentifier.Cross);
        board.TryInsert(2, 1, PlayerIdentifier.Naught);
        board.TryInsert(0, 2, PlayerIdentifier.Naught);
        Assert.AreEqual(BoardState.Inconclusive, boardChecker.CheckBoardState(board));
    }

    [Test]
    public void TiedTest() {
        board.TryInsert(0, 0, PlayerIdentifier.Cross);
        board.TryInsert(1, 0, PlayerIdentifier.Naught);
        board.TryInsert(2, 0, PlayerIdentifier.Cross);
        board.TryInsert(0, 1, PlayerIdentifier.Naught);
        board.TryInsert(1, 1, PlayerIdentifier.Cross);
        board.TryInsert(2, 1, PlayerIdentifier.Naught);
        board.TryInsert(0, 2, PlayerIdentifier.Naught);
        board.TryInsert(1, 2, PlayerIdentifier.Cross);
        board.TryInsert(2, 2, PlayerIdentifier.Naught);
        Assert.AreEqual(BoardState.Tied, boardChecker.CheckBoardState(board));
    }
}
