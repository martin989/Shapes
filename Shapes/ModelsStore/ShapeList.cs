using Shapes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.ModelsStore
{
    class ShapeList
    {
        private CSVReader _csvReader;

        #region Constructor
        public ShapeList()
        {
            _csvReader = new CSVReader();
        }
        #endregion


        #region Methods
        /// <summary>
        /// Gets list of circles form the csv file (calls LoadFromCSV)
        /// </summary>
        /// <param name="shape"></param>
        /// <param name="fileName"></param>
        /// <returns> List of circles</returns>
        public List<Circle> GetCircleList(string shape, string fileName)
        {
            List<IShape> list = new List<IShape>();
            List<Circle> clist = new List<Circle>();
            list = _csvReader.LoadFromCSV(shape, fileName);
            foreach (Circle c in list)
            {
                clist.Add(c);
            }
            return clist;
        }

        /// <summary>
        /// Gets list of Ellipse form the csv file (calls LoadFromCSV)
        /// </summary>
        /// <param name="shape"></param>
        /// <param name="fileName"></param>
        /// <returns> List of Ellipse</returns>
        public List<Ellipse> GetEllipseList(string shape, string fileName)
        {
            List<IShape> list = new List<IShape>();
            List<Ellipse> elist = new List<Ellipse>();
            list = _csvReader.LoadFromCSV(shape, fileName);
            foreach (Ellipse e in list)
            {
                elist.Add(e);
            }
            return elist;
        }

        /// <summary>
        /// Gets list of Square form the csv file (calls LoadFromCSV)
        /// </summary>
        /// <param name="shape"></param>
        /// <param name="fileName"></param>
        /// <returns> List of Square</returns>
        public List<Square> GetSquareList(string shape, string fileName)
        {
            List<IShape> list = new List<IShape>();
            List<Square> slist = new List<Square>();
            list = _csvReader.LoadFromCSV(shape, fileName);
            foreach (Square s in list)
            {
                slist.Add(s);
            }
            return slist;
        }

        /// <summary>
        /// Gets list of Equilateral Triangle form the csv file (calls LoadFromCSV)
        /// </summary>
        /// <param name="shape"></param>
        /// <param name="fileName"></param>
        /// <returns> List of Equilateral Triangle</returns>
        public List<EquilateralTriangle> GetEquilateralTriangleList(string shape, string fileName)
        {
            List<IShape> list = new List<IShape>();
            List<EquilateralTriangle> tlist = new List<EquilateralTriangle>();
            list = _csvReader.LoadFromCSV(shape, fileName);
            foreach (EquilateralTriangle t in list)
            {
                tlist.Add(t);
            }
            return tlist;
        }

        /// <summary>
        /// Gets list of FreeForm Polygon form the csv file (calls LoadFromCSV)
        /// </summary>
        /// <param name="shape"></param>
        /// <param name="fileName"></param>
        /// <returns> List of FreeForm Polygon</returns>
        public List<FreeFormPolygon> GetFreeFormPolygonList(string shape, string fileName)
        {
            List<IShape> list = new List<IShape>();
            List<FreeFormPolygon> plist = new List<FreeFormPolygon>();
            list = _csvReader.LoadFromCSV(shape, fileName);
            foreach (FreeFormPolygon p in list)
            {
                plist.Add(p);
            }
            return plist;
        }
#endregion
    }
}
