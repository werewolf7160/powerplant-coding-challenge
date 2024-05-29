using Newtonsoft.Json;

namespace powerplant_coding_challenge_branch.Class;

public class Powerplant
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("efficiency")]
    public double Efficiency { get; set; }

    [JsonProperty("pmin")]
    public int Pmin { get; set; }

    [JsonProperty("pmax")]
    public double Pmax { get; set; }

    [JsonIgnore] public double KwHPrice { get; set; }
    [JsonIgnore] public double ToProduce { get; set; } = 0.0;
}