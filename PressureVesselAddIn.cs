using System;

namespace SolidWorksAddIn
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the PressureVesselCreator class
            PressureVesselCreator pressureVesselCreator = new PressureVesselCreator();

            // Set example parameters for the pressure vessel
            double diameter = 1.0;
            double height = 2.0;
            double thickness = 0.1;
            string material = "AISI 1020 Steel";

            // Call the Create method to create the pressure vessel in SolidWorks
            pressureVesselCreator.Create(diameter, height, thickness, material);

            // Keep the console window open until a key is pressed
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}