namespace TheSafeOfThePilotBrothers.Models;

public class LeverModel
{
    private int[,] _lever;
    private const int StartSize = 4;
    
    // сделать просто рандомное количество смен крестовин, но при этом начальная сетка будет с заполненым крайним рядом
    // и столбцом, только нужно продумать как должны крестовины вызываться, чтобы распутать
    private void RandomEvenArray()
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

            if (counterAll1 == _lever.GetLength(0) * _lever.GetLength(1)
                || counterAll0 == _lever.GetLength(0) * _lever.GetLength(1))
            {
                continue;
            }

            break;
        }
    }

    private void RandomOddArray()
    {
        var rnd = new Random();
        var size = _lever.GetLength(0);
        
        var usedCols = new bool[size];

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                _lever[i, j] = 0;
            }
        }

        for (int i = 0; i < size; i++)
        {
            var col = rnd.Next(0, size);
            while (true)
            {
                if (usedCols[col])
                {
                    col = rnd.Next(0, size);
                }
                else if (!usedCols[col])
                {
                    break;
                }
            }
            usedCols[col] = true;
            
            _lever[col, i] = 1;
        }
    }

    public LeverModel()
    {
        _lever = new int[StartSize, StartSize];
        if (_lever.GetLength(0) % 2 == 0)
        {
            RandomEvenArray();
        }
        
        RandomOddArray();
    }

    public void Resize(int newRows, int newCols)
    {
        _lever = new int[newRows, newCols];
        if (newRows % 2 == 0)
        {
            RandomEvenArray();
        }
        
        RandomOddArray();
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