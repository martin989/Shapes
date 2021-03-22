namespace Shapes.Views
{
    partial class MainView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tblLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnZoomMinus = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnColorChange = new System.Windows.Forms.Button();
            this.btnZoomPos = new System.Windows.Forms.Button();
            this.pnlDraw = new System.Windows.Forms.Panel();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.lblCord = new System.Windows.Forms.Label();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.tblLayoutMain.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.pnlDraw.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tblLayoutMain
            // 
            this.tblLayoutMain.ColumnCount = 2;
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tblLayoutMain.Controls.Add(this.pnlButtons, 0, 0);
            this.tblLayoutMain.Controls.Add(this.pnlDraw, 1, 0);
            this.tblLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.tblLayoutMain.Name = "tblLayoutMain";
            this.tblLayoutMain.RowCount = 1;
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 852F));
            this.tblLayoutMain.Size = new System.Drawing.Size(1806, 852);
            this.tblLayoutMain.TabIndex = 1;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.tableLayoutPanel2);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButtons.Location = new System.Drawing.Point(3, 3);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(174, 846);
            this.pnlButtons.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.btnZoomMinus, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.btnReset, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnSave, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnLoad, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnColorChange, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.btnZoomPos, 0, 8);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 10;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(174, 846);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btnZoomMinus
            // 
            this.btnZoomMinus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnZoomMinus.Location = new System.Drawing.Point(3, 759);
            this.btnZoomMinus.Name = "btnZoomMinus";
            this.btnZoomMinus.Size = new System.Drawing.Size(168, 84);
            this.btnZoomMinus.TabIndex = 8;
            this.btnZoomMinus.Text = "-";
            this.btnZoomMinus.UseVisualStyleBackColor = true;
            this.btnZoomMinus.Click += new System.EventHandler(this.btnZoomMinus_Click);
            // 
            // btnReset
            // 
            this.btnReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReset.Location = new System.Drawing.Point(3, 171);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(168, 78);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Location = new System.Drawing.Point(3, 87);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(168, 78);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            this.btnLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoad.Location = new System.Drawing.Point(3, 3);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(168, 78);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            // 
            // btnColorChange
            // 
            this.btnColorChange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnColorChange.Location = new System.Drawing.Point(3, 339);
            this.btnColorChange.Name = "btnColorChange";
            this.btnColorChange.Size = new System.Drawing.Size(168, 78);
            this.btnColorChange.TabIndex = 6;
            this.btnColorChange.Text = "Color Change";
            this.btnColorChange.UseVisualStyleBackColor = true;
            this.btnColorChange.Click += new System.EventHandler(this.btnColorChange_Click);
            // 
            // btnZoomPos
            // 
            this.btnZoomPos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnZoomPos.Location = new System.Drawing.Point(3, 675);
            this.btnZoomPos.Name = "btnZoomPos";
            this.btnZoomPos.Size = new System.Drawing.Size(168, 78);
            this.btnZoomPos.TabIndex = 7;
            this.btnZoomPos.Text = "+";
            this.btnZoomPos.UseVisualStyleBackColor = true;
            this.btnZoomPos.Click += new System.EventHandler(this.btnZoomPos_Click);
            // 
            // pnlDraw
            // 
            this.pnlDraw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDraw.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDraw.Controls.Add(this.picBox);
            this.pnlDraw.Controls.Add(this.lblCord);
            this.pnlDraw.Location = new System.Drawing.Point(183, 3);
            this.pnlDraw.Name = "pnlDraw";
            this.pnlDraw.Size = new System.Drawing.Size(1620, 846);
            this.pnlDraw.TabIndex = 1;
            // 
            // picBox
            // 
            this.picBox.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.picBox.Location = new System.Drawing.Point(-2, 1);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(1623, 846);
            this.picBox.TabIndex = 1;
            this.picBox.TabStop = false;
            this.picBox.Paint += new System.Windows.Forms.PaintEventHandler(this.picBox_Paint);
            this.picBox.MouseEnter += new System.EventHandler(this.picBox_MouseEnter);
            this.picBox.MouseLeave += new System.EventHandler(this.picBox_MouseLeave);
            this.picBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picBox_MouseMove);
            // 
            // lblCord
            // 
            this.lblCord.AutoSize = true;
            this.lblCord.Location = new System.Drawing.Point(-2, 809);
            this.lblCord.Name = "lblCord";
            this.lblCord.Size = new System.Drawing.Size(106, 32);
            this.lblCord.TabIndex = 0;
            this.lblCord.Text = "lblCord";
            // 
            // fileDialog
            // 
            this.fileDialog.FileName = "fileDialog";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1806, 852);
            this.Controls.Add(this.tblLayoutMain);
            this.Name = "MainView";
            this.Text = "Shapes";
            this.tblLayoutMain.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.pnlDraw.ResumeLayout(false);
            this.pnlDraw.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblLayoutMain;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.OpenFileDialog fileDialog;
        private System.Windows.Forms.Button btnColorChange;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button btnZoomMinus;
        private System.Windows.Forms.Button btnZoomPos;
        private System.Windows.Forms.Panel pnlDraw;
        private System.Windows.Forms.Label lblCord;
        private System.Windows.Forms.PictureBox picBox;
    }
}

