using System;
using System.Drawing;

namespace OOPLaba4
{
    public class CSquare : BaseShape
    {
        private int size = 50; // Размер стороны квадрата

        // Конструктор
        public CSquare(int x, int y) : base(x, y)
        {
        }

        // Реализация метода ContainsPoint
        public override bool ContainsPoint(int px, int py)
        {
            // Проверяем, находится ли точка внутри квадрата
            int scaledSize = (int)(size * scale);
            return px >= x - scaledSize / 2 && px <= x + scaledSize / 2 &&
                   py >= y - scaledSize / 2 && py <= y + scaledSize / 2;
        }

        // Реализация метода Draw
        public override void Draw(Graphics g)
        {
            Brush brush = isSelected ? Brushes.Red : new SolidBrush(color);
            int scaledSize = (int)(size * scale); // Учитываем масштаб
            g.FillRectangle(brush, x - scaledSize / 2, y - scaledSize / 2, scaledSize, scaledSize);
        }

        // Переопределение метода Move для квадрата
        public override void Move(int dx, int dy, int maxX, int maxY)
        {
            base.Move(dx, dy, maxX, maxY);
        }

        protected override int GetWidth()
        {
            return size; // Ширина квадрата
        }

        protected override int GetHeight()
        {
            return size; // Высота квадрата
        }
    }
}