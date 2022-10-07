using System.Collections;
using System.Security.AccessControl;

namespace Genialita;

public class Capek
{
    private string Jmeno;
    private double MaxHP;
    private double RnHP;
    private Klacek Tool;
    private List<Kolecek> Gear;
    private double DmgMultiplier = 1;
    private double DmgReduction = 1;


    public Capek(string jmeno, double maxhp, Klacek tool)
    {
        this.Jmeno = jmeno;
        this.MaxHP = this.RnHP = maxhp;
        this.Tool = tool;
        Gear = new List<Kolecek>();
    }

    public Capek(string jmeno, double maxhp, double rnhp, Klacek tool)
    {
        this.Jmeno = jmeno;
        this.MaxHP = maxhp;
        this.RnHP = rnhp;
        this.Tool = tool;
        Gear = new List<Kolecek>();

        if (rnhp > maxhp)
            Console.WriteLine("WARN: " + jmeno + "'s rnhp (" + rnhp + ") is larger than its maxhp (" + maxhp + ")");
    }

    public void bol(double boleni)
    {
        this.RnHP -= boleni * DmgReduction;
    }

    public void mlat(Capek tenDruhej)
    {
        this.bol(tenDruhej.Tool.GetBolest()*this.DmgMultiplier);
        tenDruhej.bol(this.Tool.GetBolest()*tenDruhej.DmgMultiplier);
    }

    public void nasaditRing(Kolecek k)
    {
        this.Gear.Add(k);
        switch (k.CoSiZac())
        {
            case Kolecek.Bonus.DMGREDUCTION:
                DmgReduction *= k.Silnost();
                break;
            case Kolecek.Bonus.HPMULTIPLIER:
                MaxHP *= k.Silnost();
                RnHP *= k.Silnost();
                break;
            case Kolecek.Bonus.DMGMULTIPLIER:
                DmgMultiplier *= k.Silnost();
                break;
        }
    }

    public void SundatRing(Kolecek k)
    {
        if (this.Gear.Remove(k))
            switch (k.CoSiZac())
            {
                case Kolecek.Bonus.DMGREDUCTION:
                    DmgReduction /= k.Silnost();
                    break;
                case Kolecek.Bonus.HPMULTIPLIER:
                    MaxHP /= k.Silnost();
                    RnHP /= k.Silnost();
                    break;
                case Kolecek.Bonus.DMGMULTIPLIER:
                    DmgMultiplier /= k.Silnost();
                    break;
            }
    }

    public void SundatRing(int pos)
    {
        Kolecek k = this.Gear[pos];
        this.Gear.RemoveAt(pos);
        switch (k.CoSiZac())
        {
            case Kolecek.Bonus.DMGREDUCTION:
                DmgReduction /= k.Silnost();
                break;
            case Kolecek.Bonus.HPMULTIPLIER:
                MaxHP /= k.Silnost();
                RnHP /= k.Silnost();
                break;
            case Kolecek.Bonus.DMGMULTIPLIER:
                DmgMultiplier /= k.Silnost();
                break;
        }
    }

    public bool Umrels()
    {
        return this.RnHP <= 0;
    }
}