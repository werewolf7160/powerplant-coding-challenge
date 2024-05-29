namespace powerplant_coding_challenge_branch.Class;

public class PowerListElement
{
    public string Name { get; set; }

    public double P { get; set; }

    public PowerListElement(string name, double p)
    {
        Name = name;
        P = p;
    }
}