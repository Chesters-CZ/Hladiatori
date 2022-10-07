using System.Text;
using Genialita;

string RandomBullshit(int wordSize)
{
    string ven = "";
    StringBuilder borek = new StringBuilder();
    Random random = new Random();

    borek.Append((char)(random.NextDouble() * (90 - 65) + 65));
    for (int j = 0; j < wordSize; j++)
    {
        borek.Append((char)(random.NextDouble() * (122 - 97) + 97));
    }

    ven = borek.ToString();

    return ven;
}

Random random = new Random();
Capek jedna = new Capek(RandomBullshit(8), (random.NextDouble() * (1000 - 100) + 100), new Klacek(RandomBullshit(8),random.NextDouble() * (100 - 10) + 10,random.NextDouble() * (250 - 101) + 101));
Capek dva = new Capek(RandomBullshit(8), (random.NextDouble() * (1000 - 100) + 100), new Klacek(RandomBullshit(8),random.NextDouble() * (100 - 10) + 10,random.NextDouble() * (250 - 101) + 101));
jedna.nasaditRing(new Kolecek(RandomBullshit(8), Kolecek.Bonus.DMGREDUCTION, 0.5));
dva.nasaditRing(new(RandomBullshit(8), Kolecek.Bonus.DMGMULTIPLIER, 0.5));

while (!jedna.Umrels() || !dva.Umrels())
{
    jedna.mlat(dva);
}

