using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace SolidWorksAddIn
{
    public class PressureVesselCreator
    {
        public void Create(double diameter, double height, double thickness, string material)
        {
            // Connect to SolidWorks API and create a new instance
            SldWorks swApp = new SldWorks();
            swApp.Visible = true;
            swApp.NewPart();

            // Set up the necessary configurations
            PartDoc swPart = (PartDoc)swApp.ActiveDoc;
            ModelDoc2 swModel = (ModelDoc2)swApp.ActiveDoc;

            // Create the cylindrical body
            swModel.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swModel.SketchManager.InsertSketch(true);
            swModel.SketchManager.CreateCircle(0, 0, 0, diameter / 2, 0, 0);
            swModel.SketchManager.InsertSketch(true);
            swModel.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, height, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, false, 0, 0, false);

            // Create the first end cap
            swModel.Extension.SelectByID2("Top Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swModel.SketchManager.InsertSketch(true);
            swModel.SketchManager.CreateCircle(0, 0, 0, diameter / 2 + thickness, 0, 0);
            swModel.SketchManager.InsertSketch(true);
            swModel.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, thickness, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, false, 0, 0, false);

            // Create the second end cap
            swModel.Extension.SelectByID2("Bottom Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swModel.SketchManager.InsertSketch(true);
            swModel.SketchManager.CreateCircle(0, 0, 0, diameter / 2 + thickness, 0, 0);
            swModel.SketchManager.InsertSketch(true);
            swModel.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, thickness, 0, false, false, false, false, 0, 0, false, false, false, false, true, true, false, 0, 0, false);

            // Set material
            swPart.SetMaterialPropertyName2("Default", "", material);

            // Save the part
            string partFileName = $"PressureVessel_{diameter}_{height}_{thickness}_{material}.SLDPRT";
            int errors = 0;
            int warnings = 0;
            swModel.SaveAs4(partFileName, (int)swSaveAsVersion_e.swSaveAsCurrentVersion, (int)swSaveAsOptions_e.swSaveAsOptions_Silent, ref errors, ref warnings);

        }
    }
}
