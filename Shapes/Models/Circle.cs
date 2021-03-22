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
    public class Circle : IShape
    {
        #region Variables
        public float CenterX { get; set; }
        public float CenterY { get; set; }
        public float Radius { get; set; }
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
        public float Orienation { get; set; }
        private GraphicsPath _path;
        #endregion


        #region Constructor
        public Circle()
        {
        }


        /// <summary>
        /// Creates a Circle with given parameters
        /// </summary>
        /// <param name="CenterX"></param>
        /// <param name="CenterY"></param>
        /// <param name="Radius"></param>
        public Circle(float CenterX, float CenterY, float Radius)
        {
            Update(CenterX, CenterY, Radius);
            this.Color = Color;
        }
        #endregion


        #region Methods

        /// <summary>
        /// Updates Shape Object. Use later to change shape size.
        /// </summary>
        /// <param name="CenterX"></param>
        /// <param name="CenterY"></param>
        /// <param name="Radius"></param>
        public void Update(float CenterX, float CenterY, float Radius)
        {
            this.Type = ShapeEnum.Circle;
            this.CenterX = CenterX;
            this.CenterY = CenterY;
            this.Radius = Radius;
            this.Orienation = Orienation;
            this.Area = (float)(Math.PI * Math.Pow(Radius, 2));
            this.Perimeter = (float)(2 * Math.PI * Radius);
        }


        /// <summary>
        /// Creates graphics path of shape
        /// </summary>
        public void UpdatePath()
        {
            RectangleF r = new RectangleF(CenterX, CenterY, Radius, Radius);
            _path = new GraphicsPath();
            _path.AddEllipse(r);
        }
        #endregion
    }
}
