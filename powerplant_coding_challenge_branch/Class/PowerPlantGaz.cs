namespace powerplant_coding_challenge_branch.Class;

public class PowerPlantGaz : IPowerPlant
{
    public string Name { get; set; }
    public string Type { get; set; }
    public double Efficiency { get; set; }
    public int Pmin { get; set; }
    public double Pmax { get; set; }
    public double MwHProducedPrice { get; set; }
    public double ToProduce { get; set; }

    public void CalculateKWHCost(double priceByUnit)
    {
        MwHProducedPrice = priceByUnit / Efficiency;
    }
}