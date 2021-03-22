using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Models
{
    public class Ellipse : IShape
    {
        #region Variables
        public float CenterX { get; set; }
        public float CenterY { get; set; }
        public float Radius1 { get; set; }
        public float Radius2 { get; set; }
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
        public Ellipse()
        {

        }

        /// <summary>
        /// Creates a Ellipse with given parameters
        /// </summary>
        /// <param name="CenterX"></param>
        /// <param name="CenterY"></param>
        /// <param name="Radius1"></param>
        /// <param name="Radius2"></param>
        /// <param name="Orienation"></param>
        public Ellipse(float CenterX, float CenterY, float Radius1, float Radius2, float Orienation)
        {
            Update(CenterX, CenterY, Radius1, Radius2, Orienation);
        }
        #endregion


        #region Methods
        /// <summary>
        /// Updates Shape Object. Use later to change shape size.
        /// </summary>
        /// <param name="CenterX"></param>
        /// <param name="CenterY"></param>
        /// <param name="Radius1"></param>
        /// <param name="Radius2"></param>
        /// <param name="Orienation"></param>
        public void Update(float CenterX, float CenterY, float Radius1, float Radius2, float Orienation)
        {
            this.Type = ShapeEnum.Ellipse;
            this.CenterX = CenterX;
            this.CenterY = CenterY;
            this.Radius1 = Radius1;
            this.Radius2 = Radius2;
            this.Orienation = Orienation;
            this.Area = (float)(Math.PI * this.Radius1 * this.Radius2);
            this.Perimeter = (float)(Math.PI * (3 * (this.Radius1 + this.Radius2) - Math.Sqrt((this.Radius1 + (3 * this.Radius2)) * (this.Radius2 + (3 * this.Radius1)))));
        }


        /// <summary>
        /// Creates graphics path of shape
        /// </summary>
        public void UpdatePath()
        {
            _path = new GraphicsPath();
            _path.AddEllipse(CenterX, CenterY, Radius1, Radius2); ;
        }
        #endregion
    }
}

