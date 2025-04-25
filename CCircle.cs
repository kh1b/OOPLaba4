using System;
using System.Drawing;

namespace OOPLaba4
{
    public class CCircle : BaseShape
    {
        private int radius = 30; // Радиус круга

        // Конструктор
        public CCircle(int x, int y) : base(x, y)
        {
        }

        // Реализация метода ContainsPoint
        public override bool ContainsPoint(int px, int py)
        {
            return (px - x) * (px - x) + (py - y) * (py - y) <= radius * radius;
        }

        // Реализация метода Draw
        public override void Draw(Graphics g)
        {
            Brush brush = isSelected ? Brushes.Red : new SolidBrush(color);
            int scaledRadius = (int)(radius * scale);
            g.FillEllipse(brush, x - scaledRadius, y - scaledRadius, 2 * scaledRadius, 2 * scaledRadius);
        }

        // Реализация метода Resize
        public override void Resize(float factor, int maxX, int maxY)
        {
            base.Resize(factor, maxX - (int)(radius * scale), maxY - (int)(radius * scale));
        }

        // Переопределение метода Move для круга
        public override void Move(int dx, int dy, int maxX, int maxY)
        {
            base.Move(dx, dy, maxX, maxY);
        }

        protected override int GetWidth()
        {
            return radius * 2; // Диаметр круга
        }

        protected override int GetHeight()
        {
            return radius * 2; // Диаметр круга
        }
    }
}
