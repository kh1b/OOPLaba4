using System;
using System.Drawing;

namespace OOPLaba4
{
    public abstract class BaseShape
    {
        // Добавляем коэффициент масштабирования
        protected float scale = 1.0f;

        protected int x, y; // Координаты верхнего левого угла
        protected Color color = Color.Blue; // Цвет фигуры
        protected bool isSelected; // Состояние выделения

        // Конструктор
        public BaseShape(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.isSelected = false;
        }

        // Метод для проверки, находится ли точка внутри фигуры
        public abstract bool ContainsPoint(int px, int py);

        // Метод для отрисовки фигуры
        public abstract void Draw(Graphics g);

        // Метод для изменения состояния выделения
        public void SetSelected(bool selected)
        {
            isSelected = selected;
        }

        // Геттер для состояния выделения
        public bool IsSelected()
        {
            return isSelected;
        }

        // Метод для перемещения фигуры
        public virtual void Move(int dx, int dy, int maxX, int maxY)
        {
            // Вычисляем новые координаты
            int newX = x + dx;
            int newY = y + dy;

            // Определяем ширину и высоту фигуры с учётом масштаба
            int scaledWidth = (int)(GetWidth() * scale);
            int scaledHeight = (int)(GetHeight() * scale);

            // Проверяем, чтобы ни одна часть фигуры не выходила за границы
            if (newX - scaledWidth / 2 < 0) newX = scaledWidth / 2; // Левая граница
            if (newY - scaledHeight / 2 < 0) newY = scaledHeight / 2; // Верхняя граница
            if (newX + scaledWidth / 2 > maxX) newX = maxX - scaledWidth / 2; // Правая граница
            if (newY + scaledHeight / 2 > maxY) newY = maxY - scaledHeight / 2; // Нижняя граница

            // Обновляем координаты
            x = newX;
            y = newY;
        }

        // Метод для изменения размера фигуры
        public virtual void Resize(float factor, int maxX, int maxY)
        {
            scale *= factor;

            // После изменения размера проверяем, чтобы фигура не выходила за границы
            Move(0, 0, maxX, maxY); // "Перемещаем" фигуру на месте, чтобы скорректировать положение
        }

        // Метод для изменения цвета
        public void ChangeColor(Color newColor)
        {
            color = newColor;
        }

        // Абстрактные методы для получения ширины и высоты фигуры
        protected abstract int GetWidth();
        protected abstract int GetHeight();
    }
}