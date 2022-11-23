namespace SimpleAlgorithms
{
    public interface IMatrix<T>
    {
        public int Width { get; }
        public int Height { get; }

        public T this[int row, int column] { get; set; }

        public T[,] GetArray();
    }
}
