using Shapes.Presenters;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Shapes.Views
{
    public partial class MainView : Form, IMainView
    {

        #region Variables
        private GraphicsPath _path;
        private Color _color;
        private float _orientation;
        private GraphicsPath _CurrentDrawnPath;
        private float _zoom;
        #endregion


        #region Constructor
        /// <summary>
        /// MainView Constructor
        /// </summary>
        public MainView()
        {
            InitializeComponent();

            btnLoad.Click += delegate { LoadShapeSelectorView?.Invoke(this, EventArgs.Empty); };           
            btnSave.Click += delegate { Save?.Invoke(this, EventArgs.Empty); };
            btnReset.Click += delegate { Reset?.Invoke(this, EventArgs.Empty); };           
            btnColorChange.Hide();
            lblCord.BringToFront();
            btnZoomMinus.Hide();
            btnZoomPos.Hide();
            picBox.Width = pnlDraw.Width;
            picBox.Height = pnlDraw.Height;
        }
        #endregion


        #region IMainView
        public event EventHandler LoadShapeSelectorView;
        public event EventHandler Save;
        public event EventHandler Reset;
        public event EventHandler ShapeColorChange;

        public MainViewPresenter Presenter { get; set; }

        /// <summary>
        /// Draw request from MainViewPresenter. Takes path, color, and orientation of the shape object.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="color"></param>
        /// <param name="orientation"></param>
        public void Draw(GraphicsPath path, Color color, float orientation)
        {
            _path = new GraphicsPath();
            _color = new Color();
            _path = path;
            _color = color;
            _orientation = orientation;
            picBox.Invalidate();
        }
        #endregion


        #region Events
        /// <summary>
        /// Method to draw grid lines on picture box (Called by picBox_Paint event).
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private PaintEventArgs DrawGrid(PaintEventArgs e)
        {
            try
            {
                picBox.Width = pnlDraw.Width;
                picBox.Height = pnlDraw.Height;
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                e.Graphics.InterpolationMode = InterpolationMode.High;
                int countX = 0;
                for (int x = 0; x < picBox.Width; x++)
                {
                    e.Graphics.DrawLine(new Pen(Color.LightGray, 0.01F), countX, 0, countX, picBox.Height);
                    countX += 10;
                }
                int countY = 0;
                for (int y = 0; y < picBox.Width; y++)
                {
                    e.Graphics.DrawLine(new Pen(Color.LightGray, 0.01F), 0, countY, picBox.Width, countY);
                    countY += 10;

                }
            }
            finally
            {
                e.Graphics.RotateTransform(0F);
            }
            return e;
        }


        /// <summary>
        /// Loads color dialog on the button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnColorChange_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog
            {
                SolidColorOnly = true
            };
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                Object obj = colorDlg.Color;
                ShapeColorChange?.Invoke(obj, EventArgs.Empty);
                colorDlg.Dispose();
            }
        }


        /// <summary>
        /// Zoom positive button event. Still needs work to function.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnZoomPos_Click(object sender, EventArgs e)
        {
            _zoom += 1000f;
            picBox.Width = Convert.ToInt32(picBox.Width + _zoom);
            picBox.Height = Convert.ToInt32(picBox.Height + _zoom);
        }

        /// <summary>
        /// Zoom minus button event. Still needs work to function.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnZoomMinus_Click(object sender, EventArgs e)
        {
            _zoom -= 1000f;
            picBox.Width = Convert.ToInt32(picBox.Width - _zoom);
            picBox.Height = Convert.ToInt32(picBox.Height - _zoom);
        }


        /// <summary>
        /// Picture box paint event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picBox_Paint(object sender, PaintEventArgs e)
        {
            Brush brush = new SolidBrush(_color);

            try
            {
                e = DrawGrid(e);
                float orientat = (float)(_orientation * (180 / Math.PI));
                if (orientat < 180)
                {
                    e.Graphics.RotateTransform(orientat);
                }
                else
                {
                    e.Graphics.RotateTransform((float)(360 - _orientation));
                }
                if (_path != null && _color != null)
                {
                    _CurrentDrawnPath = _path;
                    e.Graphics.FillPath(brush, _path);
                    btnColorChange.Show();
                }
            }
            finally
            {
                e.Graphics.RotateTransform(0F);
                brush.Dispose();
            }
        }


        /// <summary>
        /// Mouse move event to update label with current coordinates.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picBox_MouseMove(object sender, MouseEventArgs e)
        {
            lblCord.Text = "X:" + e.Location.X + "  " + "Y:" + e.Location.Y;
            int x = (int)(e.Location.X + (10));
            int y = (int)(e.Location.Y + (10));
            lblCord.Location = new Point(x, y);
        }

        /// <summary>
        /// Mouse leave event to hide coordinates label.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picBox_MouseLeave(object sender, EventArgs e)
        {
            lblCord.Hide();
        }

        /// <summary>
        /// Mouse enter event to hide coordinates label.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picBox_MouseEnter(object sender, EventArgs e)
        {
            lblCord.Show();
        }
        #endregion

    }
}
