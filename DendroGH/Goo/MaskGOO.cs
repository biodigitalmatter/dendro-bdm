﻿using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using Rhino.Geometry;
using System;

namespace DendroGH
{
    /// <summary>
    /// goo implementation for DendroMask data types
    /// </summary>
    /// <typeparam name="DendroMask">mask object</typeparam>
    public class MaskGOO : GH_GeometricGoo<DendroMask>, IGH_BakeAwareData, IGH_PreviewData
    {
        #region Constructors
        /// <summary>
        /// default constructor
        /// </summary>
        public MaskGOO()
        {
            this.Value = new DendroMask();
        }

        /// <summary>
        /// copy constructor
        /// </summary>
        /// <param name="vMask">mask to copy from</param>
        public MaskGOO(DendroMask vMask)
        {
            if (vMask == null)
            {
                vMask = new DendroMask();
            }
            this.Value = new DendroMask(vMask);
        }

        /// <summary>
        /// make a complete duplicate of this instance
        /// </summary>
        /// <returns>duplicated MaskGOO</returns>
        public MaskGOO DuplicateGoo()
        {
            if (this.Value == null)
            {
                return new MaskGOO();
            }
            else
            {
                DendroMask mask = new DendroMask(Value);
                return new MaskGOO(mask);
            }
        }

        /// <summary>
        /// make a complete duplicate of this instance
        /// </summary>
        /// <returns>duplicated MaskGOO</returns>
        public override IGH_Goo Duplicate()
        {
            return DuplicateGoo();
        }

        /// <summary>
        /// make a complete duplicate of this geometry
        /// </summary>
        /// <returns>duplicated MaskGOO</returns>
        public override IGH_GeometricGoo DuplicateGeometry()
        {
            return DuplicateGoo();
        }
        #endregion

        #region Properties
        /// <summary>
        /// gets a value indicating whether or not the current value is valid
        /// </summary>
        /// <returns>property value</returns>
        public override bool IsValid
        {
            get
            {
                if (Value == null) { return false; }
                return Value.IsValid;
            }
        }

        /// <summary>
        /// gets a string describing the state of "invalidness". if the instance is valid, then this property should return Nothing or String.Empty
        /// </summary>
        /// <returns>property value</returns>
        public override string IsValidWhyNot
        {
            get
            {
                if (Value.IsValid)
                {
                    return "Dendro Mask is valid";
                }
                else
                {
                    return "Dendro Mask is not valid";
                }
            }
        }

        /// <summary>
        /// creates a string description of the current instance value
        /// </summary>
        /// <returns>property value</returns>
        public override string ToString()
        {
            if (Value == null)
                return "Invalid Dendro Mask";
            else return "Dendro Mask";
        }

        /// <summary>
        /// gets a description of the type of the implementation
        /// </summary>
        /// <returns>property value</returns>
        public override string TypeDescription
        {
            get { return ("Container for Dendro Masks"); }
        }

        /// <summary>
        /// gets the name of the type of the implementation
        /// </summary>
        /// <returns>property value</returns>
        public override string TypeName
        {
            get { return "Dendro Mask"; }
        }

        /// <summary>
        /// gets the world axis aligned boundingbox for the mask
        /// </summary>
        /// <returns>boundingbox of the geometry in world coordinates or BoundingBox.Empty if not bounding box could be found</returns>
        public override BoundingBox Boundingbox
        {
            get
            {
                return Value.GetBoundingBox();
            }
        }

        /// <summary>
        /// gets the world axis aligned boundingbox for the transformed mask
        /// </summary>
        /// <param name="xform">transformation to apply to object prior to the bounding box computation</param>
        /// <returns>accurate boundingbox of the transformed geometry in world coordinates or BoundingBox.Empty if not bounding box could be found</returns>
        public override BoundingBox GetBoundingBox(Transform xform)
        {
            return Value.GetBoundingBox(xform);
        }

        /// <summary>
        /// bake an object in the given rhino document
        /// </summary>
        /// <param name="doc">document to bake into</param>
        /// <param name="att">attributes to bake with (should not be null)</param>
        /// <param name="obj_guid">the id of the baked object</param>
        /// <returns>true on success. ifalse, obj_guid and obj_inst are not guaranteed to be valid pointers</returns>
        public bool BakeGeometry(Rhino.RhinoDoc doc, Rhino.DocObjects.ObjectAttributes att, out Guid obj_guid)
        {
            obj_guid = Guid.Empty;

            if (Value == null)
                return false;

            if (!Value.IsValid)
                return false;

            doc.Objects.AddMesh(Value.Display);

            return true;
        }
        #endregion

        #region Casting
        /// <summary>
        /// this function will be called when the local IGH_Goo instance disappears into a user script
        /// </summary>
        /// <returns>returns the DendroMask instance</returns>
        public override object ScriptVariable()
        {
            return Value;
        }

        /// <summary>
        /// attempt a cast to type Q
        /// </summary>
        /// <param name="target">pointer to target of cast</param>
        /// <typeparam name="Q">type to cast to</typeparam>
        /// <returns>true on success, false on failure</returns>
        public override bool CastTo<Q>(out Q target)
        {
            if (typeof(Q).IsAssignableFrom(typeof(DendroMask)))
            {
                if (Value == null)
                    target = default(Q);
                else
                    target = (Q)(object)Value;
                return true;
            }
            target = default(Q);
            return false;
        }

        /// <summary>
        /// attempt a cast from generic object
        /// </summary>
        /// <param name="source">reference to source of cast</param>
        /// <returns>true on success, false on failure</returns>
        public override bool CastFrom(object source)
        {
            return false;
        }
        #endregion

        #region Transformation
        /// <summary>
        /// transforms the object or a deformable representation of the object
        /// </summary>
        /// <param name="xform">transformation matrix</param>
        /// <returns>transformed geometry</returns>
        public override IGH_GeometricGoo Transform(Transform xform)
        {
            DendroMask mask = new DendroMask(Value);

            mask.Transform(xform);

            return new MaskGOO(mask);
        }

        /// <summary>
        /// morph the object or a deformable representation of the object
        /// </summary>
        /// <param name="xmorph">spatial deform</param>
        /// <returns>deformed geometry</returns>
        public override IGH_GeometricGoo Morph(SpaceMorph xmorph)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Display
        /// <summary>
        /// gets the clipping box for this data
        /// </summary>
        /// <returns>clipping box for this object</returns>
        public BoundingBox ClippingBox
        {
            get
            {
                return Value.GetBoundingBox();
            }
        }

        /// <summary>
        /// draw all wire and point previews
        /// </summary>
        public void DrawViewportWires(GH_PreviewWireArgs args)
        {

        }

        /// <summary>
        /// draw all shaded meshes
        /// </summary>
        public void DrawViewportMeshes(GH_PreviewMeshArgs args)
        {

            if (Value == null)
                return;

            if (args.Pipeline.SupportsShading)
            {
                var c = args.Material.Diffuse;
                c = System.Drawing.Color.FromArgb((int)(args.Material.Transparency * 255), c);

                args.Pipeline.DrawMeshShaded(Value.Display, args.Material);
            }
        }
        #endregion

    }
}