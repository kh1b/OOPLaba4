using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLaba4
{
    public class ShapeStorage
    {
        private List<BaseShape> shapes = new List<BaseShape>();

        // Добавление новой фигуры
        public void AddShape(BaseShape shape)
        {
            shapes.Add(shape);
        }

        // Удаление всех выделенных фигур
        public void RemoveSelectedShapes()
        {
            shapes.RemoveAll(shape => shape.IsSelected());
        }

        // Получение всех фигур
        public List<BaseShape> GetShapes()
        {
            return shapes;
        }

        // Очистка контейнера
        public void Clear()
        {
            shapes.Clear();
        }
    }
}
