using Shapes.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Shapes.ModelsStore
{
    internal class Repository : IRepository
    {
        #region Variables
        private List<IShape> _shapeList;
        private readonly string _xmlCircleFilePath;
        private readonly string _xmlEllipseFilePath;
        private readonly string _xmlTriangleFilePath;
        private readonly string _xmlPolygonFilePath;
        private readonly string _xmlSquareFilePath;

        private List<Circle> _circleList;
        private List<Ellipse> _ellipseList;
        private List<EquilateralTriangle> _triangleList;
        private List<FreeFormPolygon> _polygonList;
        private List<Square> _squareList;
        #endregion


        #region Constuctor
        public Repository(string path)
        {
            _shapeList = new List<IShape>();

            _xmlCircleFilePath = path + @"\circles.xml";
            _xmlEllipseFilePath = path + @"\ellipse.xml";
            _xmlTriangleFilePath = path + @"\triangles.xml";
            _xmlPolygonFilePath = path + @"\polygons.xml";
            _xmlSquareFilePath = path + @"\squares.xml";


            CSVReader csvReader = new CSVReader();
            if (!File.Exists(_xmlCircleFilePath)) { SaveCircleList(csvReader.GetCircleList("Circle", path)); }
            if (!File.Exists(_xmlEllipseFilePath)) { SaveEllipseList(csvReader.GetEllipseList("Ellipse", path)); }
            if (!File.Exists(_xmlTriangleFilePath)) { SaveTriangleList(csvReader.GetEquilateralTriangleList("Equilateral Triangle", path)); }
            if (!File.Exists(_xmlPolygonFilePath)) { SavePolygonList(csvReader.GetFreeFormPolygonList("Polygon", path)); }
            if (!File.Exists(_xmlSquareFilePath)) { SaveSquareList(csvReader.GetSquareList("Square", path)); }


            _circleList = ReadCircle(_xmlCircleFilePath);
            _ellipseList = ReadEllipse(_xmlEllipseFilePath);
            _triangleList = ReadTriangle(_xmlTriangleFilePath);
            _polygonList = ReadPolygon(_xmlPolygonFilePath);
            _squareList = ReadSquare(_xmlSquareFilePath);

            _shapeList = GetAllShapes();
        }
        #endregion


        #region CreateFiles

        /// <summary>
        /// Saves Circles to xml file
        /// </summary>
        /// <param name="circle list"></param>
        private void SaveCircleList(List<Circle> list)
        {
            XmlSerializer _serializer = new XmlSerializer(typeof(List<Circle>));

            using (var writer = new StreamWriter(_xmlCircleFilePath, false))
            {
                _serializer.Serialize(writer, list);
            }
        }

        /// <summary>
        /// Saves Ellipse to xml file
        /// </summary>
        /// <param name="Ellipse list"></param>
        private void SaveEllipseList(List<Ellipse> list)
        {
            XmlSerializer _serializer = new XmlSerializer(typeof(List<Ellipse>));

            using (var writer = new StreamWriter(_xmlEllipseFilePath, false))
            {
                _serializer.Serialize(writer, list);
            }
        }

        /// <summary>
        /// Saves Equilateral Triangle to xml file
        /// </summary>
        /// <param name="Equilatera lTriangle list"></param>
        private void SaveTriangleList(List<EquilateralTriangle> list)
        {
            XmlSerializer _serializer = new XmlSerializer(typeof(List<EquilateralTriangle>));

            using (var writer = new StreamWriter(_xmlTriangleFilePath, false))
            {
                _serializer.Serialize(writer, list);
            }
        }

        /// <summary>
        /// Saves Polygon to xml file
        /// </summary>
        /// <param name="Polygon list"></param>
        private void SavePolygonList(List<FreeFormPolygon> list)
        {
            XmlSerializer _serializer = new XmlSerializer(typeof(List<FreeFormPolygon>));

            using (var writer = new StreamWriter(_xmlPolygonFilePath, false))
            {
                _serializer.Serialize(writer, list);
            }
        }

        /// <summary>
        /// Saves Square to xml file
        /// </summary>
        /// <param name="Square list"></param>
        private void SaveSquareList(List<Square> list)
        {
            XmlSerializer _serializer = new XmlSerializer(typeof(List<Square>));

            using (var writer = new StreamWriter(_xmlSquareFilePath, false))
            {
                _serializer.Serialize(writer, list);
            }
        }

        #endregion


        #region ReadFiles

        /// <summary>
        /// Read Circles xml file
        /// </summary>
        /// <param name="file path"></param>
        /// <returns>List of Circles</returns>
        private List<Circle> ReadCircle(string path)
        {
            XmlSerializer _serializer = new XmlSerializer(typeof(List<Circle>));
            using (var reader = new StreamReader(path))
            {
                return (List<Circle>)_serializer.Deserialize(reader);
            }
        }

        /// <summary>
        /// Read FreeForm Polygon xml file
        /// </summary>
        /// <param name="file path"></param>
        /// <returns>List of FreeForm Polygon</returns>
        private List<FreeFormPolygon> ReadPolygon(string path)
        {
            XmlSerializer _serializer = new XmlSerializer(typeof(List<FreeFormPolygon>));
            using (var reader = new StreamReader(path))
            {
                return (List<FreeFormPolygon>)_serializer.Deserialize(reader);
            }
        }

        /// <summary>
        /// Read Square xml file
        /// </summary>
        /// <param name="file path"></param>
        /// <returns>List of Square</returns>
        private List<Square> ReadSquare(string path)
        {
            XmlSerializer _serializer = new XmlSerializer(typeof(List<Square>));
            using (var reader = new StreamReader(path))
            {
                return (List<Square>)_serializer.Deserialize(reader);
            }
        }

        /// <summary>
        /// Read Equilateral Triangle xml file
        /// </summary>
        /// <param name="file path"></param>
        /// <returns>List of Equilateral Triangle</returns>
        private List<EquilateralTriangle> ReadTriangle(string path)
        {
            XmlSerializer _serializer = new XmlSerializer(typeof(List<EquilateralTriangle>));
            using (var reader = new StreamReader(path))
            {
                return (List<EquilateralTriangle>)_serializer.Deserialize(reader);
            }
        }

        /// <summary>
        /// Read Ellipse xml file
        /// </summary>
        /// <param name="file path"></param>
        /// <returns>List of Ellipse</returns>
        private List<Ellipse> ReadEllipse(string path)
        {
            XmlSerializer _serializer = new XmlSerializer(typeof(List<Ellipse>));
            using (var reader = new StreamReader(path))
            {
                return (List<Ellipse>)_serializer.Deserialize(reader);
            }
        }
        #endregion


        #region IRepository

        /// <summary>
        /// Get and Set List<IShape> of all shapes</IShape>
        /// </summary>
        public List<IShape> GetShapeList
        {
            get
            {
                return _shapeList;
            }
            set
            {
                _shapeList = value;
            }

        }

        /// <summary>
        /// Private method to set all shapes to one variable
        /// </summary>
        private List<IShape> GetAllShapes()
        {

            _circleList = ReadCircle(_xmlCircleFilePath);
            _ellipseList = ReadEllipse(_xmlEllipseFilePath);
            _triangleList = ReadTriangle(_xmlTriangleFilePath);
            _polygonList = ReadPolygon(_xmlPolygonFilePath);
            _squareList = ReadSquare(_xmlSquareFilePath);
            if (_circleList.Count != 0 || _circleList != null)
            {
                foreach (IShape s in _circleList)
                {
                    s.UpdatePath();
                    _shapeList.Add(s);
                }
            }
            if (_ellipseList.Count != 0 || _ellipseList != null)
            {
                foreach (IShape s in _ellipseList)
                {
                    s.UpdatePath();
                    _shapeList.Add(s);
                }
            }
            if (_polygonList.Count != 0 || _polygonList != null)
            {
                foreach (IShape s in _polygonList)
                {
                    s.UpdatePath();
                    _shapeList.Add(s);
                }
            }
            if (_triangleList.Count != 0 || _triangleList != null)
            {
                foreach (IShape s in _triangleList)
                {
                    s.UpdatePath();
                    _shapeList.Add(s);
                }

            }
            if (_squareList.Count != 0 || _squareList != null)
            {
                foreach (IShape s in _squareList)
                {
                    s.UpdatePath();
                    _shapeList.Add(s);
                }
            }
            return _shapeList;
        }

        
        /// <summary>
        /// Finds all shapetypes to place into datatable for shape selector.
        /// </summary>
        /// <param name="shapeType"></param>
        /// <returns>DataTable</returns>
        public DataTable GetSimpleShape(String shapeType)
        {
            Enum.TryParse(shapeType, out ShapeEnum type);
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("TYPE", typeof(string));
            table.Columns.Add("PERIMETER", typeof(string));
            table.Columns.Add("AREA", typeof(string));
            table.Columns.Add("COLOR", typeof(string));

            foreach (IShape s in _shapeList)
            {
                if (type == s.Type)
                {
                    table.Rows.Add(s.ShapeID, s.Type, s.Perimeter, s.Area, s.Color);
                }
            }

            return table;
        }


        /// <summary>
        /// Gets shape from shapeID and shape type.
        /// </summary>
        /// <param name="shapeID"></param>
        /// <param name="Type"></param>
        /// <returns>IShape</returns>
        public IShape GetShapeFromID(int shapeID, String Type)
        {
            List<IShape> emptyShape = new List<IShape>();
            switch (Type)
            {
                case "Square":
                    emptyShape.Add(_squareList[shapeID]);
                    break;
                case "Ellipse":
                    emptyShape.Add(_ellipseList[shapeID]);
                    break;
                case "Circle":
                    emptyShape.Add(_circleList[shapeID]);
                    break;
                case "EquilateralTriangle":
                    emptyShape.Add(_triangleList[shapeID]);
                    break;
                case "FreeformPolygon":
                    emptyShape.Add(_polygonList[shapeID]);
                    break;
            }
            return emptyShape[0];
        }


        /// <summary>
        /// Save all shapes to xml
        /// </summary>
        public void SaveShapes()
        {
            SaveSquareList(_squareList);
            SaveEllipseList(_ellipseList);
            SaveCircleList(_circleList);
            SaveTriangleList(_triangleList);
            SavePolygonList(_polygonList);
        }

        /// <summary>
        /// Update shape color from the given parameters
        /// </summary>
        /// <param name="shapeID"></param>
        /// <param name="type"></param>
        /// <param name="color"></param>
        public void UpdateShapeColorID(int shapeID, String type, String color)
        {
            switch (type)
            {
                case "Square":
                    _squareList[shapeID].Color = color;
                    break;
                case "Ellipse":
                    _ellipseList[shapeID].Color = color;
                    break;
                case "Circle":
                    _circleList[shapeID].Color = color;
                    break;
                case "EquilateralTriangle":
                    _triangleList[shapeID].Color = color;
                    break;
                case "FreeformPolygon":
                    _polygonList[shapeID].Color = color;
                    break;
            }
        }
        #endregion
    }
}
