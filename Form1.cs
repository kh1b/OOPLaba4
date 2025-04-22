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
        private Type? currentShapeType = typeof(CCircle); // ������� ��� ������

        public Form1()
        {
            InitializeComponent();

            exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;

            this.Text = "���������� ��������";
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
                            // ���� Ctrl �� �����, ������� ��������� �� ���� �����
                            foreach (var s in storage.GetShapes())
                                s.SetSelected(false);
                        }

                        // ����������� ��������� ������� ������
                        shape.SetSelected(!shape.IsSelected());
                        anySelected = true;
                    }
                }

                if (!anySelected)
                {
                    if (isCtrlPressed)
                    {
                        // ���� Ctrl ����� � ���� ��� �� ������ �������, ������� ��������� �� ���� �����
                        foreach (var s in storage.GetShapes())
                            s.SetSelected(false);
                    }
                    else
                    {
                        // ���� Ctrl �� �����, ������ ����� ������
                        if (currentShapeType != null)
                        {
                            BaseShape newShape = (BaseShape)Activator.CreateInstance(currentShapeType, e.X, e.Y)!;
                            storage.AddShape(newShape);
                        }
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

            if (e.KeyCode == Keys.Up)
            {
                foreach (var shape in storage.GetShapes())
                {
                    if (shape.IsSelected())
                        shape.Move(0, -5, this.ClientSize.Width, this.ClientSize.Height);
                }
                this.Invalidate();
            }

            if (e.KeyCode == Keys.Down)
            {
                foreach (var shape in storage.GetShapes())
                {
                    if (shape.IsSelected())
                        shape.Move(0, 5, this.ClientSize.Width, this.ClientSize.Height);
                }
                this.Invalidate();
            }

            if (e.KeyCode == Keys.Left)
            {
                foreach (var shape in storage.GetShapes())
                {
                    if (shape.IsSelected())
                        shape.Move(-5, 0, this.ClientSize.Width, this.ClientSize.Height);
                }
                this.Invalidate();
            }

            if (e.KeyCode == Keys.Right)
            {
                foreach (var shape in storage.GetShapes())
                {
                    if (shape.IsSelected())
                        shape.Move(5, 0, this.ClientSize.Width, this.ClientSize.Height);
                }
                this.Invalidate();
            }

            if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus) // ���������� �������
            {
                foreach (var shape in storage.GetShapes())
                {
                    if (shape.IsSelected())
                        shape.Resize(1.1f, this.ClientSize.Width, this.ClientSize.Height);
                }
                this.Invalidate();
            }

            if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus) // ���������� �������
            {
                foreach (var shape in storage.GetShapes())
                {
                    if (shape.IsSelected())
                        shape.Resize(0.9f, this.ClientSize.Width, this.ClientSize.Height);
                }
                this.Invalidate();
            }

            if (e.KeyCode == Keys.C && e.Control)
            {
                using (ColorDialog colorDialog = new ColorDialog())
                {
                    if (colorDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (var shape in storage.GetShapes())
                        {
                            if (shape.IsSelected())
                                shape.ChangeColor(colorDialog.Color);
                        }
                        this.Invalidate();
                    }
                }
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

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); // ������� ����������
        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // ���������, ����� ������ ���� ������
            if (e.ClickedItem == toolStripButton1)
            {
                currentShapeType = typeof(CCircle); // ���������� ������� ��� ������ ��� ����
            }
            else if (e.ClickedItem == toolStripButton2)
            {
                currentShapeType = typeof(CRectangle); // ���������� ������� ��� ������ ��� �������������
            }
            else if (e.ClickedItem == toolStripButton3)
            {
                currentShapeType = typeof(CEllipse); // ���������� ������� ��� ������ ��� ������
            }
            else if (e.ClickedItem == toolStripButton4)
            {
                currentShapeType = typeof(CTriangle); // ���������� ������� ��� ������ ��� �����������
            }
        }
    }
}
