using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Models
{
    public class FreeFormPolygon : IShape
    {
        #region Variables
        public List<float> VerticesX { get; set; }
        public List<float> VerticesY { get; set; }
        public float Area { get; set; }
        public float ShapeID { get; set; }
        public float Perimeter { get; set; }
        public String Color { get; set; }
        public ShapeEnum Type { get; set; }
        public float Orienation { get; set; }
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
        public FreeFormPolygon()
        {

        }

        /// <summary>
        /// Creates a Polygon with given parameters
        /// </summary>
        /// <param name="VerticesX"></param>
        /// <param name="VerticesY"></param>
        public FreeFormPolygon(List<float> VerticesX, List<float> VerticesY)
        {
            this.Type = ShapeEnum.FreeformPolygon;
            this.Orienation = 0;
            Update(VerticesX, VerticesY);
        }
        #endregion


        #region Methods


        /// <summary>
        /// Updates Shape Object. Use later to change shape size.
        /// </summary>
        /// <param name="VerticesX"></param>
        /// <param name="VerticesY"></param>
        public void Update(List<float> VerticesX, List<float> VerticesY)
        {
            this.VerticesX = VerticesX;
            this.VerticesY = VerticesY;
            PointF[] curvePoints = new PointF[VerticesX.Count];
            for (int i = 0; i < VerticesX.Count - 1; i++)
            {
                curvePoints[i].X = VerticesX[i];
                curvePoints[i].Y = VerticesY[i];
            }
            this.Area = Math.Abs(curvePoints.Take(curvePoints.Length - 1).Select((p, i) => (curvePoints[i + 1].X - p.X) * (curvePoints[i + 1].Y + p.Y)).Sum() / 2);
            this.Area = 0.0F;
            int endPoints = curvePoints.Length - 1;

            for (int i = 0; i < curvePoints.Length; i++)
            {
                this.Area += (curvePoints[endPoints].X + curvePoints[i].X) * (curvePoints[endPoints].Y - curvePoints[i].Y);
                endPoints = i;
            }
            this.Area = Math.Abs(this.Area / 2.0F);

            int nextPoint = 1;
            for (int i = 0; i < curvePoints.Length; i++)
            {
                if (nextPoint == curvePoints.Length)
                {
                    nextPoint = 0;
                }
                this.Perimeter += (float)Math.Sqrt((float)Math.Pow(curvePoints[nextPoint].X - curvePoints[i].X, 2.0f) + (float)Math.Pow(curvePoints[nextPoint].Y - curvePoints[i].Y, 2.0f));
                nextPoint += 1;
            }
        }


        /// <summary>
        /// Creates graphics path of shape
        /// </summary>
        public void UpdatePath()
        {
            _path = new GraphicsPath();
            PointF[] curvePoints = new PointF[VerticesX.Count];
            for (int i = 0; i < VerticesX.Count - 1; i++)
            {
                curvePoints[i].X = VerticesX[i];
                curvePoints[i].Y = VerticesY[i];
            }
            _path.AddPolygon(curvePoints);
        }
        #endregion
    }
}

