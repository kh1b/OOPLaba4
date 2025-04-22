using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLaba4
{
    public class CRectangle : BaseShape
    {
        private int width = 50; // Ширина прямоугольника
        private int height = 30; // Высота прямоугольника

        // Конструктор
        public CRectangle(int x, int y) : base(x, y)
        {
            this.x = x - width / 2;
            this.y = y - height / 2;
        }

        // Реализация метода ContainsPoint
        public override bool ContainsPoint(int px, int py)
        {
            return px >= x && px <= x + width && py >= y && py <= y + height;
        }

        // Реализация метода Draw
        public override void Draw(Graphics g)
        {
            Brush brush = isSelected ? Brushes.Red : new SolidBrush(color);
            int scaledWidth = (int)(width * scale);
            int scaledHeight = (int)(height * scale);
            g.FillRectangle(brush, x, y, scaledWidth, scaledHeight);
        }

        public override void Resize(float factor, int maxX, int maxY)
        {
            base.Resize(factor, maxX - (int)(width * scale), maxY - (int)(height * scale));
        }

        // Переопределение метода Move для прямоугольника
        public override void Move(int dx, int dy, int maxX, int maxY)
        {
            base.Move(dx, dy, maxX - width, maxY - height);
        }
    }
}
