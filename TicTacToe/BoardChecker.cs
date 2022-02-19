namespace TicTacToe;

using System;
using TicTacToe.Interfaces;


/// <summary>
/// A basic board checker that will determine if for a given row, diagonal or column, if all of
/// the elements is equal to eachother and not equal to null. It will also determine if the board
/// is in a tied position.
/// </summary>
public class BoardChecker : IBoardChecker {

    /// <summary>
    /// Method that is used to check if all elements in a row is equal to eachother and is not
    /// equal to null.
    /// </summary>
    /// <param name="board">A given board.</param>
    /// <returns>
    /// True if there is a win where all identifiers in the row is equal else false.
    /// </returns>
    private bool IsRowWin(Board board) {
        PlayerIdentifier? first = null;
        for (int row=0; row<board.Size; row++) {
            first = board.Get(row, 0);
            if (first is null) {
                continue;
            }
            for (int col=1; col<board.Size; col++) {
                if (board.Get(row, col) != first) {
                    first = null;
                    break;
                }
            }
            if (first is not null) {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Method that is used to check if all elements in a column is equal to eachother and is not
    /// equal to null.
    /// </summary>
    /// <param name="board">A given board.</param>
    /// <returns>
    /// True if there is a win where all identifiers in the column is equal else false.
    /// </returns>
    private bool IsColWin(Board board) {
        PlayerIdentifier? first = null;
        for (int col=0; col<board.Size; col++) {
            first = board.Get(0, col);
            if (first is null) {
                continue;
            }
            for (int row=1; row<board.Size; row++) {
                if (board.Get(row, col) != first) {
                    first = null;
                    break;
                }
            }
            if (first is not null) {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Method that is used to check if all elements in a diagonal is equal to eachother and is not
    /// equal to null. This diagonal will always be the two longest in a square.
    /// </summary>
    /// <param name="board">A given board.</param>
    /// <returns>
    /// True if there is a win where all identifiers in the diagonal is equal else false.
    /// </returns>
    private bool IsDiagWin(Board board) {
        PlayerIdentifier? first = board.Get(0, 0);
        if (first is not null) {
            for (int rowcol=1; rowcol<board.Size; rowcol++) {
                if (board.Get(rowcol, rowcol) != first) {
                    first = null;
                    break;
                }
            }
            if (first is not null) {
                return true;   
            }
        }
        first = board.Get(0, board.Size-1);
        if (first is not null) {
            for (int row=1, col=board.Size-2; row<board.Size; row++, col--) {
                if (board.Get(row, col) != first) {
                    first = null;
                    break;
                }
            }
        }
        if (first is not null) {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Method that will determine what the state of the board is. If there is a winner, a tied or
    /// the game is still inconclusive.
    /// </summary>
    /// <param name="board">A given board.</param>
    /// <returns> The state of the board.</returns>
    public BoardState CheckBoardState(Board board) {
        if (IsRowWin(board)) {
            return BoardState.Winner;
        } else if (IsColWin(board)) {
            return BoardState.Winner;
        } else if (IsDiagWin(board)) {
            return BoardState.Winner;
        } else if (board.IsFull()) {
            return BoardState.Tied;
        } else {
            return BoardState.Inconclusive;
        }
    }
}