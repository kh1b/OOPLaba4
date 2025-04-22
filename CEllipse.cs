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
        public CEllipse(int x, int y) : base(x, y)
        {
        }

        // Реализация метода ContainsPoint
        public override bool ContainsPoint(int px, int py)
        {
            double dx = (px - (x + width / 2.0)) / (width / 2.0);
            double dy = (py - (y + height / 2.0)) / (height / 2.0);
            return dx * dx + dy * dy <= 1;
        }

        // Реализация метода Draw
        public override void Draw(Graphics g)
        {
            Brush brush = isSelected ? Brushes.Red : new SolidBrush(color);
            g.FillEllipse(brush, x, y, width, height);
        }

        // Переопределение метода Move для эллипса
        public override void Move(int dx, int dy, int maxX, int maxY)
        {
            base.Move(dx, dy, maxX - width, maxY - height);
        }
    }
}