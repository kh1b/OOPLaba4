using System;
using System.Drawing;

namespace OOPLaba4
{
    public class CRectangle : BaseShape
    {
        private int width = 65; // Ширина прямоугольника
        private int height = 40; // Высота прямоугольника

        // Конструктор
        public CRectangle(int centerX, int centerY) : base(centerX, centerY)
        {
        }

        // Реализация метода ContainsPoint
        public override bool ContainsPoint(int px, int py)
        {
            // Проверяем, находится ли точка внутри прямоугольника
            int scaledWidth = (int)(width * scale);
            int scaledHeight = (int)(height * scale);

            return px >= x - scaledWidth / 2 && px <= x + scaledWidth / 2 &&
                   py >= y - scaledHeight / 2 && py <= y + scaledHeight / 2;
        }

        // Реализация метода Draw
        public override void Draw(Graphics g)
        {
            Brush brush = isSelected ? Brushes.Red : new SolidBrush(color);
            int scaledWidth = (int)(width * scale); // Учитываем масштаб
            int scaledHeight = (int)(height * scale); // Учитываем масштаб

            // Рисуем прямоугольник с учётом центра
            g.FillRectangle(brush, x - scaledWidth / 2, y - scaledHeight / 2, scaledWidth, scaledHeight);
        }

        // Переопределение метода Move для прямоугольника
        public override void Move(int dx, int dy, int maxX, int maxY)
        {
            base.Move(dx, dy, maxX, maxY);
        }

        // Методы для получения исходных размеров
        protected override int GetWidth()
        {
            return width; // Полная ширина прямоугольника
        }

        protected override int GetHeight()
        {
            return height; // Полная высота прямоугольника
        }
    }
}