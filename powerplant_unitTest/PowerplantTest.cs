using powerplant_coding_challenge_branch.Class;

namespace powerplant_unitTest
{
    public class PowerplantTest
    {
        [Fact]
        public void PowerplantGasTestEfficiencyOneDecimal()
        {
            var powerPlantGas = new PowerPlantGaz();
            powerPlantGas.Efficiency = 0.5;
            var rawPriceMwH = 10;
            powerPlantGas.CalculateKWHCost(rawPriceMwH);

            Assert.Equal(powerPlantGas.MwHProducedPrice, 20);
        }

        [Fact]
        public void PowerplantGasTestEfficiencyTwoDecimal()
        {
            var powerPlantGas = new PowerPlantGaz();
            powerPlantGas.Efficiency = 0.53;
            var rawPriceMwH = 10;
            powerPlantGas.CalculateKWHCost(rawPriceMwH);

            Assert.Equal(Math.Round(powerPlantGas.MwHProducedPrice, 2), 18.87);
        }
    }
}