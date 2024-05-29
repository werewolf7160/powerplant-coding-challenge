using Newtonsoft.Json;

namespace powerplant_coding_challenge_branch.Class;

public class DataWrapper
{
    [JsonProperty("load")]
    public double Load { get; set; }

    [JsonProperty("fuels")]
    public FuelPrice FuelPrice { get; set; }

    [JsonProperty("powerplants")]
    public List<Powerplant> Powerplants { get; set; }
}