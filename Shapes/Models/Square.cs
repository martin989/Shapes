using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Shapes.Models
{
    public class Square : IShape
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
        public Square()
        {

        }

        /// <summary>
        /// Creates a Square with given parameters
        /// </summary>
        /// <param name="CenterX"></param>
        /// <param name="CenterY"></param>
        /// <param name="SideLength"></param>
        /// <param name="Orienation"></param>
        public Square(float CenterX, float CenterY, float SideLength, float Orienation)
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
            this.Type = ShapeEnum.Square;
            this.CenterX = CenterX;
            this.CenterY = CenterY;
            this.SideLength = SideLength;
            this.Orienation = Orienation;
            this.Area = (float)Math.Pow(SideLength, (float)2);
            this.Perimeter = this.SideLength * 4;
        }

        /// <summary>
        /// Creates graphics path of shape
        /// </summary>
        public void UpdatePath()
        {
            _path = new GraphicsPath();
            RectangleF r = new RectangleF(CenterX, CenterY, SideLength / 2, SideLength / 2);
            _path.AddRectangle(r);
        }
        #endregion
    }
}

