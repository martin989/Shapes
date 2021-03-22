using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Models
{
    public class EquilateralTriangle : IShape
    {
        #region Variables
        public float CenterX { get; set; }
        public float CenterY { get; set; }
        public float SideLength { get; set; }
        public float Orienation { get; set; }
        public float Area { get; set; }
        public float ShapeID { get; set; }
        public float Perimeter { get; set; }
        public String Color { get; set; }
        public ShapeEnum Type { get; set; }
        public GraphicsPath Path
        {
            get
            {
                return _path;
            }
        }
        private GraphicsPath _path;
        #endregion


        #region Constructor
        public EquilateralTriangle()
        {

        }

        /// <summary>
        /// Creates a Triangle with given parameters
        /// </summary>
        /// <param name="CenterX"></param>
        /// <param name="CenterY"></param>
        /// <param name="SideLength"></param>
        /// <param name="Orienation"></param>
        public EquilateralTriangle(float CenterX, float CenterY, float SideLength, float Orienation)
        {
            Update(CenterX, CenterY, SideLength, Orienation);          
        }
        #endregion


        #region Methods

        /// <summary>
        /// Updates Shape Object. Use later to change shape size.
        /// </summary>
        /// <param name="CenterX"></param>
        /// <param name="CenterY"></param>
        /// <param name="SideLength"></param>
        /// <param name="Orienation"></param>
        public void Update(float CenterX, float CenterY, float SideLength, float Orienation)
        {
            this.Type = ShapeEnum.EquilateralTriangle;
            this.CenterX = CenterX;
            this.CenterY = CenterY;
            this.SideLength = SideLength;
            this.Orienation = Orienation;

            this.Area = (float)(Math.Pow(SideLength, (float)2) * (Math.Sqrt(3) / 4));
            this.Perimeter = 3 * SideLength;
        }


        /// <summary>
        /// Creates graphics path of shape
        /// </summary>
        public void UpdatePath()
        {
            PointF[] curvePoints = new PointF[3];
            curvePoints[0].X = CenterX;
            curvePoints[0].Y = CenterY + (SideLength / 2);
            curvePoints[1].X = CenterX + (SideLength / 2);
            curvePoints[1].Y = CenterY - (SideLength / 2);
            curvePoints[2].X = CenterX - (SideLength / 2);
            curvePoints[2].Y = CenterY - (SideLength / 2);
            _path = new GraphicsPath();
            _path.AddPolygon(curvePoints);
        }
#endregion
    }
}

