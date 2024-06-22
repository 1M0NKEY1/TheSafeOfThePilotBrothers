namespace TheSafeOfThePilotBrothers.Models;

public class LeverModel
{
    private int[,] _lever;

    private void RandomArray()
    {
        var rnd = new Random();
        for (var i = 0; i < _lever.GetLength(0); i++)
        {
            for (var j = 0; j < _lever.GetLength(1); j++)
            {
                _lever[i, j] = rnd.Next(2);
            }
        }
    }

    public LeverModel(int rows, int cols)
    {
        _lever = new int[rows, cols];
        RandomArray();
    }

    public void Resize(int newRows, int newCols)
    {
        var tmpLever = new int[newRows, newCols];
        var rows = Math.Min(newRows, _lever.GetLength(0));
        var cols = Math.Min(newCols, _lever.GetLength(1));

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                tmpLever[i, j] = _lever[i, j];
            }
        }

        _lever = tmpLever;
    }

    // Can be without else if, only else
    public void ToggleCell(int row, int col)
    {
        if (_lever[row, col] == 1)
        {
            _lever[row, col] = 0;
        }
        else if (_lever[row, col] == 0)
        {
            _lever[row, col] = 1;
        }
    }

    public void ToggleFullRow(int row)
    {
        for (var i = 0; i < _lever.GetLength(1); i++)
        {
            if (_lever[row, i] == 1)
            {
                _lever[row, i] = 0;
            }
            else if (_lever[row, i] == 0)
            {
                _lever[row, i] = 1;
            }
        }
    }

    public void ToggleFullCol(int col)
    {
        for (var i = 0; i < _lever.GetLength(0); i++)
        {
            if (_lever[i, col] == 1)
            {
                _lever[i, col] = 0;
            }
            else if (_lever[i, col] == 0)
            {
                _lever[i, col] = 1;
            }
        }
    }

    public int[,] GetArray()
    {
        return _lever;
    }
}