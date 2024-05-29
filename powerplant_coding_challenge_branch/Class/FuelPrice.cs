using Newtonsoft.Json;

namespace powerplant_coding_challenge_branch.Class;

public class FuelPrice
{
    [JsonProperty("gas(euro/MWh)")]
    public double Gas { get; set; }

    [JsonProperty("kerosine(euro/MWh)")]
    public double Kerosine { get; set; }

    [JsonProperty("co2(euro/ton)")]
    public double Co2 { get; set; }

    [JsonProperty("wind(%)")]
    public double Wind { get; set; }
}