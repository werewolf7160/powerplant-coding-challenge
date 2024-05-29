namespace powerplant_coding_challenge_branch.Class;

public class PowerPlantResolver
{
    public List<PowerListElement> ResolvePowerPlant(List<Powerplant> powerplants, FuelPrice fuel, double load)
    {
        foreach (var powerplant in powerplants)
        {
            CalculateCost(powerplant, fuel);
        }

        return PlanningProduction(powerplants, load);
    }

    /// <summary>
    /// calculate cost based 
    /// </summary>
    /// <param name="powerplant"></param>
    /// <param name="fuel"></param>
    private void CalculateCost(Powerplant powerplant, FuelPrice fuel)
    {
        switch (powerplant.Type)
        {
            case "gasfired":
                powerplant.KwHPrice = fuel.Gas / (powerplant.Efficiency);
                break;
            case "turbojet":
                powerplant.KwHPrice = fuel.Kerosine / (powerplant.Efficiency);
                break;
            case "windturbine":
                powerplant.KwHPrice = 0;
                powerplant.Pmax =(powerplant.Pmax * (fuel.Wind / 100));
                break;
        }
    }

    private List<PowerListElement> PlanningProduction(List<Powerplant> powerplants, double load)
    {
        powerplants = powerplants.OrderBy(x => x.KwHPrice).ThenByDescending(x => x.Pmax).ToList();

        var toUses = new List<Powerplant>();
        var notUses = new List<Powerplant>();
        var toCompletes = new List<Powerplant>();

        var baseLoad = load;

        foreach (var pp in powerplants)
        {
            if (pp.Pmin < load && pp.Pmax >= load && pp.Pmax > 0)
            {
                toUses.Add(pp);
                load -= load > pp.Pmax ? pp.Pmax : load;
            }
            else
            {
                notUses.Add(pp);
            }
        }

        if (load > 0)
        {
            var tmpNotUses = new List<Powerplant>();
            tmpNotUses.AddRange(notUses);
            foreach (var pp in tmpNotUses)
            {
                if (pp.Pmin < baseLoad && pp.Pmax >= baseLoad && pp.Pmax > 0)
                {
                    toCompletes.Add(pp);
                    notUses.Remove(pp);
                    break;
                }
            }
        }

        return CalculateProduction(load, powerplants, toUses, toCompletes);
    }

    private List<PowerListElement> CalculateProduction
    (
        double load,
        List<Powerplant> toUses, 
        List<Powerplant> toCompletes, 
        List<Powerplant> notUses
    )
    {
        //if something in complete it's for case payload2 (sum of max powerplant (not all) < all min)
        foreach (var pp in toCompletes)
        {
            pp.ToProduce = pp.Pmin;
        }

        foreach (var pp in toUses)
        {
            pp.ToProduce = pp.Pmax < load ? pp.Pmax : load;
            load -= pp.ToProduce;
        }
        
        var completeList = new List<Powerplant>();
        completeList.AddRange(toUses);
        completeList.AddRange(toCompletes);
        completeList.AddRange(notUses);

        completeList = completeList.OrderBy(x => x.KwHPrice).ThenByDescending(x => x.Pmax).ToList();

        var powerList = new List<PowerListElement>();

        foreach (var pp in completeList)
        {
            powerList.Add(new PowerListElement(pp.Name, Math.Round(pp.ToProduce,1)));
        }

        return powerList;
    }

}