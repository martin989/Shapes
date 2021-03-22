using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Models
{

    /// <summary>
    /// Enum Describing for shape types
    /// </summary>
    public enum ShapeEnum
    { 
        Ellipse,
        Circle,
        Square,
        EquilateralTriangle,
        FreeformPolygon
    }

    public interface IShape
    {

        float Area { get; set; }
        float ShapeID { get; set; }
        float Perimeter { get; set; }
        float Orienation { get; set; }
        String Color { get; set; }
        ShapeEnum Type { get; set; }
        GraphicsPath Path { get; }
        void UpdatePath();

    }
}
