using Calcx.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace Calcx.Core.Constants
{
    public class AstronomicalConstants
    {
        public struct GeneralConstants
        {
            public const double GaussianGravitationalConstant = 0.01720209895D;
            public const int AstronomicalUnit_AU = 149_597_871;
            public const double SpeedOfLightInVacuum = 299_792.458D;
            public const double DynamicalFormFactor_J2_ForEarth = 0.001082636D;
            public const double ProductOfGravitationalConstantAndEarthMass = 398_600.5D;
            public const double EarthToMoonMassRatio = 81.3006D;
            public const double MoonsSiderealMeanMotion = 0.00000266169D; //2.661699489x10^-6 radians s^-1
            public static DegreeMinuteSecond ObliquityOfTheEcliptic = new DegreeMinuteSecond
            {
                Degrees = 23D,
                Minutes = 26D,
                Seconds = 21.448D
            };
            public const double ConstantOfNutationInObliquity_J2000 = 9.2052331D;
            public const double SolarParallax = 8.794143D;
            public const double LightTimeForUnitDistance = 499.004784D;
            public const double ConstantOfAbberation = 20.49551D;
            public const double MeanDistanceOfEarthToMoon = 384_400D;
            public const double ConstantOfSineMoonsParallax = 3422.451D;
            public const double LunarInequality = 6.43987D;
            public const double ParallacticInequality = 124.986D;
        }

        public struct GeneralConstantsUnitsInLaTeX
        {
            public const string GaussianGravitationalConstant = "";
            public const string AstronomicalUnit_AU = "";
            public const string SpeedOfLightInVacuum = "";
            public const string DynamicalFormFactor_J2_ForEarth = "";
            public const string ProductOfGravitationalConstantAndEarthMass = "";
            public const string EarthToMoonMassRatio = "";
            public const string MoonsSiderealMeanMotion = "";
            public const string ObliquityOfTheEcliptic = "";
            public const string ConstantOfNutationInObliquity_J2000 = "";
            public const string SolarParallax = "";
            public const string LightTimeForUnitDistance = "";
            public const string ConstantOfAbberation = "";
            public const string MeanDistanceOfEarthToMoon = "";
            public const string ConstantOfSineMoonsParallax = "";
            public const string LunarInequality = "";
            public const string ParallacticInequality = "";
        }
    }
}
