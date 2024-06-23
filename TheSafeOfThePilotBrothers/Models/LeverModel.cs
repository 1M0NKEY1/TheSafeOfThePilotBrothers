namespace TheSafeOfThePilotBrothers.Models;

public class LeverModel
{
    private int[,] _lever;
    private const int StartSize = 4;
    
    private void RandomArray()
    {
        while (true)
        {
            var rnd = new Random();
            var counterAll1 = 0;
            var counterAll0 = 0;
            for (var i = 0; i < _lever.GetLength(0); i++)
            {
                for (var j = 0; j < _lever.GetLength(1); j++)
                {
                    _lever[i, j] = rnd.Next(2);
                    if (_lever[i, j] == 1)
                    {
                        counterAll1++;
                    }
                    else if (_lever[i, j] == 0)
                    {
                        counterAll0++;
                    }
                }
            }

            if (counterAll1 == _lever.GetLength(0) * _lever.GetLength(1) || counterAll0 == _lever.GetLength(0) * _lever.GetLength(1))
            {
                continue;
            }

            break;
        }
    }

    public LeverModel()
    {
        _lever = new int[StartSize, StartSize];
        RandomArray();
    }

    public void Resize(int newRows, int newCols)
    {
        _lever = new int[newRows, newCols];
        RandomArray();
    }

    
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