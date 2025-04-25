using System;
using System.Drawing;

namespace OOPLaba4
{
    public class CTriangle : BaseShape
    {
        private int width = 60;  // Ширина треугольника (основание)
        private int height = 80; // Высота треугольника

        // Конструктор
        public CTriangle(int centerX, int centerY) : base(centerX, centerY)
        {
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
            int scaledWidth = (int)(width * scale);  // Учитываем масштаб
            int scaledHeight = (int)(height * scale); // Учитываем масштаб

            // Получаем точки треугольника с учётом масштаба
            Point[] points = GetTrianglePoints(scaledWidth, scaledHeight);

            // Рисуем треугольник
            g.FillPolygon(brush, points);
        }

        // Получение точек треугольника (с учётом масштаба)
        private Point[] GetTrianglePoints(int scaledWidth, int scaledHeight)
        {
            return new Point[]
            {
                new Point(x, y + scaledHeight / 2), // Нижняя точка
                new Point(x - scaledWidth / 2, y - scaledHeight / 2), // Левая верхняя точка
                new Point(x + scaledWidth / 2, y - scaledHeight / 2) // Правая верхняя точка
            };
        }

        // Получение точек треугольника (для проверки точки внутри треугольника)
        private Point[] GetTrianglePoints()
        {
            return new Point[]
            {
                new Point(x, y + height / 2), // Нижняя точка
                new Point(x - width / 2, y - height / 2), // Левая верхняя точка
                new Point(x + width / 2, y - height / 2) // Правая верхняя точка
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

        // Вспомогательный метод: знаковая площадь треугольника
        private float Sign(int px, int py, int x1, int y1, int x2, int y2)
        {
            return (px - x2) * (y1 - y2) - (x1 - x2) * (py - y2);
        }

        // Переопределение метода Move для треугольника
        public override void Move(int dx, int dy, int maxX, int maxY)
        {
            base.Move(dx, dy, maxX, maxY);
        }

        // Методы для получения исходных размеров
        protected override int GetWidth()
        {
            return width; // Полная ширина треугольника
        }

        protected override int GetHeight()
        {
            return height; // Полная высота треугольника
        }
    }
}