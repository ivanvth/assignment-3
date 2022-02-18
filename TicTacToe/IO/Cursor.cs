namespace TicTacToe.IO;

using System;
using TicTacToe.Interfaces;


/// <summary>
/// Object that uses the console cursor to retrieve a position input.
/// </summary>
public class Cursor : IPositionInput {
    
    int min, max;
    public Position position;
    private ICharToInputType charToInputType;

    /// <summary>
    /// A property that makes it possible to use a short hand for modifing the X position.
    /// </summary>
    private int X {
        get => position.X;
        set => position.X = value;
    }

    /// <summary>
    /// A property that makes it possible to use a short hand for modifing the Y position.
    /// </summary>
    private int Y {
        get => position.Y; 
        set => position.Y = value;
    }

    /// <summary>
    /// The Cursor object needs to know the size of board and how it should convert keyboard
    /// keys to an InputType.
    /// </summary>
    /// <param name="size">The board is a square, so the size is a side length of a square.</param>
    /// <param name="charToInputType">
    /// An object that can convert the keyboard keys to InputType.
    /// </param>
    public Cursor(int size, ICharToInputType charToInputType) {
        this.charToInputType = charToInputType;

        X = Y = 0;
        min = 0;
        max = size - 1;
    }

    /// <summary>
    /// Moves the cursor one position up.
    /// </summary>
    public void MoveUp() {
        if (Y != min) {
            Y--;
        }
    }

    /// <summary>
    /// Moves the cursor one position down.
    /// </summary>
    public void MoveDown() {
        if (Y != max) {
            Y++;
        }
    }

    /// <summary>
    /// Moves the cursor one position left.
    /// </summary>
    public void MoveLeft() {
        X = X == min ? X : X-1;
    }

    /// <summary>
    /// Moves the cursor one position right.
    /// </summary>
    public void MoveRight() {
        X = X == max ? X : X+1;
    }

    /// <summary>
    /// Quits the game.
    /// </summary>
    public void Quit() {
        Console.Clear();
        Environment.Exit(0);
    }

    /// <summary>
    /// Method that will perform some game action depending on the TypeInput.
    /// </summary>
    /// <param name="inputType">
    /// An InputType that defines the action the player will be performing.
    /// </param>
    /// <returns>
    /// True if the InputType was PerformMove else false.
    /// </returns>
    private bool MoveCursor(InputType inputType) {
        bool rv = false;
        switch (inputType) {
            case InputType.Undefined:
                rv = false;
                break;
            case InputType.PerformMove:
                rv = true;
                break;
            case InputType.Exit:
                rv = false;
                Quit();
                break;
            case InputType.Up:
                rv = false;
                MoveUp();
                break;
            case InputType.Down:
                rv = false;
                MoveDown();
                break;
            case InputType.Right:
                rv = false;
                MoveRight();
                break;
            case InputType.Left:
                rv = false;
                MoveLeft();
                break;
        }
        return rv;
    }

    /// <summary>
    /// Method that will perform some game action depending on the TypeInput.
    /// </summary>
    /// <returns>
    /// The InputType enum that describes what action the player performed.
    /// </returns>
    public InputType GetMove() {
        return charToInputType.Convert(Console.ReadKey(true).KeyChar);
    }

    /// <summary>
    /// Method that will convert the internal position to a position in relation to the board.
    /// </summary>
    /// <param name="positionIn">
    /// Some position in relation to the cursor class.
    /// </param>
    /// <returns>
    /// The resulting position in relation to the board.
    /// </returns>
    private Position ToBoardPosition(Position positionIn) {
        return new Position(positionIn.Y, positionIn.X);
    }

    /// <summary>
    /// Sets the cursors console position.
    /// </summary>
    private void SetCursorPosition() => Console.SetCursorPosition(X + 1, Y + 1);

    /// <summary>
    /// Keeps retrieving an input until the player decides to perform that action.
    /// </summary>
    /// <returns>
    /// The players position when it has been decided.
    /// </returns>
    public Position ReceivePosition() {
        do {
            SetCursorPosition();
        } while (MoveCursor(GetMove()));

        return ToBoardPosition(position);
    }

}