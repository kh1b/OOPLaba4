using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLaba4
{
    public class CTriangle : BaseShape
    {
        private int size = 50; // Размер треугольника

        // Конструктор
        public CTriangle (int x, int y) : base(x, y)
        {
            this.y = y + size / -3;
        }

        // Реализация метода ContainsPoint
        public override bool ContainsPoint(int px, int py)
        {
            Point[] points = GetTrianglePoints();
            return IsPointInTriangle(px, py, points[0], points[1], points[2]);
        }

        // Реализация метода Draw
        public override void Draw(Graphics g)
        {
            Brush brush = isSelected ? Brushes.Red : new SolidBrush(color);
            int scaledSize = (int)(size * scale);
            Point[] points = GetTrianglePoints(scaledSize);
            g.FillPolygon(brush, points);
        }

        // Получение точек треугольника
        private Point[] GetTrianglePoints(int scaledSize)
        {
            return new Point[]
            {
                new Point(x, y + scaledSize),
                new Point(x - scaledSize / 2, y),
                new Point(x + scaledSize / 2, y)
            };
        }

        // Получение точек треугольника (для проверки точки внутри треугольника)
        private Point[] GetTrianglePoints()
        {
            return new Point[]
            {
                new Point(x, y + size),
                new Point(x - size / 2, y),
                new Point(x + size / 2, y)
            };
        }

        // Проверка, находится ли точка внутри треугольника
        private bool IsPointInTriangle(int px, int py, Point a, Point b, Point c)
        {
            float d1 = Sign(px, py, a.X, a.Y, b.X, b.Y);
            float d2 = Sign(px, py, b.X, b.Y, c.X, c.Y);
            float d3 = Sign(px, py, c.X, c.Y, a.X, a.Y);

            bool hasNeg = (d1 < 0) || (d2 < 0) || (d3 < 0);
            bool hasPos = (d1 > 0) || (d2 > 0) || (d3 > 0);

            return !(hasNeg && hasPos);
        }

        private float Sign(int px, int py, int x1, int y1, int x2, int y2)
        {
            return (px - x2) * (y1 - y2) - (x1 - x2) * (py - y2);
        }

        // Реализация метода Resize
        public override void Resize(float factor, int maxX, int maxY)
        {
            base.Resize(factor, maxX - size / 2, maxY - size);
        }

        // Переопределение метода Move для треугольника
        public override void Move(int dx, int dy, int maxX, int maxY)
        {
            base.Move(dx, dy, maxX - size / 2, maxY - size);
        }
    }
}