using Shapes.Models;
using Shapes.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Presenters
{
    public class ShapeSelectorPresenter
    {
        #region Variables
        private readonly IMainView _mainView;
        private readonly IShapeSelectorView _shapeSelectorView;
        private readonly Shapes.ModelsStore.IRepository _repo;
        #endregion


        #region Constructor

        /// <summary>
        /// Constructor for ShapeSelectorPresenter (Main Call happens in MainViewPresenter).
        /// </summary>
        /// <param name="mainView"></param>
        /// <param name="shapeSelectorView"></param>
        /// <param name="repo"></param>
        public ShapeSelectorPresenter(IMainView mainView,IShapeSelectorView shapeSelectorView, Shapes.ModelsStore.IRepository repo)
        {
            _shapeSelectorView = shapeSelectorView;
            shapeSelectorView.Presenter = this;
            _repo = repo;
            _mainView = mainView;
            this._shapeSelectorView.Cancel += Cancel;
            this._shapeSelectorView.SelectedShapeChange += SelectedShapeChange;
        }
        #endregion


        #region Events
        /// <summary>
        /// Clear datagrid and load new selected shapetype to view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SelectedShapeChange(object sender, EventArgs e)
        {       
            _shapeSelectorView.ClearGrid();
            _shapeSelectorView.AddTableToGrid(_repo.GetSimpleShape(_shapeSelectorView.SelectedShapeType));
        }

        /// <summary>
        /// Clear rquest of the datagrid 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SelectionChanged(object sender, EventArgs e)
        {
            _shapeSelectorView.ClearGrid();
        }

        /// <summary>
        /// Calls close event for the ShapeSelectorView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Cancel(object sender, EventArgs e)
        {
            _shapeSelectorView.CloseView();
        }

        #endregion
    }


}
