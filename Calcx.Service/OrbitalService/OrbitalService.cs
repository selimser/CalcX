using Calcx.Core;

namespace Calcx.Service.OrbitalService
{
    public class OrbitalService : IOrbitalService
    {
        public void TestMethod()
        {
            var massOrbitalPeriodSample = FormulaConstants.MercuryConstants.OrbitalPeriod;
            var result = massOrbitalPeriodSample - 1000;
        }
    }
}
