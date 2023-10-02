namespace TrickOrTreatRPG;

public class Candy : IComparable<Candy>
{
    public string Name { get; }
    public int Points { get; }

    public Candy(string name, int points)
    {
        Name = name;
        Points = points;
    }
    
    public int CompareTo(Candy other)
    {
        if (other == null) return 1; // Null is considered greater.
        return Points.CompareTo(other.Points);
    }
    
}