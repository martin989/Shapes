using Shapes.Presenters;
using Shapes.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace Shapes.Views
{
    public partial class ShapeSelectorView : Form, IShapeSelectorView
    {
        #region Constructor

        /// <summary>
        /// Shape Selector View constructor
        /// </summary>
        public ShapeSelectorView()
        {
            InitializeComponent();
            cboPreview.SelectedIndexChanged += delegate { SelectedShapeChange?.Invoke(this, EventArgs.Empty); };
            dgvPreview.SelectionChanged += delegate { SelectionChanged?.Invoke(this, EventArgs.Empty); };
            btnLoad.Click += delegate { LoadShape?.Invoke(this, new ShapeIDArgs((int)dgvPreview.CurrentRow.Cells[0].Value, (String)dgvPreview.CurrentRow.Cells[1].Value)); };
            btnCancel.Click += delegate { Cancel?.Invoke(this, EventArgs.Empty); };
            btnLoad.Hide();
        }
        #endregion

        #region IShapeSelectorView
        public event EventHandler<ShapeIDArgs> LoadShape;
        public event EventHandler SelectedShapeChange;
        public event EventHandler Cancel;
        public event EventHandler SelectionChanged;
        public ShapeSelectorPresenter Presenter { get; set; }


        /// <summary>
        /// Property for selected shape type string
        /// </summary>
        public string SelectedShapeType
        {
            get => (cboPreview.SelectedItem.ToString());
        }

        /// <summary>
        /// Method for adding new DataTable to grid view.
        /// </summary>
        /// <param name="table"></param>
        void IShapeSelectorView.AddTableToGrid(DataTable table)
        {
            btnLoad.Show();
            dgvPreview.DataSource = table;
            dgvPreview.Refresh();
        }

        /// <summary>
        /// Clear grid view
        /// </summary>
        public void ClearGrid()
        {
            dgvPreview.DataSource = null;
            dgvPreview.Refresh();
        }

        /// <summary>
        /// Close ShapeSelectorView request.
        /// </summary>
        void IShapeSelectorView.CloseView()
        {
            this.Close();
        }

        /// <summary>
        /// Update shape type combo box with enum ShapeEnum
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboPreview_DropDown(object sender, EventArgs e)
        {
            cboPreview.DataSource = Enum.GetValues(typeof(ShapeEnum));
        }
        #endregion
    }



    /// <summary>
    /// ShapeID Arguments
    /// </summary>
    public class ShapeIDArgs : EventArgs
    {
        public int ShapeID { get; }
        public String Type { get; }

        public ShapeIDArgs(int shapeID, String type)
        {
            ShapeID = shapeID;
            Type = type;
        }
    }
}
