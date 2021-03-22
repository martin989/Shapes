using Shapes.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.ModelsStore
{
    public class CSVReader
    {
        #region Constructor
        public CSVReader()
        {
        }
        #endregion


        #region Methods
        /// <summary>
        /// Loads the default csv file with shapes. Using a brute force method of searching for matching string requirements for the shape type.
        /// </summary>
        /// <param name="shape"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public List<IShape> LoadFromCSV(string shape, String fileName)
        {
            List<IShape> _lstShapes = new List<IShape>();
            var reader = new StreamReader(File.OpenRead(fileName+ @"\Machine Vision Development Engineer Coding Exercise _ ShapeList.csv"));
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var value = line.Split(';');
                String[] values = line.Split(',');
                values = values.Where(x => !string.IsNullOrEmpty(x)).ToArray();

                if(values[0].ToString() == shape)
                {
                    switch (values[0].ToString())
                    {
                        case "Square":
                            _lstShapes.Add(new Square(float.Parse(values[2], CultureInfo.InvariantCulture.NumberFormat), float.Parse(values[4], CultureInfo.InvariantCulture.NumberFormat), float.Parse(values[6], CultureInfo.InvariantCulture.NumberFormat), float.Parse(values[8], CultureInfo.InvariantCulture.NumberFormat)));
                            break;
                        case "Ellipse":
                            _lstShapes.Add(new Ellipse(float.Parse(values[2], CultureInfo.InvariantCulture.NumberFormat), float.Parse(values[4], CultureInfo.InvariantCulture.NumberFormat), float.Parse(values[6], CultureInfo.InvariantCulture.NumberFormat), float.Parse(values[8], CultureInfo.InvariantCulture.NumberFormat), float.Parse(values[10], CultureInfo.InvariantCulture.NumberFormat)));
                            break;
                        case "Circle":
                            _lstShapes.Add(new Circle(float.Parse(values[2], CultureInfo.InvariantCulture.NumberFormat), float.Parse(values[4], CultureInfo.InvariantCulture.NumberFormat), float.Parse(values[6], CultureInfo.InvariantCulture.NumberFormat)));
                            break;
                        case "Equilateral Triangle":
                            _lstShapes.Add(new EquilateralTriangle(float.Parse(values[2], CultureInfo.InvariantCulture.NumberFormat), float.Parse(values[4], CultureInfo.InvariantCulture.NumberFormat), float.Parse(values[6], CultureInfo.InvariantCulture.NumberFormat), float.Parse(values[8], CultureInfo.InvariantCulture.NumberFormat)));
                            break;
                        case "Polygon":
                            List<float> VerticesX = new List<float>();
                            List<float> VerticesY = new List<float>();
                            for (int i = 1; i < values.Length; i += 4)
                            {
                                VerticesX.Add(float.Parse(values[i + 1], CultureInfo.InvariantCulture.NumberFormat));
                                VerticesY.Add(float.Parse(values[i + 3], CultureInfo.InvariantCulture.NumberFormat));
                            }
                            _lstShapes.Add(new FreeFormPolygon(VerticesX, VerticesY));
                            break;
                        default:
                            Console.WriteLine("Shape Not Found");
                            break;
                    }
                }
 
                if (_lstShapes.Count != 0)
                {
                    _lstShapes[_lstShapes.Count - 1].ShapeID = _lstShapes.Count - 1;
                    String color = Color.Black.ToString();
                    int c1 = color.IndexOf('[')+1;
                    int c2= color.IndexOf(']');
                    color = color.Substring(c1, c2 - c1);
                    _lstShapes[_lstShapes.Count - 1].Color = color;
                }
            }
            return _lstShapes;
        }


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
            list = LoadFromCSV(shape, fileName);
            foreach(Circle c in list)
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
            list = LoadFromCSV(shape, fileName);
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
            list = LoadFromCSV(shape, fileName);
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
            list = LoadFromCSV(shape, fileName);
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
            list = LoadFromCSV(shape, fileName);
            foreach (FreeFormPolygon p in list)
            {
                plist.Add(p);
            }
            return plist;
        }
        #endregion
    }
}
