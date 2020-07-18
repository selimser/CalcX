namespace Calcx.Core
{
    public sealed class FormulaConstants
    {
        public struct MercuryConstants
        {
            public const string Epoch = "J2000";
            /// <summary>
            /// Unit is in kilometres
            /// </summary>
            public const float Aphelion = 69_816_900f;

            /// <summary>
            /// Unit is in kilometres
            /// </summary>
            public const float Perihelion = 46_001_200f;

            /// <summary>
            /// Unit is in kilometres
            /// </summary>
            public const float SemiMajorAxis = 57_909_050f;

            /// <summary>
            /// Unit is in days
            /// </summary>
            public const float OrbitalPeriod = 87.9691f;

            /// <summary>
            /// Unit is in days
            /// </summary>
            public const float SynodicPeriod = 115.88f;

            /// <summary>
            /// Unit is in km/s
            /// </summary>
            public const float AverageOrbitalSpeed = 47.362f;

            /// <summary>
            /// Unit is in degrees
            /// </summary>
            public const float MeanAnomaly = 174.796f;

            /// <summary>
            /// Unit is in kilometres
            /// </summary>
            public const float MeanDiameter = 4880f;

            /// <summary>
            /// Unit is in kilometres, ±1.0 km
            /// </summary>
            public const float MeanRadius = 2439.7f;

            /// <summary>
            /// Unit is in kilometre squared
            /// </summary>
            public const float SurfaceArea = 74_800_000f;

            /// <summary>
            /// Unit is in kilometre cubed
            /// </summary>
            public const float Volume = 60_830_000_000f;

            /// <summary>
            /// Unit is in kilograms
            /// </summary>
            public const double Mass = 3.3011e+23d;

            /// <summary>
            /// Unit is in g/cm^3
            /// </summary>
            public const float MeanDensity = 5.427f;

            /// <summary>
            /// Unit is in m/s^2
            /// </summary>
            public const float SurfaceGravity = 3.7f;

            /// <summary>
            /// Unit is in g-force
            /// </summary>
            public const float SurfaceGravityInG = 0.38f;

            /// <summary>
            /// Unit is in km/s
            /// </summary>
            public const float EscapeVelocity = 4.25f;

            /// <summary>
            /// Unit is in km/h
            /// </summary>
            public const float EquatorialRotationVelocity = 10.892f;
        }
    }
}
