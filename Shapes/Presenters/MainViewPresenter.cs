using Shapes.Models;
using Shapes.ModelsStore;
using Shapes.Views;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Shapes.Presenters
{
    public class MainViewPresenter
    {
        #region Variables
        private readonly IMainView _mainView;
        private readonly IRepository _repo;
        private int _activeShapeID;
        private String _activeShapeType;
        #endregion


        #region Constructor
        /// <summary>
        /// Constructor for MainViewPresenter (Main Call happens in Program.cs).
        /// </summary>
        /// <param name="mainFormView"></param>
        /// <param name="repo"></param>
        public MainViewPresenter(IMainView mainFormView , IRepository repo)
        {
            _mainView = mainFormView;
            mainFormView.Presenter = this;
            _repo = repo;
            this._mainView.LoadShapeSelectorView += LoadShapeSelectorView;
            this._mainView.Save += Save;
            this._mainView.Reset += Reset;
            this._mainView.ShapeColorChange += ShapeColorChange;
        }
        #endregion


        #region Events
        /// <summary>
        /// Button Event for creating and loading the ShapeSelectorPresenter.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void LoadShapeSelectorView(object sender, EventArgs e)
        {
            var viewShapeSelectorView = new Views.ShapeSelectorView();
            var shapeList = _repo;
            var presenterShapeSelectorPresenter = new Presenters.ShapeSelectorPresenter(this._mainView, viewShapeSelectorView, shapeList);
            viewShapeSelectorView.Show();
            viewShapeSelectorView.LoadShape += LoadShape;
        }


        /// <summary>
        /// Button Event for saving the repo, all list object shapes are saved.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Save(object sender, EventArgs e)
        {
            _repo.SaveShapes();
        }


        /// <summary>
        /// Reset the shape in the view box. This is done by local variables saved on the view. 
        /// Local variables provide data activeShapeID, activeShapeType which allow the _rope request to load shape.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Reset(object sender, EventArgs e)
        {
            if (_activeShapeID >= 0)
            {
                _mainView.Draw
                    (_repo.GetShapeFromID(_activeShapeID, _activeShapeType).Path,
                    Color.FromName(_repo.GetShapeFromID(_activeShapeID, _activeShapeType).Color),
                    _repo.GetShapeFromID(_activeShapeID, _activeShapeType).Orienation);
            }
        }


        /// <summary>
        /// Shape color change request which passes new color selected in the color dialog to the MainView.
        /// Local variables provide data activeShapeID, activeShapeType.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShapeColorChange(object sender, EventArgs e)
        {
            _mainView.Draw
                (_repo.GetShapeFromID(_activeShapeID, _activeShapeType).Path,
                (Color)sender,
                _repo.GetShapeFromID(_activeShapeID, _activeShapeType).Orienation);
        }
        #endregion


        #region Other Events
        /// <summary>
        /// Load Shape Event from Shape Selector Presenter. Loads selected shape called in the Load button event of the ShapeSelctorPresenter. 
        /// Uses parameters passed in form ShapeIDArgs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e" (Shape type and ID)></param>
        public void LoadShape(object sender, ShapeIDArgs e)
        {
            if (e.ShapeID >= 0)
            {
                _activeShapeID = e.ShapeID;
                _activeShapeType = e.Type;
                _mainView.Draw
                    (_repo.GetShapeFromID(e.ShapeID, e.Type).Path,
                    Color.FromName(_repo.GetShapeFromID(e.ShapeID, e.Type).Color),
                    _repo.GetShapeFromID(e.ShapeID, e.Type).Orienation);

            }
        }
        #endregion
    }
}