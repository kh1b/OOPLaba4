using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            g.FillEllipse(brush, x - radius, y - radius, 2 * radius, 2 * radius);
        }

        // Переопределение метода Move для круга
        public override void Move(int dx, int dy, int maxX, int maxY)
        {
            base.Move(dx, dy, maxX - radius, maxY - radius);
        }
    }
}
