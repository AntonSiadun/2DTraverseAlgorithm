using System;

namespace Algorithms
{
    public class Field<T> : IMatrix<T>
    {
        private readonly T[,] _array;

        public Field(int width, int height)
        {
            if (width <= 0 || height <= 0)
                throw new ArgumentException("Widht and height must be positive values.");

            _array = new T[width, height];
        }

        public Field(T[,] array)
        {
            _array = array.Clone() as T[,];
        }

        public T this[Vector2Int position]
        {
            get => _array[position.Row, position.Column];
            set => _array[position.Row, position.Column] = value;
        }

        public int Width => _array.GetLength(1);
        public int Height => _array.GetLength(0);

        public T[,] GetArray()
        {
            T[,] result = _array.Clone() as T[,];
            return result;
        }
    }
}