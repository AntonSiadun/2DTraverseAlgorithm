namespace SimpleAlgorithms
{
    public interface IMatrix<T>
    {
        public int Width { get; }
        public int Height { get; }

        public T this[Vector2Int position] { get; set; }

        public T[,] GetArray();
    }
}
