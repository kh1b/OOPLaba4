using System;
using System.Drawing;

namespace OOPLaba4
{
    public class CLine : BaseShape
    {
        private int startX, startY; // Начальная точка отрезка
        private int endX, endY;  // Конечная точка отрезка
        private int thickness = 2; // Толщина линии

        // Конструктор
        public CLine(int centerX, int centerY) : base(centerX, centerY)
        {
            // Инициализируем начальную и конечную точки отрезка
            startX = -25; // Начальная точка (слева от центра)
            startY = 0; // На уровне центра по вертикали
            endX = 25; // Конечная точка (справа от центра)
            endY = 0; // На уровне центра по вертикали
        }

        // Реализация метода ContainsPoint
        public override bool ContainsPoint(int px, int py)
        {
            // Проверяем, находится ли точка близко к линии (с допуском)
            int tolerance = thickness + 3; // Увеличиваем допуск на толщину линии
            double distance = DistanceToLine(px, py, x + startX, y + startY, x + endX, y + endY);
            return distance <= tolerance;
        }

        // Реализация метода Draw
        public override void Draw(Graphics g)
        {
            Pen pen = isSelected ? new Pen(Color.Red, thickness) : new Pen(color, thickness); // Учитываем толщину
            int scaledStartX = (int)(startX * scale);
            int scaledStartY = (int)(startY * scale);
            int scaledEndX = (int)(endX * scale);
            int scaledEndY = (int)(endY * scale);

            // Рисуем линию с учётом масштаба
            g.DrawLine(pen, x + scaledStartX, y + scaledStartY, x + scaledEndX, y + scaledEndY);
        }

        // Переопределение метода Move для отрезка
        public override void Move(int dx, int dy, int maxX, int maxY)
        {
            // Вычисляем новые координаты центра
            int newX = x + dx;
            int newY = y + dy;

            // Определяем ширину и высоту отрезка с учётом масштаба
            int scaledWidth = (int)(GetWidth() * scale);
            int scaledHeight = (int)(GetHeight() * scale);

            // Учитываем толщину линии при проверке границ
            int halfThickness = thickness / 2;

            // Проверяем, чтобы ни одна часть отрезка не выходила за границы
            if (newX - scaledWidth / 2 - halfThickness < 0) newX = scaledWidth / 2 + halfThickness; // Левая граница
            if (newY - scaledHeight / 2 - halfThickness < 0) newY = scaledHeight / 2 + halfThickness; // Верхняя граница
            if (newX + scaledWidth / 2 + halfThickness > maxX) newX = maxX - scaledWidth / 2 - halfThickness; // Правая граница
            if (newY + scaledHeight / 2 + halfThickness > maxY) newY = maxY - scaledHeight / 2 - halfThickness; // Нижняя граница

            // Обновляем координаты центра
            x = newX;
            y = newY;
        }

        // Реализация метода Resize
        public override void Resize(float factor, int maxX, int maxY)
        {
            base.Resize(factor, maxX, maxY);

            // Масштабируем длину отрезка относительно центра
            int centerX = (startX + endX) / 2;
            int centerY = (startY + endY) / 2;

            startX = centerX - (int)((centerX - startX) * factor);
            startY = centerY - (int)((centerY - startY) * factor);
            endX = centerX + (int)((endX - centerX) * factor);
            endY = centerY + (int)((endY - centerY) * factor);
        }

        // Методы для получения исходных размеров
        protected override int GetWidth()
        {
            return Math.Abs(endX - startX); // Ширина отрезка
        }

        protected override int GetHeight()
        {
            return Math.Abs(endY - startY); // Высота отрезка
        }

        // Вспомогательный метод: расстояние от точки до линии
        private double DistanceToLine(int px, int py, int x1, int y1, int x2, int y2)
        {
            double lineLengthSquared = (x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1);
            if (lineLengthSquared == 0) return Distance(px, py, x1, y1);

            double t = ((px - x1) * (x2 - x1) + (py - y1) * (y2 - y1)) / lineLengthSquared;
            t = Math.Max(0, Math.Min(1, t));

            double projectionX = x1 + t * (x2 - x1);
            double projectionY = y1 + t * (y2 - y1);

            return Distance(px, py, (int)projectionX, (int)projectionY);
        }

        // Вспомогательный метод: расстояние между двумя точками
        private double Distance(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        }
    }
}