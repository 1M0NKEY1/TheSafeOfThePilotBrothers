namespace TheSafeOfThePilotBrothers.Models;

public class LeverModel
{
    public int[,] LeverArray { get; set; }

    public int GetSize(int dimension)
    {
        return LeverArray.GetLength(dimension);
    }
}