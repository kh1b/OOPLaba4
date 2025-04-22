using System;
using System.Drawing;

namespace OOPLaba4
{
    public abstract class BaseShape
    {
        protected int x, y; // Координаты центра или верхнего левого угла
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
            x += dx;
            y += dy;

            // Проверка выхода за границы
            if (x < 0) x = 0;
            if (y < 0) y = 0;
            if (x > maxX) x = maxX;
            if (y > maxY) y = maxY;
        }

        // Метод для изменения цвета
        public void ChangeColor(Color newColor)
        {
            color = newColor;
        }
    }
}