using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Shapes.Views
{
    public interface IMainView
    {
        event EventHandler LoadShapeSelectorView;
        event EventHandler Save;
        event EventHandler Reset;
        event EventHandler ShapeColorChange;
        Presenters.MainViewPresenter Presenter { get;  set; }

        void Draw(GraphicsPath path, Color color, float orienation);

    }
}
