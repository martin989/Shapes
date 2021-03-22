using Shapes.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.ModelsStore
{
    public interface IRepository
    {
        List<IShape> GetShapeList { get; set; }
        IShape GetShapeFromID(int shapeID, String type);
        void SaveShapes();
        DataTable GetSimpleShape(String shapeType);
        void UpdateShapeColorID(int id, String type, String color);
    }
}
