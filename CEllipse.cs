using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLaba4
{
    public class CEllipse : BaseShape
    {
        private int width = 80; // Ширина эллипса
        private int height = 50; // Высота эллипса

        // Конструктор
        public CEllipse(int centerX, int centerY) : base(centerX, centerY)
        {
        }

        // Реализация метода ContainsPoint
        public override bool ContainsPoint(int px, int py)
        {
            double dx = (px - x) / (width / 2.0);
            double dy = (py - y) / (height / 2.0);
            return dx * dx + dy * dy <= 1;
        }

        // Реализация метода Draw
        public override void Draw(Graphics g)
        {
            Brush brush = isSelected ? Brushes.Red : new SolidBrush(color);
            int scaledWidth = (int)(width * scale); // Учитываем масштаб
            int scaledHeight = (int)(height * scale); // Учитываем масштаб
            g.FillEllipse(brush, x - scaledWidth / 2, y - scaledHeight / 2, scaledWidth, scaledHeight);
        }

        // Переопределение метода Move для эллипса
        public override void Move(int dx, int dy, int maxX, int maxY)
        {
            base.Move(dx, dy, maxX, maxY);
        }

        // Методы для получения исходных размеров
        protected override int GetWidth()
        {
            return width; // Полная ширина эллипса
        }

        protected override int GetHeight()
        {
            return height; // Полная высота эллипса
        }
    }
}