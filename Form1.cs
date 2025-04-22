using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OOPLaba4
{
    public partial class Form1 : Form
    {
        private ShapeStorage storage = new ShapeStorage();
        private bool isCtrlPressed = false;

        public Form1()
        {
            InitializeComponent();

            this.Text = "Визуальный редактор";
            this.Size = new Size(800, 600);

            this.MouseDown += MainForm_MouseDown;
            this.Paint += MainForm_Paint;
            this.KeyDown += MainForm_KeyDown;
            this.KeyUp += MainForm_KeyUp;
        }

        private void MainForm_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                bool anySelected = false;

                foreach (var shape in storage.GetShapes())
                {
                    if (shape.ContainsPoint(e.X, e.Y))
                    {
                        if (!isCtrlPressed)
                        {
                            foreach (var s in storage.GetShapes())
                                s.SetSelected(false);
                        }

                        shape.SetSelected(!shape.IsSelected());
                        anySelected = true;
                    }
                }

                if (!anySelected)
                {
                    if (!isCtrlPressed)
                    {
                        storage.AddShape(new CCircle(e.X, e.Y));
                    }
                }

                this.Invalidate();
            }
        }

        private void MainForm_Paint(object? sender, PaintEventArgs e)
        {
            foreach (var shape in storage.GetShapes())
            {
                shape.Draw(e.Graphics);
            }
        }

        private void MainForm_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                storage.RemoveSelectedShapes();
                this.Invalidate();
            }

            if (e.Control)
            {
                isCtrlPressed = true;
            }
        }

        private void MainForm_KeyUp(object? sender, KeyEventArgs e)
        {
            if (!e.Control)
            {
                isCtrlPressed = false;
            }
        }
    }
}
