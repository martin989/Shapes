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
            var reader = new StreamReader(File.OpenRead(fileName+ @"\Shapes.csv"));
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
    }
    #endregion
}
