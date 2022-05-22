using Grasshopper.Kernel;
using System;
using System.Drawing;

namespace DendroGH
{
    public class DendroGHInfo : GH_AssemblyInfo
    {
        public override string Name => "DendroGH";

        //Return a 24x24 pixel bitmap to represent this GHA library.
        public override Bitmap Icon => null;

        //Return a short string describing the purpose of this GHA library.
        public override string Description => "";

        public override Guid Id => new Guid("e355f38c-064c-4317-a17c-499c5a2fcded");

        //Return a string identifying you or your company.
        public override string AuthorName => "ecr labs";

        //Return a string representing your preferred contact details.
        public override string AuthorContact => "dev@ecrlabs.com";
    }
}