using System;

namespace SimpleAlgorithms
{
    public class Field<T> : IMatrix<T>
    {
        private T[,] _array;

        public Field(int width, int height)
        {
            if (width <= 0 || height <= 0)
                throw new ArgumentException("Widht and height must be positive values.");

            _array = new T[width, height];
        }

        public T this[int row, int column]
        {
            get => _array[row, column];
            set => _array[row, column] = value;
        }

        public int Width => _array.GetLength(1);
        public int Height => _array.GetLength(0);

        public T[,] GetArray()
        {
            T[,] result = new T[Height, Width];

            for(int i = 0; i < Height; i++)
            {
                for(int j = 0; j < Width; j++)
                {
                    result[i, j] = _array[i, j];
                }
            }
            return result;
        }
    }
}