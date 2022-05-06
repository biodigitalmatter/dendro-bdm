using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace DendroGH.Components
{
    public class GetValueAtPt : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public GetValueAtPt()
          : base("Get voxel value at point", "GetValueAtPt",
              "Get interpolated voxel value at point.",
            "Dendro", "Analysis")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Volume", "V", "Volume geometry", GH_ParamAccess.item);
            pManager.AddPointParameter("Point", "P", "Point to evaluate", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
              pManager.AddNumberParameter("Voxel value", "w", "Voxel value at point", GH_ParamAccess.item);

        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            DendroVolume volume = new DendroVolume();
            Point3d pt = new Point3d();

            if (!DA.GetData(0, ref volume)) return;
            if (!DA.GetData(1, ref pt)) return;

            double value = volume.GetValueAtPt(pt);

            DA.SetData(0, value);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("516439CC-D95A-4D1D-A0E1-229BDDEEA8E8"); }
        }
    }
}