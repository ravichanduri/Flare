using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlareTest.Model
{
    public class Grid : IRectangle
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public ShapeTypes ShapeType { get { return ShapeTypes.Grid; } }
    }
}
