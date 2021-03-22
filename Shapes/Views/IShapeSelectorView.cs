using System;
using System.Data;

namespace Shapes.Views
{
    public interface IShapeSelectorView
    {
        event EventHandler<ShapeIDArgs> LoadShape;
        event EventHandler SelectedShapeChange;
        event EventHandler Cancel;
        event EventHandler SelectionChanged;

        void AddTableToGrid(DataTable table);

        void ClearGrid();

        void CloseView();

        string SelectedShapeType { get; }

        Presenters.ShapeSelectorPresenter Presenter { get;  set; }
    }
}
