namespace Genialita;

public class Kolecek
{
    private string Jmeno;
    private Bonus Boost;
    private double Power;

    public Kolecek(string jmeno, Bonus bonus, double power)
    {
        this.Jmeno = jmeno;
        this.Boost = bonus;
        this.Power = power;
    }

    public Bonus CoSiZac()
    {
        return this.Boost;
    }

    public double Silnost()
    {
        return this.Power;
    }
    
    public enum Bonus
    {
        HPMULTIPLIER, DMGMULTIPLIER, DMGREDUCTION
    }
}