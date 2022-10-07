namespace Genialita;

public class Klacek
{
    private string Jmeno;
    private double MinRoll;
    private double MaxRoll;

    public Klacek(string jmeno, double min, double max)
    {
        this.Jmeno = jmeno;
        this.MinRoll = min;
        this.MaxRoll = max;
        
        if (min > max)
            Console.WriteLine("WARN: " + jmeno + "'s minroll (" + min + ") is larger than its maxroll (" + max + ")");
    }

    public double GetBolest()
    {
        return new Random().NextDouble() * (MaxRoll - MinRoll) + MinRoll;
    }
}